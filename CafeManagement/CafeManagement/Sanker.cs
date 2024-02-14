using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using Org.BouncyCastle.Math;
using System.Security.Cryptography.X509Certificates;

namespace CafeManagement
{
    public partial class Sanker : Form
    {
        private Excel.Application ExcelObj = null;


        private TcpListener server;
        private bool sostojba=false;

        public void ThreadProc()
        {
            try
            {
                while (true)
                {
                    // Check if the server is not initialized or is not actively listening
                    if (server == null || !server.Server.IsBound)
                    {
                        // Initialize the TcpListener
                        IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
                        server = new TcpListener(ip, 8084);
                        server.Start();
                    }

                    TcpClient client = server.AcceptTcpClient();
                    byte[] receivedBuffer = new byte[1024];
                    NetworkStream stream = client.GetStream();
                    stream.Read(receivedBuffer, 0, receivedBuffer.Length);
                    int count = Array.IndexOf<byte>(receivedBuffer, 0, 0);

                    string msg = Encoding.UTF8.GetString(receivedBuffer, 0, count);
                    byte[] sendData = Encoding.UTF8.GetBytes(msg);
                    int b = sendData.Length;

                    if(msg == "uspesnoPredaenaSostojba")
                    {
                       UpdatePredajSostojbaSank();
                       sostojba = true; 
                        MessageBox.Show("Успешно ја предадовте состојбата.");
                    }else if(msg == "neuspesnoPredaenaSostojba")
                    {
                        MessageBox.Show("Состојбата за денешниот ден е предаена !!!");
                    }
                  
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                // Close the TcpListener in the finally block to ensure cleanup
                server?.Stop();
            }
        }

        public int port = 1236;

        //Za excel 
        public void ThreadProcExcel()
        {
            TcpListener server = null;
            try
            {
                // Set the IP address and port number for the server
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
       
                System.Threading.Thread.Sleep(1000);
                // Create a TcpListener to listen for incoming connections
                server = new TcpListener(ipAddress, port);

                // Start listening for client requests
                server.Start();

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

                    PrikazigiSitePodatociVoListview(fileName);
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
        public Sanker()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Време нарачка", 200);// име на пијачка
            listView1.Columns.Add("Корисничко име", 200);// тип на производот
            listView1.Columns.Add("Име на производ", 200);
            listView1.Columns.Add("Продадена количина", 200);
            listView1.Columns.Add("Цена на производ", 200);
            listView1.Columns.Add("Вкупна цена", 200);

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

            Komunikacija objKomunikacija = new Komunikacija();
            string poraka = "selectNarackaSank#"+port;
            objKomunikacija.PorakaZaServer(poraka);
        }

        private void btnVnesiPoracka_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Sanker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Дали навистина сакате да се одјавите ?", "Потврда за одјавување", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DateTime currentDate = DateTime.Now;
                    string vreme = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string korisnikIme = Form1.korisnikIme;
                    string korisnikNajava = Form1.korisnikNajavaVreme;
                    Komunikacija objKomunikacija = new Komunikacija();
                    objKomunikacija.Odjava(vreme, tbZabeleshka.Text, korisnikNajava, korisnikIme);
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the form closing action
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void PrikazigiSitePodatociVoListview(string fileName)
        {
            Assets objPublicFunction = new Assets();
            FileInfo excelFile = new FileInfo(fileName);

            Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(excelFile.FullName, 0, true, 5,
            "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);

            Excel.Sheets sheets = theWorkbook.Worksheets;

            Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);


            int lastUsedRow = 0;
            lastUsedRow = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                                           System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                           Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                                           false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

            // Find the last real column
            int lastUsedColumn = 0;
            lastUsedColumn = worksheet.Cells.Find("*", System.Reflection.Missing.Value,
                                             System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                                             Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious,
                                             false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;


            string columnName = objPublicFunction.ExcelColumnFromNumber(lastUsedColumn);
            listView1.Items.Clear();

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                listView1.Invoke((MethodInvoker)delegate
                {
                    ListViewItem itm;
                    itm = new ListViewItem(strArray);
                    listView1.Items.Add(itm);
                });
            }
        }

        private void Sanker_Load(object sender, EventArgs e)
        {

        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            //thread za Excel file
            Thread threadExcel = new Thread(t =>
            {
                ThreadProcExcel();
            })
            {
                IsBackground = true
            };
            threadExcel.Start();


            Thread threadClient = new Thread(t =>
            {
                ThreadProc();
            })
            {
                IsBackground = true
            };
            threadClient.Start();

            Komunikacija objKomunikacija = new Komunikacija();
            string poraka = "selectNarackaSank#" + port;
            objKomunikacija.PorakaZaServer(poraka);
        }

        private void btnPredajSostojba_Click(object sender, EventArgs e) // з
        {
            Komunikacija objKomunikacija = new Komunikacija();
           // Assets objAssets = new Assets();

            DateTime currentDate = DateTime.Now;
            string vreme = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string den = currentDate.ToString("yyyy-MM-dd");
            string zabeleshka = "Нема забелешка";
            if(tbZabeleshka.Text != "")
            {
                zabeleshka=tbZabeleshka.Text;   
            }

            string poraka = "insertPredajSostojbaSank#" + vreme + "#" + Form1.korisnikIme + "#" + zabeleshka+"#"+ den;
            objKomunikacija.PorakaZaServer(poraka);
            if (sostojba)
            {
                UpdatePredajSostojbaSank();
            }
        }

        public void UpdatePredajSostojbaSank()
        {
            Komunikacija objKomunikacija = new Komunikacija();
            Assets objAssets = new Assets();

            string exportPath = "";

            exportPath = objAssets.NapraviExcelOdListView(exportPath, listView1, "UpdatePredajSostojbaSank");
            if (exportPath != "")
            {
                objKomunikacija.IspratiExcel(exportPath);
            }
        }
    }
}
