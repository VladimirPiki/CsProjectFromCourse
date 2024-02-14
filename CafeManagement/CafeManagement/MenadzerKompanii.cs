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
using OfficeOpenXml;
using System.Globalization;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace CafeManagement
{
    public partial class MenadzerKompanii : Form
    {

        private Excel.Application ExcelObj = null;
        public int port = 1238;

        //Za excel 
        public void ThreadProcExcel()
        {
            TcpListener server = null;
            try
            {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                System.Threading.Thread.Sleep(1000);
                server = new TcpListener(ipAddress, port);
                server.Start();
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
 
                    byte[] fileNameData = new byte[1024];
                    int fileNameBytesRead = stream.Read(fileNameData, 0, fileNameData.Length);
                    string fileName = Encoding.UTF8.GetString(fileNameData, 0, fileNameBytesRead);//КИРИЛИЦА UTF8 NAMESTO ASCII bidejki ne ja cita kirilicata
                    fileName = Path.GetFileName(fileName);
                    FileStream fileStream = File.Create(fileName);

                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }

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
                server.Stop();
            }
        }
        public MenadzerKompanii()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Ид на компанијата", 200);
            listView1.Columns.Add("Име на компанијата", 200);
            listView1.Columns.Add("Трансакциска сметка", 200);
            listView1.Columns.Add("Датум на склучување на договор", 200);
            listView1.Columns.Add("Соработка", 200);

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
            string poraka = "selectKompanii#"+port;
            objKomunikacija.PorakaZaServer(poraka);

        }

        private void btnZacuvajNovaKomp_Click(object sender, EventArgs e)
        {
            if(tbImeKompanija.Text !="" && tbTransakcija.Text != "")
            {
                if (tbTransakcija.Text.Length == 15)
                {
                    long transakciska_smetka;
                    bool daliebroj = Int64.TryParse(tbTransakcija.Text, out transakciska_smetka);
                    if (daliebroj)
                    {
                        DateTime datumOdPicker = datumSorabotka.Value;
                        string datumSorabotkaIsprati = datumOdPicker.ToString("yyyy-MM-dd");

                        Komunikacija objKomunikacija = new Komunikacija();
                            string poraka = "insertKompanii#" + tbImeKompanija.Text + "#" + transakciska_smetka + "#" + datumSorabotkaIsprati + "#aktivna#"+port;
                         objKomunikacija.PorakaZaServer(poraka);
        
                    }
                    else
                    {
                        MessageBox.Show("ДОЗВОЛЕНИ СЕ САМО ЦИФРИ !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Во полето за трансакција внесете 15 цифрен број !!!");
                }
            }
            else
            {
                MessageBox.Show("Сите полиња се задолжителни !!!");
            }
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

                string[] arr = new string[5];
                ListViewItem itm;

                arr[0] = strArray[0];
                arr[1] = strArray[1];
                arr[2] = strArray[2];
                if(DateTime.TryParse(strArray[3], out DateTime datum)){
                    arr[3] = datum.ToString("yyyy-MM-dd");
                }
                arr[4] = strArray[4];

                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
          
        }

        private void datumSorabotka_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MenadzerKompanii_Load(object sender, EventArgs e)
        {

        }

        private void btnPrikazigiSite_Click(object sender, EventArgs e)
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
            string poraka = "selectKompanii#"+port;
            objKomunikacija.PorakaZaServer(poraka);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                tbUpdateId.Text = selectedItem.SubItems[0].Text;
                tbUpdateIme.Text = selectedItem.SubItems[1].Text;
                tbUpdateTransakcija.Text = selectedItem.SubItems[2].Text;
                datumSorabotkaUpdate.Text = selectedItem.SubItems[3].Text;
                tbUpdateStatus.Text = selectedItem.SubItems[4].Text;
            }
            else
            {
                MessageBox.Show("Ве молам изберете од листата со која компанија сакате да промените вредност !!!");
            }
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (tbUpdateId.Text != "" && tbUpdateIme.Text != "" && tbUpdateTransakcija.Text != "" && tbUpdateStatus.Text != "")
            {
                if (tbUpdateTransakcija.Text.Length == 15)
                {
                    long transakciska_smetka;
                    bool daliebroj = Int64.TryParse(tbUpdateTransakcija.Text, out transakciska_smetka);
                    if (daliebroj)
                    {
                        DateTime datumOdPicker = datumSorabotkaUpdate.Value;
                        string datumSorabotkaIsprati = datumOdPicker.ToString("yyyy-MM-dd");

                        Komunikacija objKomunikacija = new Komunikacija();
                        string poraka = "updateKompanii#" + tbUpdateIme.Text + "#" + transakciska_smetka + "#" + datumSorabotkaIsprati + "#"+tbUpdateStatus.Text+"#"+tbUpdateId.Text+"#"+port;
                        objKomunikacija.PorakaZaServer(poraka);
                    }
                    else
                    {
                        MessageBox.Show("ДОЗВОЛЕНИ СЕ САМО ЦИФРИ !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Во полето за трансакција внесете 15 цифрен број !!!");
                }
            }
            else
            {
                MessageBox.Show("Сите полиња се задолжителни !!!");
            }
        }

        private void listView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                tbUpdateId.Text = selectedItem.SubItems[0].Text;
                tbUpdateIme.Text = selectedItem.SubItems[1].Text;
                tbUpdateTransakcija.Text = selectedItem.SubItems[2].Text;
                datumSorabotkaUpdate.Text = selectedItem.SubItems[3].Text;
                tbUpdateStatus.Text = selectedItem.SubItems[4].Text;
            }
        }
    }
}
