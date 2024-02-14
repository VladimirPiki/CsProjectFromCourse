using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;


namespace CafeManagement
{
    public partial class KelnerSiteNaracki : Form
    {
        private Excel.Application ExcelObj = null;

        public int port = 1235;

        private TcpListener server;

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
                        server = new TcpListener(ip, 8089);
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

                    Assets objPubFunc = new Assets();
                    List<string> porakaPrimena = objPubFunc.razdeli(msg);

                    switch (porakaPrimena[0])
                    {
                        case "vkupenPromet":
                            rbPromet.Text = porakaPrimena[1];
                            break;
                        case "vkupenPrometPredaden":
                            MessageBox.Show("Прометот за денешниот ден е предаден !!!");
                            break;
                        case "vkupenPrometUspesnoPredaden":
                            MessageBox.Show("Прометот за денешниот ден е УСПЕШНО предаден !!!");
                            break;
                        default:
                            MessageBox.Show("Нема примено никаква порака од клиент !!!");
                            break;
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
                    Assets objAssets = new Assets();
                    List<string> ime = objAssets.split(fileName, ".");
                    fileName = ime[0] + ".xlsx";
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

                    switch (fileName)
                    {
                        case "SelectNaracki.xlsx":
                            SelectNaracki(fileName);
                            break;
                        case "SelectNarackiKelner.xlsx":
                            SelectNarackaSank(fileName);
                            break;
                    };
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
        public KelnerSiteNaracki()
        {
            InitializeComponent();

            Thread threadClient = new Thread(t =>
            {
                ThreadProc();
            })
            {
                IsBackground = true
            };
            threadClient.Start();

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

            lvSite.View = View.Details;
            lvSite.GridLines = true;
            lvSite.FullRowSelect = true;
            lvSite.Columns.Add("Шифра на сметка", 300);
            lvSite.Columns.Add("Корисничко име на келнер", 300);
            lvSite.Columns.Add("Време на сметка", 300);
            lvSite.Columns.Add("Вкупен промет на сметката", 300);
            lvSite.Columns.Add("Шифра", 0);

            lvPoedinecno.View = View.Details;
            lvPoedinecno.GridLines = true;
            lvPoedinecno.FullRowSelect = true;
            lvPoedinecno.Columns.Add("Време нарачка", 200);
            lvPoedinecno.Columns.Add("Корисничко име на келнер", 200);
            lvPoedinecno.Columns.Add("Име на производ", 200);
            lvPoedinecno.Columns.Add("Продадена количина", 200);
            lvPoedinecno.Columns.Add("Цена на производ", 200);
            lvPoedinecno.Columns.Add("Вкупна цена", 200);

            Komunikacija objKomunikacija = new Komunikacija();
            string poraka = "selectNaracki#" + Form1.korisnikIme + "#" + port;
            objKomunikacija.PorakaZaServer(poraka);

            string porakaFakturi = "selectNarackiKelner#" + Form1.korisnikIme + "#" + port;
            objKomunikacija.PorakaZaServer(porakaFakturi);

            string porakaKompanii = "selectNarackiVkupenPromet#" + Form1.korisnikIme;
            objKomunikacija.PorakaZaServer(porakaKompanii);

        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            try
            {
                Thread threadClient = new Thread(t =>
                {
                    ThreadProc();
                })
                {
                    IsBackground = true
                };
                threadClient.Start();

                //thread za Excel file
                Thread threadExcel = new Thread(t =>
                {
                    ThreadProcExcel();
                })
                {
                    IsBackground = true

                };
                threadExcel.Start();

                Komunikacija objKomunikacija = new Komunikacija();
                string poraka = "selectNaracki#" + Form1.korisnikIme + "#" + port;
                objKomunikacija.PorakaZaServer(poraka);

                string porakaFakturi = "selectNarackiKelner#" + Form1.korisnikIme + "#" + port;
                objKomunikacija.PorakaZaServer(porakaFakturi);

                string porakaKompanii = "selectNarackiVkupenPromet#" + Form1.korisnikIme;
                objKomunikacija.PorakaZaServer(porakaKompanii);
            }
            catch
            {
                MessageBox.Show("Има проблем со прикажувањето нарачките !!!");
            }
        }

        private void KelnerSiteNaracki_Load(object sender, EventArgs e)
        {

        }

        private void btnPredajPromet_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни за предавање на прометот од " + rbPromet.Text + " ?", "Потврда за предавање на промет", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Komunikacija objKomunikacija = new Komunikacija();
                    DateTime datetime = DateTime.Now;
                    string vreme = datetime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string den = datetime.ToString("yyyy-MM-dd");
                    string poraka = "insertNarackiVkupenPromet#" + vreme + "#" + rbPromet.Text + "#" + Form1.korisnikIme + "#" + "Предавање промет на келнер : " + Form1.korisnikIme + "#" + den;// kontaktira so poraki
                    objKomunikacija.PorakaZaServer(poraka);
                }
                catch
                {
                    MessageBox.Show("Има проблем со предавањето на прометот");
                }
            }

        }

        public void SelectNaracki(string fileName)
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

            lvSite.Items.Clear();

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                lvSite.Invoke((MethodInvoker)delegate
                {
                    ListViewItem itm;
                    itm = new ListViewItem(strArray);
                    lvSite.Items.Add(itm);
                });
            }
        }

        public void SelectNarackaSank(string fileName)
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
            lvPoedinecno.Items.Clear();

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                lvPoedinecno.Invoke((MethodInvoker)delegate
                {
                    ListViewItem itm;
                    itm = new ListViewItem(strArray);
                    lvPoedinecno.Items.Add(itm);
                });
            }
        }

        private void KelnerSiteNaracki_FormClosing(object sender, FormClosingEventArgs e)
        {
            server?.Stop();
        }

        private void KelnerSiteNaracki_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread threadClient = new Thread(t =>
            {
                ThreadProc();
            })
            {
                IsBackground = true
            };
            threadClient.Abort();
        }

        private void lvSite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStornirajSmetka_Click(object sender, EventArgs e)
        {
            if (lvSite.SelectedItems.Count > 0)
            {
                Komunikacija objKomunikacija = new Komunikacija();
                ListViewItem selectedItem = lvSite.SelectedItems[0];
                if (selectedItem.SubItems[0].Text != "")
                {

                    DateTime date = DateTime.Parse(selectedItem.SubItems[2].Text);
                    string vreme = date.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    DateTime currentDate = DateTime.Now;
                    string den = currentDate.ToString("yyyy-MM-dd");

                    string poraka = "deleteNaracki#" + vreme + "#" + den + "#" + Form1.korisnikIme + "#" + port;
                    objKomunikacija.PorakaZaServer(poraka);

                    string poraka1 = "deleteNarackiSank#" + vreme + "#" + den + "#" + Form1.korisnikIme + "#" + port;
                    objKomunikacija.PorakaZaServer(poraka1);
                }
                else
                {
                    MessageBox.Show("Ве молам изберете од листата кој прозвод да го избришете од листата!!");
                }
            }
        }

        private void rbPromet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
