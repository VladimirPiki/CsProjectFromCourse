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
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Math;


namespace CafeManagement
{
    public partial class Kelner : Form
    {
        private Excel.Application ExcelObj = null;
        public int port = 1234;

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

        public Kelner()
        {
            InitializeComponent();

            /////thread za Excel file
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

            lvProizvodi.View = View.Details;
            lvProizvodi.GridLines = true;
            lvProizvodi.FullRowSelect = true;
            lvProizvodi.Columns.Add("Шифра на производ", 200);
            lvProizvodi.Columns.Add("Име на производ", 200);
            lvProizvodi.Columns.Add("Тип на производ", 200);
            lvProizvodi.Columns.Add("Количина на производ", 200);
            lvProizvodi.Columns.Add("Цена на производ", 200);
            lvProizvodi.Columns.Add("Име на компанијата", 200);


            lvPoracki.View = View.Details;
            lvPoracki.GridLines = true;
            lvPoracki.FullRowSelect = true;
            lvPoracki.Columns.Add("Корисничко име на келнер", 200);
            lvPoracki.Columns.Add("Шифра на производ", 200);
            lvPoracki.Columns.Add("Име на производ", 200);
            lvPoracki.Columns.Add("Количина на производот", 200);
            lvPoracki.Columns.Add("Цена на производ", 200);
            lvPoracki.Columns.Add("Вкупна цена", 200);

            Komunikacija objKomunikacija = new Komunikacija();
            string poraka = "selectProizvodiAktivni#" + port;
            objKomunikacija.PorakaZaServer(poraka);
        } 

        private void Kelner_FormClosing(object sender, FormClosingEventArgs e)
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

        private void lvPoracki_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvProizvodi_DoubleClick(object sender, EventArgs e)
        {
            if (lvProizvodi.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvProizvodi.SelectedItems[0];
                tbSifra.Text = selectedItem.SubItems[0].Text;
            }
        }

        private void lvPoracki_DoubleClick(object sender, EventArgs e)
        {

        }

        private void tbSifra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbKolicina_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbIzbrisiPoracka_Click(object sender, EventArgs e)
        {
            if(lvPoracki.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in lvPoracki.SelectedItems)
                {
                    lvPoracki.Items.Remove(selectedItem);
                }
            }
        }

        private void tbVnesiPoracka_Click(object sender, EventArgs e)
        {

        }

        private void tbVnesiPoracka_Click_1(object sender, EventArgs e)
        {
         
            if (tbSifra.Text !="" && tbKolicina.Text != "")
            {
                try
                {
                    string imeNaProizvod = "";
                    string cenaNaProizvod = "";
                    foreach (ListViewItem item in lvProizvodi.Items)
                    {
                        string sifraOdProizvodi = item.SubItems[0].Text;
                        if (sifraOdProizvodi == tbSifra.Text)
                        {
                            imeNaProizvod = item.SubItems[1].Text;
                            cenaNaProizvod = item.SubItems[4].Text;
                        }
                    }
                    foreach (ListViewItem item in lvPoracki.Items)
                    {
                        string sifraOdProizvodi = item.SubItems[1].Text;
                        if (sifraOdProizvodi == tbSifra.Text)
                        {
                            int kolicina = Int32.Parse(item.SubItems[3].Text);
                            int kolicinaVnes = Int32.Parse(tbKolicina.Text);

                            int cena = Int32.Parse(item.SubItems[4].Text);
                            int vkupnaKolicina = kolicina + kolicinaVnes;
                            int vkupnaCena = vkupnaKolicina * cena;
                            item.SubItems[3].Text = (vkupnaKolicina).ToString();
                            item.SubItems[4].Text = cenaNaProizvod;
                            item.SubItems[5].Text = vkupnaCena.ToString();

                            tbKolicina.Clear();
                            tbSifra.Clear();
                            return;
                        }
                    }

                    int cenaNaProizvodInt = Int32.Parse(cenaNaProizvod);
                    int kolicinaProizvodInt = Int32.Parse(tbKolicina.Text);
                    int vkupnaCenaProizvod = cenaNaProizvodInt * kolicinaProizvodInt;

                    string[] arr = new string[6];
                    ListViewItem itm;
                    arr[0] = Form1.korisnikIme;
                    arr[1] = tbSifra.Text;
                    arr[2] = imeNaProizvod;
                    arr[3] = tbKolicina.Text;
                    arr[4] = cenaNaProizvod;
                    arr[5] = vkupnaCenaProizvod.ToString();
                    itm = new ListViewItem(arr);
                    lvPoracki.Items.Add(itm);

                    tbKolicina.Clear();
                    tbSifra.Clear();    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Внесувате погрешна шифра !!!");
                }
            }
            else
            {
                MessageBox.Show("Задолжително внесете внесете производ и количина !!!");
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
            lvProizvodi.Items.Clear();

            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                lvProizvodi.Invoke((MethodInvoker)delegate
                {
                    ListViewItem itm;
                    itm = new ListViewItem(strArray);
                    lvProizvodi.Items.Add(itm);
                });
            }
        }

