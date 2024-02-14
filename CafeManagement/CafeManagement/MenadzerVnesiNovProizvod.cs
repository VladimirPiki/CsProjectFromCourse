using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;


namespace CafeManagement
{
    public partial class MenadzerVnesiNovProizvod : Form
    {

        private Excel.Application ExcelObj = null;
        public int port = 1237;

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
                        server = new TcpListener(ip, 8086);
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
                        case "proizvodiSifraExist":
                            MessageBox.Show("Внесувате постоечка шифра !!!");
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
                    Assets objAssets = new Assets();
                    List<string> ime = objAssets.split(fileName, ".");
                    fileName= ime[0]+ ".xlsx";   
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
                         case "selectFakturi.xlsx":
                             PrikaziFakturi(fileName);
                             break;
                         case "KompaniiVnesi.xlsx":
                             PrikazigiVoComboBox(fileName);
                             break;
                        case "selectProizvodiWhere.xlsx":
                             PrikazigiSitePodatociVoListview(fileName);
                            break;
                         default:
                             PrikazigiSitePodatociVoListview(fileName);
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

        public MenadzerVnesiNovProizvod()
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

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Шифра на производ", 200);// име на пијачка
            listView1.Columns.Add("Име на производ",200);// име на пијачка
            listView1.Columns.Add("Тип на производ", 200);// тип на производот
            listView1.Columns.Add("Количина на производ", 200);
            listView1.Columns.Add("Продажна цена на производ", 200);
            listView1.Columns.Add("Име на компанијата", 200);
            listView1.Columns.Add("Статус на производот", 200);

            lvFakturi.View = View.Details;
            lvFakturi.GridLines = true;
            lvFakturi.FullRowSelect = true;
            lvFakturi.Columns.Add("Број на фактура", 200);
            lvFakturi.Columns.Add("Датум и време на фактура", 200);
            lvFakturi.Columns.Add("Вкупна сума на фактура", 200);
            lvFakturi.Columns.Add("Корисничко име кој ја креира фактурата", 200);
            lvFakturi.Columns.Add("Име кој ја креира фактурата", 200);
            lvFakturi.Columns.Add("Презиме кој ја креира фактурата", 200);
            lvFakturi.Columns.Add("Позицијата кој ја креира фактурата", 200);
            lvFakturi.Columns.Add("Име на компанијата", 200);
            lvFakturi.Columns.Add("Трансакциска сметка", 200);
            lvFakturi.Columns.Add("Статус на фактурата", 200);
            lvFakturi.Columns.Add("Забелешка за фактуратаа", 200);

            Komunikacija objKomunikacija = new Komunikacija();
            string poraka = "selectProizvodi#"+port;
            objKomunikacija.PorakaZaServer(poraka);

            string porakaFakturi = "selectFakturi#"+port;
            objKomunikacija.PorakaZaServer(porakaFakturi);

