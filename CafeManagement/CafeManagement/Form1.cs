using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CafeManagement
{
    public partial class Form1 : Form
    {
        static public string korisnikIme;
        static public string korisnikPozicija;
        static public string korisnikNajavaVreme;

        ////Za primanje poraki od serverot dali e tocen korisnickoto ime ili ne e
        public void ThreadProc()
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 8085);
            TcpClient client = default(TcpClient);
            try
            {
                server.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Има проблем со конекцијата со сервер!!!");
            }
            while (true)
            {
                client = server.AcceptTcpClient();
                byte[] receivedBuffer = new byte[1024];
                NetworkStream stream = client.GetStream();
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                int count = Array.IndexOf<byte>(receivedBuffer, 0, 0);

                string msg = Encoding.UTF8.GetString(receivedBuffer, 0, count);//КИРИЛИЦА UTF8 NAMESTO ASCII bidejki ne ja cita kirilicata
                byte[] sendData = Encoding.UTF8.GetBytes(msg); //КИРИЛИЦА UTF8 NAMESTO ASCII bidejki ne ja cita kirilicata
                int b = sendData.Length;

                Assets objPubFunc = new Assets();

                List<string> porakaPrimena = objPubFunc.razdeli(msg);

                switch (porakaPrimena[0])
                {
                    case "najavaUspesna":
                        korisnikIme = porakaPrimena[1];
                        korisnikPozicija = porakaPrimena[2];
                        korisnikNajavaVreme = porakaPrimena[3];

                        if (korisnikPozicija == "menadzer")
                        {
                            Menadzer objMenadzer = new Menadzer();
                            objMenadzer.ShowDialog();
                        }
                        else if (korisnikPozicija == "sanker")
                        {
                            Sanker objSanker = new Sanker();
                            objSanker.ShowDialog();
                        }
                        else if (korisnikPozicija == "kelner")
                        {
                            Kelner objKelner = new Kelner();
                            objKelner.ShowDialog();
                        }
                        else if (korisnikPozicija == "sopstvenik")
                        {
                            Menadzer objMenadzer = new Menadzer();
                            objMenadzer.ShowDialog();
                        }
                        break;
                    case "najavaPogresenoKorisnickoIme":
                        MessageBox.Show("Внесувате неисправно корисничко име !!!");
                        break;
                    case "najavaPogresnaLozinka":
                        MessageBox.Show("Внесувате неисправна лозинка !!!");
                        break;
                    default:
                        MessageBox.Show("Нема примено никаква порака од клиент !!!");
                        break;
                }
            }
        }
        public Form1()
        {
            InitializeComponent();

            ////Za primanje poraki od serverot dali e tocen korisnickoto ime ili ne e
            Thread threadClient = new Thread(t =>
            {
                ThreadProc();
            })
            {
                IsBackground = true
            };
            threadClient.Start();
        }

        //Kopce za najava
        private void btnNajava_Click(object sender, EventArgs e)
        {
            if(tbKorisnickoIme.Text != ""&& tbLozinka.Text != "")
            {
                Komunikacija objKomunikacija = new Komunikacija();

                objKomunikacija.Najava(tbKorisnickoIme.Text, tbLozinka.Text);
                tbKorisnickoIme.Clear();
                tbLozinka.Clear();
            }
            else
            {
                MessageBox.Show("Полињата се задолжителни !!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