        private void lvProizvodi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbIspratiPoracka_Click(object sender, EventArgs e)
        {
            try
            {
                string sifra = "";
                string kolicinaProdaeni = "";
                string cena = "";
                string cenaVkupno = "";
                int promet = 0;
                DateTime dateTime = DateTime.Now;
                string vremePoracka = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                int itemZbir = lvPoracki.Items.Count;

                for (int i = 0; i < itemZbir; i++)
                {
                    ListViewItem item = lvPoracki.Items[i];
                    if (i < itemZbir - 1)
                    {
                        sifra += item.SubItems[1].Text + "-";
                        kolicinaProdaeni += item.SubItems[3].Text + "-";
                        cena += item.SubItems[4].Text + "-";
                        cenaVkupno += item.SubItems[5].Text + "-";
                    }
                    else
                    {
                        sifra += item.SubItems[1].Text;
                        kolicinaProdaeni += item.SubItems[3].Text;
                        cena += item.SubItems[4].Text;
                        cenaVkupno += item.SubItems[5].Text;
                    }

                    int cenaVkp = Int32.Parse(item.SubItems[5].Text);
                    promet += cenaVkp;
                  
                }
                lvPoracki.Items.Add(dateTime.ToString());
                Komunikacija objKomunikacija = new Komunikacija();
                Assets objAssets = new Assets();
                string poraka = "insertNaracki#" + Form1.korisnikIme + "#" + vremePoracka + "#" + sifra + "#" + kolicinaProdaeni + "#" + cena + "#" + cenaVkupno + "#" + promet;
                objKomunikacija.PorakaZaServer(poraka);
                string exportPath = "";
                exportPath = objAssets.NapraviExcelOdListView(exportPath, lvPoracki, "InsertNarackiSank");
                if (exportPath != "")
                {
                    objKomunikacija.IspratiExcel(exportPath);
                }
                lvPoracki.Items.Clear();
            }
            catch
            {
                MessageBox.Show("Има проблем со внесувањето на порачката !!!");
            }
        }

        private void btnSiteNaracki_Click(object sender, EventArgs e)
        {
            KelnerSiteNaracki objKelnerSiteNaracki = new KelnerSiteNaracki();
            objKelnerSiteNaracki.ShowDialog();
        }

        private void Kelner_Load(object sender, EventArgs e)
        {

        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            /////thread za Excel file
            Thread threadExcel = new Thread(t =>
            {
                ThreadProcExcel();
            })
            {
                IsBackground = true
            };
            threadExcel.Start();

            Komunikacija objKomunikacija = new Komunikacija();
            string poraka = "selectProizvodiAktivni#" + port;
            objKomunikacija.PorakaZaServer(poraka);
        }

        private void btnPecatiFiskalna_Click(object sender, EventArgs e)
        {
            if(lvPoracki.Items.Count > 0)
            {
                try
                {
                    Assets objAssets= new Assets(); 

                    DateTime dateTime = DateTime.Now;
                    string vreme = dateTime.ToString("yyyy-MM-dd HH-mm-ss");
                    string vremeFiskalna = dateTime.ToString("yyyy-MMMM-dd HH:mm:ss");

                    string fiskalna = "Кафе Владимир/Христијан\n";
                    fiskalna += "----------------------------------------------------------------\n"; 
                   
                    int itemPoracki = lvPoracki.Items.Count;
                    int itemProizvodi = lvProizvodi.Items.Count;
                    int promet = 0;
                    for (int i = 0; i < itemPoracki; i++)
                    {
                        ListViewItem item = lvPoracki.Items[i];

                        fiskalna += item.SubItems[2].Text+"    "+ item.SubItems[3].Text+" x "+ item.SubItems[4].Text+"      "+ item.SubItems[5].Text+"\n";

                        int cenaVkp = Int32.Parse(item.SubItems[5].Text);
                        promet += cenaVkp;
                    }
                    double ddv = objAssets.PremsetajDanok(promet, 18);
                    fiskalna += "----------------------------------------------------------------\n";
                    fiskalna += "ВКУПЕН  ПРОМЕТ                 " + promet+"\n";
                    fiskalna += "ВКУПЕНО ДДВ                    " + ddv +"\n";
                    fiskalna += "----------------------------------------------------------------\n";
                    fiskalna += "Корисничко име:                " + Form1.korisnikIme + "\n";
                    fiskalna += "Датум и време: " + vremeFiskalna + "\n";
                    objAssets.KreirajWordDokument(vreme, fiskalna);
                }
                catch
                {
                    MessageBox.Show("Не испечативте фискална сметка !!!");
                }
            }
            else
            {
                MessageBox.Show("Внесете порачка за да можите да печатите !!!");
            }
        
        }


    }
}