            string porakaKompanii = "selectKompaniiAktivna#"+port;
            objKomunikacija.PorakaZaServer(porakaKompanii);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbVnesiSifra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnVnesiNabavka_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbVnesiSifra.Text != "" && tbVnesiIme.Text != "" && cbVnesiTip.Text != "" && tbVnesiKolicina.Text != ""  && tbVnesiCena.Text != "" && cbVnesiKompanija.SelectedValue.ToString() != "")
                {
                    Komunikacija objKomunikacija = new Komunikacija();
                    string poraka = "insertProizvodi#" + tbVnesiSifra.Text + "#" + tbVnesiIme.Text + "#" + cbVnesiTip.Text + "#" + tbVnesiKolicina.Text + "#" + tbVnesiCena.Text + "#" + cbVnesiKompanija.SelectedValue.ToString() + "#" + port;
                    objKomunikacija.PorakaZaServer(poraka);
                }
                else
                {
                    MessageBox.Show("Сите полиња се задолжителни !!!");
                }
            }
            catch
            {
                MessageBox.Show("Има проблем со внесувањето на производ !!!");
            }
         
        }

        private void tbVnesiKolicina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void MenadzerVnesiNovProizvod_Load(object sender, EventArgs e)
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

        public void PrikaziFakturi(string fileName)
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

            lvFakturi.Items.Clear();

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                lvFakturi.Invoke((MethodInvoker)delegate
                {
                    ListViewItem itm;
                    itm = new ListViewItem(strArray);
                    lvFakturi.Items.Add(itm);
                });
            }
        }
        public void PrikazigiVoComboBox(string fileName)
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


            cbPrebarajPoKompanija.Items.Clear();
            cbVnesiKompanija.Items.Clear();

            System.Data.DataTable comboData = new System.Data.DataTable();
            comboData.Columns.Add("id_kompanija");
            comboData.Columns.Add("ime_kompanija");

            System.Data.DataTable comboDataKompanija = new System.Data.DataTable();
            comboDataKompanija.Columns.Add("id_kompanija");
            comboDataKompanija.Columns.Add("ime_kompanija");

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), "B" + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                comboDataKompanija.Rows.Add(strArray[0], strArray[1]); //polnam za vo combo box so da izlezi kaj vnesi nov proizvod
                comboData.Rows.Add(strArray[0], strArray[1]); //polnam za vo combo box so da izlezi kaj vnesi prebaraj proizvod

            }

            cbPrebarajPoKompanija.DataSource = comboData;
            cbPrebarajPoKompanija.DisplayMember = "ime_kompanija";
            cbPrebarajPoKompanija.ValueMember = "id_kompanija";

            cbVnesiKompanija.DataSource = comboDataKompanija;
            cbVnesiKompanija.DisplayMember = "ime_kompanija";
            cbVnesiKompanija.ValueMember = "id_kompanija";
        }

        private void cbVnesiKompanija_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void btnIzbrisiNabavka_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Komunikacija objKomunikacija = new Komunikacija();
                ListViewItem selectedItem = listView1.SelectedItems[0];
                if (selectedItem.SubItems[0].Text != "")
                {
                    string poraka = "updateStatusProizvodi#" + selectedItem.SubItems[0].Text + "#" + port;
                    objKomunikacija.PorakaZaServer(poraka);
                }
                else
                {
                    MessageBox.Show("Ве молам изберете од листата кој прозвод да го избришете од листата!!");
                }
            }
        }

        private void tbPromeniIme_DoubleClick(object sender, EventArgs e)
        {

        }

        private void MenadzerVnesiNovProizvod_KeyPress(object sender, KeyPressEventArgs e)
        {

        }



        private void tbPromeniKolicina_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbPromeniSifra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbPromeniCena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                tbPromeniSifra.Text = selectedItem.SubItems[0].Text;
                tbPromeniIme.Text = selectedItem.SubItems[1].Text;
                cbPromeniTip.Text = selectedItem.SubItems[2].Text;
                tbPromeniKolicina.Text = selectedItem.SubItems[3].Text;
                tbPromeniCena.Text = selectedItem.SubItems[4].Text;
                statusUpd.Text= selectedItem.SubItems[6].Text;  
            }
        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            if (tbPromeniSifra.Text != "" && tbPromeniIme.Text != "" && cbPromeniTip.Text != "" && tbPromeniKolicina.Text != "" && tbPromeniCena.Text != "" && statusUpd.Text != "")
            {
             Komunikacija objKomunikacija = new Komunikacija();
             string poraka = "updateProizvodi#"+ tbPromeniSifra.Text + "#" + tbPromeniIme.Text + "#" + cbPromeniTip.Text + "#" + tbPromeniKolicina.Text + "#" + tbPromeniCena.Text+"#"+port+"#"+statusUpd.Text;
             objKomunikacija.PorakaZaServer(poraka);
             tbPromeniSifra.Text = ""; tbPromeniIme.Text = ""; cbPromeniTip.Text = ""; tbPromeniKolicina.Text = ""; tbPromeniCena.Text = "";
            }
            else
            {
                MessageBox.Show("Сите полиња се задолжителни !!!");
            }
        }

        private void btnPonistiFak_Click(object sender, EventArgs e)
        {
            if(lvFakturi.SelectedItems.Count > 0)
            {
                Komunikacija objKomunikacija = new Komunikacija();
                ListViewItem selectedItem = lvFakturi.SelectedItems[0];
                if (selectedItem.SubItems[0].Text != "")
                {
                    string poraka = "updateFakturi#" + selectedItem.SubItems[0].Text + "#" + port;
                    objKomunikacija.PorakaZaServer(poraka);
                }
                else
                {
                    MessageBox.Show("Ве молам изберете од листата кој прозвод да го избришете од листата!!");
                }
            }
            else
            {
                MessageBox.Show("Ве молам изберете од листата на фактури");
            }
        }

        static async Task OpenPdfAsync(string filePath)
        {
            try
            {
                // Use the default PDF viewer to open the PDF file
                using ( Process process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    };

                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void OpenPdf(string filePath)
        {
            try
            {
                // Use the default PDF viewer to open the PDF file
                using (Process process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    };

                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private void lvFakturi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem selectedItem = lvFakturi.SelectedItems[0];              
                string pdfFilePath = "C:\\Users\\Vladimir Piki\\mikrosamProekti\\Project\\CafeManagementServer\\CafeManagementServer\\fakturi\\" + "broj_na_faktura-" + selectedItem.SubItems[0].Text+".pdf";
                // Run the OpenPdfAsync method on a separate STA thread
                var thread = new Thread(() => OpenPdf(pdfFilePath));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
       

        }

        private void tbPrebrajPoSifra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnPrebaraj_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> koloni = new List<string>();

                if (tbPrebrajPoSifra.Text != "" && cbSifra.Checked)
                {
                    koloni.Add("sifra_proizvodi=" + tbPrebrajPoSifra.Text);
                }
                if (tbPrebarajIme.Text != "" && cbIme.Checked)
                {
                    koloni.Add("ime_proizvodi='" + tbPrebarajIme.Text + "'");
                }
                if (cbPrebarajTip.Text != "" && cbTip.Checked)
                {
                    koloni.Add("tip_proizvodi='" + cbPrebarajTip.Text + "'");
                }
                if (cbPrebarajPoKompanija.Text != "" && cbKompanija.Checked)
                {
                    koloni.Add("kompanija_proizvodi_id=" + cbPrebarajPoKompanija.SelectedValue.ToString());
                }

                string where = " WHERE ";
                for (int i = 0; i < koloni.Count; i++)
                {

                    if (i < koloni.Count - 1)
                    {
                        where = where + koloni[i] + " AND ";

                    }
                    else
                    {
                        where = where + koloni[i];
                    }
                }

                Komunikacija objKomunikacija = new Komunikacija();
                string poraka = "selectProizvodiWhere#"+where+"#"+port;
                objKomunikacija.PorakaZaServer(poraka);

            }
            catch
            {
                MessageBox.Show("Има проблем со пребарувањето на производите !!!");
            }
        }

        private void cbSifra_CheckedChanged(object sender, EventArgs e)
        {

            if (cbSifra.Checked)
            {
                tbPrebrajPoSifra.Visible = true;
            }
            else
            {
                tbPrebrajPoSifra.Visible = false;
                tbPrebrajPoSifra.Text = "";
            }
        }

        private void cbIme_CheckedChanged(object sender, EventArgs e)
        {

            if (cbIme.Checked)
            {
                tbPrebarajIme.Visible = true;
            }
            else
            {
                tbPrebarajIme.Visible = false;
                tbPrebarajIme.Text = "";
            }
        }

        private void cbTip_CheckedChanged(object sender, EventArgs e)
        {

            if (cbTip.Checked)
            {
                cbPrebarajTip.Visible = true;
            }
            else
            {
                cbPrebarajTip.Visible = false;
                cbPrebarajTip.Text = "";
            }
        }

        private void cbKompanija_CheckedChanged(object sender, EventArgs e)
        {

            if (cbKompanija.Checked)
            {
                cbPrebarajPoKompanija.Visible = true;
            }
            else
            {
                cbPrebarajPoKompanija.Visible = false;
                cbPrebarajPoKompanija.Text = "";
            }
        }

        private void cbPromeniTip_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvFakturi_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                string poraka = "selectProizvodi#" + port;
                objKomunikacija.PorakaZaServer(poraka);

                string porakaFakturi = "selectFakturi#" + port;
                objKomunikacija.PorakaZaServer(porakaFakturi);

                string porakaKompanii = "selectKompaniiAktivna#" + port;
                objKomunikacija.PorakaZaServer(porakaKompanii);
            }
            catch
            {
                MessageBox.Show("Има проблем со прикажувањето нарачките !!!");
            }
        }
    }
}
