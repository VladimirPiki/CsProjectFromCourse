using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CafeManagementServer.Database;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace CafeManagementServer
{
    public partial class Nabavka : Form
    {
        public Nabavka()
        {
            InitializeComponent();

            lvKompanii.View = View.Details;
            lvKompanii.GridLines = true;
            lvKompanii.FullRowSelect = true;
            lvKompanii.Columns.Add("Ид на компанијата", 200);
            lvKompanii.Columns.Add("Име на компанијата", 200);
            lvKompanii.Columns.Add("Трансакциска сметка", 200);
            lvKompanii.Columns.Add("Датум на склучување на договор", 200);
            lvKompanii.Columns.Add("Соработка", 200);

            lvNabavka.View = View.Details;
            lvNabavka.GridLines = true;
            lvNabavka.FullRowSelect = true;
            lvNabavka.Columns.Add("Име на производ", 100);
            lvNabavka.Columns.Add("Набавна цена на производ", 100);
            lvNabavka.Columns.Add("Количина на производ", 100);
            lvNabavka.Columns.Add("Вкупна цена", 100);

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

            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string tableName = "Kompanii  WHERE status='aktivna' ";
            SqlDataReader sqlite_datareader = objSql.SelectFrom(tableName);
            DataTable comboData = new DataTable();
            comboData.Columns.Add("id_kompanija");
            comboData.Columns.Add("ime_kompanija");
            comboData.Columns.Add("transakciska_smetka_kompanija");
            lvKompanii.Items.Clear();
            while (sqlite_datareader.Read())
            {
                string[] arr = new string[5];
                ListViewItem itm;

                arr[0] = sqlite_datareader.GetValue(0).ToString();
                arr[1] = sqlite_datareader.GetValue(1).ToString();
                arr[2] = sqlite_datareader.GetValue(2).ToString();
                arr[3] = sqlite_datareader.GetDateTime(3).ToString("yyyy-MM-dd");
                arr[4] = sqlite_datareader.GetValue(4).ToString();

                itm = new ListViewItem(arr);
                lvKompanii.Items.Add(itm);

                comboData.Rows.Add(sqlite_datareader.GetValue(0).ToString(), sqlite_datareader.GetValue(1).ToString(), sqlite_datareader.GetValue(2).ToString());
            }

            kompanii.DataSource = comboData;
            kompanii.DisplayMember = "ime_kompanija";
            kompanii.ValueMember = "id_kompanija";
            objSql.CloseConnection();

            string imnjaKoloni = "id_fakturi,datum_fakturi,vkupna_suma,korisnicko_ime,ime,prezime,pozicija,ime_kompanija,transakciska_smetka,status_fakturi,zabelshka_fakturi";
            string tableNameFakturi = "Fakturi INNER JOIN Vraboteni on Fakturi.korisnicko_ime_fakturi=Vraboteni.korisnicko_ime INNER JOIN Kompanii ON Fakturi.id_kompanija_fakturi=Kompanii.id_kompanija WHERE Kompanii.status='aktivna'  order by id_fakturi desc";
            lvFakturi.Items.Clear();
            SqlDataReader sqlite_datareader_fakturi = objSql.SelectFields(imnjaKoloni, tableNameFakturi);
            while (sqlite_datareader_fakturi.Read())
            {
                string[] arr = new string[11];
                ListViewItem itm;

                arr[0] = sqlite_datareader_fakturi.GetValue(0).ToString();
                arr[1] = sqlite_datareader_fakturi.GetValue(1).ToString();
                arr[2] = sqlite_datareader_fakturi.GetValue(2).ToString();
                arr[3] = sqlite_datareader_fakturi.GetValue(3).ToString();
                arr[4] = sqlite_datareader_fakturi.GetValue(4).ToString();
                arr[5] = sqlite_datareader_fakturi.GetValue(5).ToString();
                arr[6] = sqlite_datareader_fakturi.GetValue(6).ToString();
                arr[7] = sqlite_datareader_fakturi.GetValue(7).ToString();
                arr[8] = sqlite_datareader_fakturi.GetValue(8).ToString();
                arr[9] = sqlite_datareader_fakturi.GetValue(9).ToString();
                arr[10] = sqlite_datareader_fakturi.GetValue(10).ToString();

                itm = new ListViewItem(arr);
                lvFakturi.Items.Add(itm);

            }
            objSql.CloseConnection();
        }

        private void cenaProizovod_KeyPress(object sender, KeyPressEventArgs e)
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

        private void kolicinaProizvod_KeyPress(object sender, KeyPressEventArgs e)
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

        private void kompanii_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView selectedDataRow = (DataRowView)kompanii.SelectedItem;
            transakciskaSmetka.Text = selectedDataRow["transakciska_smetka_kompanija"].ToString();
            kompnijaId.Text = selectedDataRow["id_kompanija"].ToString();
            kompanijName.Text = selectedDataRow["ime_kompanija"].ToString();
        }

        private void btnSendNabavka_Click(object sender, EventArgs e)
        {
            if(kompanii.SelectedValue.ToString() != "" && imeProizvod.Text !="" && cenaProizovod.Text != "" && kolicinaProizvod.Text !="")
            {
                int cena, kolicina, vkupno;
                cena= Int32.Parse(cenaProizovod.Text);
                kolicina= Int32.Parse(kolicinaProizvod.Text);
                vkupno = cena * kolicina;
                string[] arr = new string[4];
                ListViewItem itm;

                arr[0] = imeProizvod.Text;
                arr[1] = cenaProizovod.Text;
                arr[2] = kolicinaProizvod.Text;
                arr[3] = vkupno.ToString();


                itm = new ListViewItem(arr);
                lvNabavka.Items.Add(itm);
            }
            else
            {
                MessageBox.Show("Сите полиња се задолжителни !!!");
            }
        }

        private void kompanii_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void kompanii_SelectionChangeCommitted(object sender, EventArgs e)
        {
            kompanii.Visible = false;
            groupBox1.Visible = true;   
        }

        private void btnNovaKompanija_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Доколку сакате да внесите нова набавка, листата со моментални набавки ќе биде избришана ?", "Потврда за внесување набавка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                    kompanii.Visible = true;
                    imeProizvod.Clear();
                    cenaProizovod.Clear();
                    kolicinaProizvod.Clear();
                    lvNabavka.Items.Clear();
                    groupBox1.Visible = false;    
            }
        }

        private void transakciskaSmetka_Click(object sender, EventArgs e)
        {

        }

        private void btnSendFaktura_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbSlika.Text != "")
                {
                    DateTime date = DateTime.Now;
                    string vreme = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                    SQLManager objSql = new SQLManager(connectionString);


                    string poracka = "Ime na proizvod | Nabavna cena | Kolicina | Suma \n";
                    int vkupnaSuma = 0;
                    foreach (ListViewItem item in lvNabavka.Items)
                    {
                        int suma = 0;
                        suma = Int32.Parse(item.SubItems[3].Text);
                        vkupnaSuma += suma;
                        poracka += item.SubItems[0].Text + " | " + item.SubItems[1].Text + " | " + item.SubItems[2].Text + " | " + item.SubItems[3].Text + "\n";
                    }
                    poracka += "\n";

                    Insert objInsert = new Insert();
                    Update objUpdate = new Update();
                    Assets objAssets = new Assets();
                    objInsert.InsertFakturi(vreme, vkupnaSuma.ToString(), Form1.korisnikIme, kompnijaId.Text, zabeleshkaFakturi.Text);
                    objInsert.InsertOdliv(vreme, vkupnaSuma.ToString(), Form1.korisnikIme, transakciskaSmetka.Text, "Испраќање фактура на компанија " + kompanijName.Text);
                    objUpdate.UpdateBudzetOdliv(vreme, vkupnaSuma.ToString(), "Испраќање фактура на компанија " + kompanijName.Text);
                    zabeleshkaFakturi.Clear();

                    string imnjaKoloni = "id_fakturi,datum_fakturi,vkupna_suma,korisnicko_ime,ime,prezime,pozicija,ime_kompanija,transakciska_smetka,status_fakturi,zabelshka_fakturi";
                    string tableNameFakturi = "Fakturi INNER JOIN Vraboteni on Fakturi.korisnicko_ime_fakturi=Vraboteni.korisnicko_ime INNER JOIN Kompanii ON Fakturi.id_kompanija_fakturi=Kompanii.id_kompanija WHERE Kompanii.status='aktivna'  order by id_fakturi desc";
                    lvFakturi.Items.Clear();
                    SqlDataReader sqlite_datareader_fakturi = objSql.SelectFields(imnjaKoloni, tableNameFakturi);
                    while (sqlite_datareader_fakturi.Read())
                    {
                        string[] arr = new string[11];
                        ListViewItem itm;

                        arr[0] = sqlite_datareader_fakturi.GetValue(0).ToString();
                        arr[1] = sqlite_datareader_fakturi.GetValue(1).ToString();
                        arr[2] = sqlite_datareader_fakturi.GetValue(2).ToString();
                        arr[3] = sqlite_datareader_fakturi.GetValue(3).ToString();
                        arr[4] = sqlite_datareader_fakturi.GetValue(4).ToString();
                        arr[5] = sqlite_datareader_fakturi.GetValue(5).ToString();
                        arr[6] = sqlite_datareader_fakturi.GetValue(6).ToString();
                        arr[7] = sqlite_datareader_fakturi.GetValue(7).ToString();
                        arr[8] = sqlite_datareader_fakturi.GetValue(8).ToString();
                        arr[9] = sqlite_datareader_fakturi.GetValue(9).ToString();
                        arr[10] = sqlite_datareader_fakturi.GetValue(10).ToString();

                        itm = new ListViewItem(arr);
                        lvFakturi.Items.Add(itm);

                    }
                    objSql.CloseConnection();

                    string ispratnica = "                                                   FAKTURA/ISPRATNICA\n" +
                                        "                                                   KAFE VLADIMIR/HRISTIJAN\n\n";
                    string ispratil = "";
                    string brojNaFaktura = "";
                    SqlDataReader sqlite_datareader = objSql.SelectFields(imnjaKoloni, "Fakturi INNER JOIN Vraboteni on Fakturi.korisnicko_ime_fakturi=Vraboteni.korisnicko_ime INNER JOIN Kompanii ON Fakturi.id_kompanija_fakturi=Kompanii.id_kompanija WHERE Kompanii.status='aktivna' AND datum_fakturi='" + vreme + "'");
                    while (sqlite_datareader.Read())
                    {
                        brojNaFaktura += sqlite_datareader.GetValue(0);
                        ispratnica += "Isprateno do: " + sqlite_datareader.GetValue(7) + "\nTransakciska smetka : " + sqlite_datareader.GetValue(8) + "\n\n";
                        ispratnica += "Broj na faktura: " + brojNaFaktura + "\nVkupna suma: " + sqlite_datareader.GetValue(2) + "\nDatum i vreme na isprakjanje na fakturata: " + sqlite_datareader.GetValue(1) + "\n\n";
                        ispratil += "Ispratil : " + sqlite_datareader.GetValue(4) + " " + sqlite_datareader.GetValue(5);
                    }
                    objSql.CloseConnection();

                    ispratnica += poracka + ispratil;
                    string path = "C:\\Users\\Vladimir Piki\\mikrosamProekti\\Project\\CafeManagementServer\\CafeManagementServer\\fakturi\\";
                    objAssets.PdfFile(brojNaFaktura, ispratnica, tbSlika.Text, path);
                }
                else
                {
                    MessageBox.Show("Ве молам изберете слика !!!");
                }
            }
            catch {
                MessageBox.Show("Има проблем со внесувањето на фактурата");
            }

          
        }

        private void kompnijaId_Click(object sender, EventArgs e)
        {

        }

        private void btIzberiSlika_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pictureBox.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                tbSlika.Text = openFileDialog1.FileName;
            }
        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvFakturi.SelectedItems[0].Text != "")
                {
                    string imeNaPdf = lvFakturi.SelectedItems[0].SubItems[0].Text + ".pdf";
                    axAcroPDF1.src = "C:\\Users\\Vladimir Piki\\mikrosamProekti\\Project\\CafeManagementServer\\CafeManagementServer\\fakturi\\" +"broj_na_faktura-"+ imeNaPdf;
                }
            }
            catch
            {
                MessageBox.Show("Има проблем во прегледувањето на фактурата");
            }
        }

        private void lvKompanii_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Доколку сакате да внесите нова набавка, листата со моментални набавки ќе биде избришана ?", "Потврда за внесување набавка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (lvKompanii.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = lvKompanii.SelectedItems[0];
                    kompanii.Visible = false;
                    groupBox1.Visible = true;
                    kompanijName.Text = selectedItem.SubItems[1].Text;
                    transakciskaSmetka.Text = selectedItem.SubItems[2].Text;

                    imeProizvod.Clear();
                    cenaProizovod.Clear();
                    kolicinaProizvod.Clear();
                    lvNabavka.Items.Clear();
                }
            }
        }

        private void lvKompanii_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvFakturi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvFakturi_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void lvFakturi_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvFakturi.SelectedItems[0].Text != "")
                {
                    string imeNaPdf = lvFakturi.SelectedItems[0].SubItems[0].Text + ".pdf";
                    axAcroPDF1.src = "C:\\Users\\Vladimir Piki\\mikrosamProekti\\Project\\CafeManagementServer\\CafeManagementServer\\fakturi\\" + "broj_na_faktura-" + imeNaPdf;
                }
            }
            catch
            {
                MessageBox.Show("Има проблем во прегледувањето на фактурата");
            }
        }

        private void kompanii_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Nabavka_Load(object sender, EventArgs e)
        {

        }
    }
}
