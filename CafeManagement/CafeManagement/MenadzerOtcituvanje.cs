using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;
using System.Security.Policy;

namespace CafeManagement
{
    public partial class MenadzerOtcituvanje : Form
    {

        private Excel.Application ExcelObj = null;
        public int port = 1239;

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
                        case "SelectEvidencijaRabotnici.xlsx":
                            SelectEvidencijaRabotnici(fileName);
                            break;
                        case "SelectVkupenPrometKelneri.xlsx":
                            SelectVkupenPrometKelneri(fileName);
                            break;
                        case "SelectPredaenaSostojbaSank.xlsx":
                            SelectPredaenaSostojbaSank(fileName);
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
        public MenadzerOtcituvanje()
        {
            InitializeComponent();

            lvEvidencijaDenes.View = View.Details;
            lvEvidencijaDenes.GridLines = true;
            lvEvidencijaDenes.FullRowSelect = true;

            lvEvidencijaDenes.Columns.Add("Датум", 200);
            lvEvidencijaDenes.Columns.Add("Време најава", 200);
            lvEvidencijaDenes.Columns.Add("Време одјава", 200);
            lvEvidencijaDenes.Columns.Add("Пресметка на работно време во часови", 200);
            lvEvidencijaDenes.Columns.Add("Корисничко име", 200);
            lvEvidencijaDenes.Columns.Add("Име на вработен", 200);
            lvEvidencijaDenes.Columns.Add("Презиме на вработен", 200);
            lvEvidencijaDenes.Columns.Add("Позиција на вработен", 200);
            lvEvidencijaDenes.Columns.Add("Забелешка", 200);

            lvPredadenPromet.View = View.Details;
            lvPredadenPromet.GridLines = true;
            lvPredadenPromet.FullRowSelect = true;
            lvPredadenPromet.Columns.Add("Вкупно предаден промет", 200);
            lvPredadenPromet.Columns.Add("Време на предаден промет", 200);
            lvPredadenPromet.Columns.Add("Корисничко име", 200);
            lvPredadenPromet.Columns.Add("Име", 200);
            lvPredadenPromet.Columns.Add("Презиме", 200);

            lvSank.View = View.Details;
            lvSank.GridLines = true;
            lvSank.FullRowSelect = true;
            lvSank.Columns.Add("Датум и време на предадена состојба", 200);
            lvSank.Columns.Add("Корисничко име", 200);
            lvSank.Columns.Add("Име", 200);
            lvSank.Columns.Add("Презиме", 200);
            lvSank.Columns.Add("Забелешка за предадена состојба", 200);

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
            string poraka = "selectEvidencijaRabotnici#"+port;
            objKomunikacija.PorakaZaServer(poraka);

            string porakaKelner = "selectVkupenPrometKelneri#"+port;
            objKomunikacija.PorakaZaServer(porakaKelner);

            string porakaSanker = "selectPredaenaSostojbaSank#" + port;
            objKomunikacija.PorakaZaServer(porakaSanker);
        }

        public void SelectEvidencijaRabotnici(string fileName)
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

            lvEvidencijaDenes.Items.Clear();

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                string vremeOdjava = "";
                if (strArray.GetValue(2).ToString() != "01.1.1900 00:00:00")
                {
                    vremeOdjava = strArray.GetValue(2).ToString();
                }
                string[] arr = new string[9];
                ListViewItem itm;
                string denes = "";
                if(DateTime.TryParse(strArray.GetValue(0).ToString(), out DateTime datum)){
                    denes = datum.ToString("yyyy-MM-dd");   
                }

                arr[0] = denes;
                arr[1] = strArray.GetValue(1).ToString();
                arr[2] = vremeOdjava;
                if (DateTime.TryParse(arr[1], out DateTime startDate) && DateTime.TryParse(arr[2], out DateTime endDate))
                {

                    TimeSpan timeDifference = endDate - startDate;
                    int hoursDifference = timeDifference.Hours;
                    int minutesDifference = timeDifference.Minutes;

                    string timeDifferenceStr = hoursDifference + " час и " + minutesDifference + " минути";

                    if (timeDifferenceStr[0] == '-')
                    {
                        arr[3] = "";
                    }
                    else
                    {
                        arr[3] = timeDifferenceStr;
                    }

                };
                arr[4] = strArray.GetValue(3).ToString();
                arr[5] = strArray.GetValue(4).ToString();
                arr[6] = strArray.GetValue(5).ToString();
                arr[7] = strArray.GetValue(6).ToString();
                arr[8] = strArray.GetValue(7).ToString();

                itm = new ListViewItem(arr);
                lvEvidencijaDenes.Items.Add(itm);
            }
        }

        public void SelectVkupenPrometKelneri(string fileName)
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

            lvPredadenPromet.Items.Clear();

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                lvPredadenPromet.Invoke((MethodInvoker)delegate
                {
                    ListViewItem itm;
                    itm = new ListViewItem(strArray);
                    lvPredadenPromet.Items.Add(itm);
                });
            }
        }

        public void SelectPredaenaSostojbaSank(string fileName)
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

            lvSank.Items.Clear();

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                lvSank.Invoke((MethodInvoker)delegate
                {
                    ListViewItem itm;
                    itm = new ListViewItem(strArray);
                    lvSank.Items.Add(itm);
                });
            }
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MenadzerOtcituvanje_Load(object sender, EventArgs e)
        {

        }

        private void lvPredadenPromet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvEvidencijaDenes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            Thread threadExcel = new Thread(t =>
            {
                ThreadProcExcel();
            })
            {
                IsBackground = true
            };
            threadExcel.Start();
            Komunikacija objKomunikacija = new Komunikacija();
            string poraka = "selectEvidencijaRabotnici#"+port;
            objKomunikacija.PorakaZaServer(poraka);

            string porakaKelner = "selectVkupenPrometKelneri#" + port;
            objKomunikacija.PorakaZaServer(porakaKelner);

            string porakaSanker = "selectPredaenaSostojbaSank#" + port;
            objKomunikacija.PorakaZaServer(porakaSanker);
        }
    }
}
