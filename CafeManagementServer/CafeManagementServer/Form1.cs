using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CafeManagementServer.Database;
using BCrypt.Net;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace CafeManagementServer
{
    public partial class Form1 : Form
    {
        static public string korisnikIme;
        static public string korisnikPozicija;
        static public string korisnikNajava;

        private Excel.Application ExcelObj = null;

        ////Za primanje poraki od client sto se najavuva i odjavuva
        public void ThreadProc()
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 8080);
            TcpClient client = default(TcpClient);
            try
            {
                server.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Има проблем со конекцијата со клиент !!!");
            }
            while (true)
            {
                client = server.AcceptTcpClient();
                byte[] receivedBuffer = new byte[1024];
                NetworkStream stream = client.GetStream();
                stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                int count = Array.IndexOf<byte>(receivedBuffer, 0, 0);

                string msg = Encoding.UTF8.GetString(receivedBuffer, 0, count);
                byte[] sendData = Encoding.UTF8.GetBytes(msg);
                int b = sendData.Length;

                Login objPubFunc = new Login();
                Assets objAssets = new Assets();
                Insert objInsert = new Insert();
                Select objSelect = new Select();
                Update objUpdate = new Update();
                Delete objDelete = new Delete();
                List<string> porakaPrimena = objAssets.razdeli(msg);
                switch (porakaPrimena[0])
                {
                    case "najava":
                        objPubFunc.NajavaClient(porakaPrimena[1], porakaPrimena[2]);
                        break;
                    case "odjava":
                        objPubFunc.OdjavaClient(porakaPrimena[1], porakaPrimena[2], porakaPrimena[3], porakaPrimena[4]);
                        break;
                    case "insertKompanii":
                        objInsert.InsertKompanii(porakaPrimena[1], porakaPrimena[2], porakaPrimena[3], porakaPrimena[4], porakaPrimena[5]);//1238 menadzer site kompanii
                        break;
                    case "selectKompanii":
                        objSelect.selectKompanii(porakaPrimena[1]);//port 1237 (vnesi nov proizvod menadzer), 1238 menadzer site kompanii
                        break;
                    case "selectKompaniiAktivna":
                        objSelect.selectKompaniiAktivna(porakaPrimena[1]);//port 1237 (vnesi nov proizvod menadzer), 1238 menadzer site kompanii
                        break;
                    case "updateKompanii":
                        objUpdate.UpdateKompanii(porakaPrimena[1], porakaPrimena[2], porakaPrimena[3], porakaPrimena[4], porakaPrimena[5], porakaPrimena[6]);//1238 menadzer site kompanii
                        break;
                    case "deleteKompanii":
                        objDelete.DeleteKompanii(porakaPrimena[1], porakaPrimena[2]);//1238 menadzer site kompanii
                        break;
                    case "insertProizvodi":
                        objInsert.InsertProizvodi(porakaPrimena[1], porakaPrimena[2], porakaPrimena[3], porakaPrimena[4], porakaPrimena[5], porakaPrimena[6], porakaPrimena[7]);//port-1237 vnesi nov proizvod vo menadzer
                        break;
                    case "selectProizvodi":
                        objSelect.selectProizvodi(porakaPrimena[1]);//da
                        break;
                    case "selectProizvodiAktivni":
                        objSelect.selectProizvodiAktivni(porakaPrimena[1]);//da
                        break;
                    case "selectProizvodiWhere":
                        objSelect.selectProizvodiWhere(porakaPrimena[1], porakaPrimena[2]);//port 1237 (vnesi nov proizvod menadzer)
                        break;
                    case "deleteProizvodi":
                        objDelete.DeleteProizvodi(porakaPrimena[1], porakaPrimena[2]);////port 1237 (vnesi nov proizvod menadzer)
                        break;
                    case "updateProizvodi":
                        objUpdate.UpdateProizvodi(porakaPrimena[1], porakaPrimena[2], porakaPrimena[3], porakaPrimena[4], porakaPrimena[5], porakaPrimena[6], porakaPrimena[7]);//port 1237 (vnesi nov proizvod menadzer)
                        break;
                     case "insertNaracki":
                        objInsert.InsertNaracki(porakaPrimena[1], porakaPrimena[2], porakaPrimena[3], porakaPrimena[4], porakaPrimena[5], porakaPrimena[6], porakaPrimena[7]);
                        break;
                    case "selectNarackaSank"://1236 sank
                        objSelect.SelectNarackaSank(porakaPrimena[1]);
                        break;
                    case "insertPredajSostojbaSank"://1236 predaja Sostojbata
                       objInsert.InsertPredajSostojbaSank(porakaPrimena[1], porakaPrimena[2], porakaPrimena[3], porakaPrimena[4]);
                        break;
                    case "selectNaracki":
                        objSelect.SelectNaracki(porakaPrimena[1], porakaPrimena[2]);//da
                        break;
                    case "selectNarackiKelner":
                        objSelect.SelectNarackiKelner(porakaPrimena[1], porakaPrimena[2]);//da
                        break;
                    case "selectNarackiVkupenPromet":
                        objSelect.SelectNarackiVkupenPromet(porakaPrimena[1]);//nemora
                        break;
                    case "insertNarackiVkupenPromet":
                        objInsert.InsertNarackiVkupenPromet(porakaPrimena[1], porakaPrimena[2], porakaPrimena[3], porakaPrimena[4], porakaPrimena[5]);//SO poraki kontaktira
                        break;
                    case "selectFakturi":
                        objSelect.SelectFakturi(porakaPrimena[1]);//port 1237(vnesi nov proizovod vo menadzer)
                        break;
                    case "updateFakturi":
                        objUpdate.UpdateFakturi(porakaPrimena[1], porakaPrimena[2]);//port 1237(vnesi nov proizovod vo menadzer)
                        break;
                    case "selectEvidencijaRabotnici":
                        objSelect.SelectEvidencijaRabotnici(porakaPrimena[1]);//1239 otcituvanje
                        break;
                    case "selectVkupenPrometKelneri":
                        objSelect.SelectVkupenPrometKelneri(porakaPrimena[1]);//1239 otcituvanje
                        break;
                    case "deleteNaracki":
                        objDelete.DeleteNaracki(porakaPrimena[1], porakaPrimena[2],porakaPrimena[4], porakaPrimena[3]);//1239 otcituvanje
                        break;
                    case "deleteNarackiSank":
                        objDelete.DeleteNarackiSank(porakaPrimena[1], porakaPrimena[2], porakaPrimena[4], porakaPrimena[3]);//1239 otcituvanje
                        break;
                    case "selectPredaenaSostojbaSank":
                        objSelect.SelectPredaenaSostojbaSank(porakaPrimena[1]);//1239 otcituvanje
                        break;
                    default:
                        MessageBox.Show("Нема примено никаква порака од клиент !!!");
                        break;
                }
            }
        }

        //Za excel 
        public void ThreadProcExcel()
        {
            TcpListener server = null;
            try
            {
                // Set the IP address and port number for the server
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                int port = 1027;
                System.Threading.Thread.Sleep(1000);
                // Create a TcpListener to listen for incoming connections
                server = new TcpListener(ipAddress, port);

                // Start listening for client requests
                server.Start();

                //MessageBox.ShowLine("Server is waiting for connections...");

                while (true)
                {
                    // Accept a client connection
                    TcpClient client = server.AcceptTcpClient();
                    // MessageBox.ShowLine("Client connected!");

                    // Get the network stream for reading
                    NetworkStream stream = client.GetStream();

                    // Receive the file name and create a file stream to save the Excel file
                    byte[] fileNameData = new byte[1024];
                    int fileNameBytesRead = stream.Read(fileNameData, 0, fileNameData.Length);
                    string fileName = Encoding.UTF8.GetString(fileNameData, 0, fileNameBytesRead);//КИРИЛИЦА UTF8 NAMESTO ASCII bidejki ne ja cita kirilicata
                    fileName = Path.GetFileName(fileName);
                    FileStream fileStream = File.Create(fileName);

                    // Receive and save the Excel file data
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }

                    // Close the client connection and file stream
                    fileStream.Close();
                    client.Close();
                    Insert objInsert = new Insert();
                    Update objUpdate = new Update();
                    if (fileName == "InsertNarackiSank.xlsx")
                    {
                        objInsert.InsertNarackiSank(fileName);
                    }else if(fileName == "UpdatePredajSostojbaSank.xlsx")
                    {
                        objUpdate.UpdatePredajSostojbaSank(fileName);
                    } 
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                // Stop listening for incoming connections
                server.Stop();
            }
        }


        public Form1()
        {
            InitializeComponent();
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            objSql.CreateTables();

            ////Za primanje poraki od client sto se najavuva i odjavuva
            Thread thread = new Thread(t =>
            {
                ThreadProc();
            })
            {
                IsBackground = true
            };
            thread.Start();

            //thread za Excel file
            Thread threadExcel = new Thread(t =>
            {
                ThreadProcExcel();
            })
            {
                IsBackground = true
            };
            threadExcel.Start();


            ExcelObj = new Excel.Application();
            if (ExcelObj == null)
            {
                MessageBox.Show("ERROR: EXCEL couldn't be started!");
                System.Windows.Forms.Application.Exit();
            }
            ExcelObj.Visible = false;
        }

        private void btnNajava_Click(object sender, EventArgs e)
        {
            if (tbKorisnickoIme.Text != "" && tbLozinka.Text != "")
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string korisnickoIme = "";
                string pozicija = "";
                string lozinka = "";
                SqlDataReader sqlite_datareader = objSql.SelectNajava(tbKorisnickoIme.Text);
                while (sqlite_datareader.Read())
                {
                    korisnickoIme = sqlite_datareader.GetValue(0).ToString();
                    pozicija = sqlite_datareader.GetValue(1).ToString();
                    lozinka = sqlite_datareader.GetValue(2).ToString();
                 
                }
                objSql.CloseConnection();

                if(korisnickoIme != "" && pozicija != "" && lozinka != "")
                {
                    bool daliEtocenaLozinkata = BCrypt.Net.BCrypt.Verify(tbLozinka.Text, lozinka);

                    if (daliEtocenaLozinkata)
                    {
                        if(pozicija == "sopstvenik")
                        {
                            DateTime currentDate = DateTime.Now;
                            string vreme = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                            korisnikIme = korisnickoIme;
                            korisnikPozicija = pozicija;
                            korisnikNajava = vreme;
                            List<string> evidencijaKoloni = new List<string>() { "datum", "vreme_najava", "vreme_odjava", "zabeleshka_evidencija", "korisnicko_ime_evidencija" };
                            List<string> evidencijaVrednosti = new List<string>() { "GETDATE()", vreme, "", "", korisnickoIme };
                            objSql.InsertRow(evidencijaKoloni, evidencijaVrednosti, "Evidencija_rabotno_vreme");
                            tbKorisnickoIme.Clear();
                            tbLozinka.Clear();
                            Sopstvenik objSopstvenik = new Sopstvenik();
                            objSopstvenik.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Во системот се најавува само сопственикот !!!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Внесувате неисправна лозинка !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Внесувате неисправно корисничко име !!!");
                }
            }
            else
            {
                MessageBox.Show("Полињата се задолжителни !!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNajava_MouseClick(object sender, MouseEventArgs e)
        {

        }

 
    }
}
