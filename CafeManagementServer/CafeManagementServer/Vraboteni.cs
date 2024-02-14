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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using BCrypt.Net;

namespace CafeManagementServer
{
    public partial class Vraboteni : Form
    {
        public Vraboteni()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Корисничко име", 200);
            listView1.Columns.Add("Име на вработен", 200);
            listView1.Columns.Add("Презиме на вработен", 200);
            listView1.Columns.Add("Датум на почеток на работа", 200);
            listView1.Columns.Add("Позиција", 200);
            listView1.Columns.Add("Плата", 200);
            listView1.Columns.Add("Договор", 200);
            listView1.Columns.Add("Трансакциска сметка", 200);

            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string imnjaKoloni = "korisnicko_ime,ime,prezime,datum_pocetok_rabota,pozicija,plata_vraboten,dogovor_vraboten,transakciska_smetka_vraboten";
            string tableName = "Vraboteni";
            SqlDataReader sqlite_datareader = objSql.SelectFields(imnjaKoloni, tableName);
            while (sqlite_datareader.Read())
            {
                string[] arr = new string[8];
                ListViewItem itm;

                arr[0] = sqlite_datareader.GetValue(0).ToString();
                arr[1] = sqlite_datareader.GetValue(1).ToString();
                arr[2] = sqlite_datareader.GetValue(2).ToString();
                arr[3] = sqlite_datareader.GetDateTime(3).ToString("yyyy-MM-dd");
                arr[4] = sqlite_datareader.GetValue(4).ToString();
                arr[5] = sqlite_datareader.GetValue(5).ToString();
                arr[6] = sqlite_datareader.GetValue(6).ToString();
                arr[7] = sqlite_datareader.GetValue(7).ToString();

                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);

            }
            objSql.CloseConnection();
        }

        private void btnNovVraboten_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIzbrisiVraboten_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                if (selectedItem.SubItems[0].Text != "")
                {
                    string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                    SQLManager objSql = new SQLManager(connectionString);
                    string imnjaKoloni = "korisnicko_ime,ime,prezime,datum_pocetok_rabota,pozicija,plata_vraboten,dogovor_vraboten,transakciska_smetka_vraboten";
                    string tableName = "Vraboteni";
                    string uslov = "korisnicko_ime = '" + selectedItem.SubItems[0].Text + "'";
                    objSql.Delete(tableName, uslov);
                    listView1.Items.Clear();

                    SqlDataReader sqlite_datareader = objSql.SelectFields(imnjaKoloni, tableName);
                    while (sqlite_datareader.Read())
                    {
                        string[] arr = new string[8];
                        ListViewItem itm;

                        arr[0] = sqlite_datareader.GetValue(0).ToString();
                        arr[1] = sqlite_datareader.GetValue(1).ToString();
                        arr[2] = sqlite_datareader.GetValue(2).ToString();
                        arr[3] = sqlite_datareader.GetDateTime(3).ToString("yyyy-MM-dd");
                        arr[4] = sqlite_datareader.GetValue(4).ToString();
                        arr[5] = sqlite_datareader.GetValue(5).ToString();
                        arr[6] = sqlite_datareader.GetValue(6).ToString();
                        arr[7] = sqlite_datareader.GetValue(7).ToString();

                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);

                    }
                    objSql.CloseConnection();
                }
                else
                {
                    MessageBox.Show("Ве молам изберете од листата вработен кој сакате да го избришите !!!");
                }
            }
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            if (korisnickoImeUpdate.Text != "" && imeVrabotenUpdate.Text != "" && prezimeVrabotenUpdate.Text != "" && datumVrabotenUpdate.Text != "" && pozicijaUpdate.Text != "" && plataUpdate.Text != "" && dogovorUpdate.Text !="" && transakciskaUpdate.Text != "")
            {

                DateTime date = DateTime.Parse(datumVrabotenUpdate.Text);
                string datum = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
                if (imeVrabotenUpdate.Text.Length > 2 && prezimeVrabotenUpdate.Text.Length >2)
                {
                    string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                    SQLManager objSql = new SQLManager(connectionString);
                    string imnjaKoloni = "korisnicko_ime,ime,prezime,datum_pocetok_rabota,pozicija,plata_vraboten,dogovor_vraboten,transakciska_smetka_vraboten";
                    string tableName = "Vraboteni";
                    string koloni = "ime='" + imeVrabotenUpdate.Text + "', prezime='" + prezimeVrabotenUpdate.Text + "', datum_pocetok_rabota='" + datum + "', pozicija='" + pozicijaUpdate.Text + "', plata_vraboten='" + plataUpdate.Text + "', dogovor_vraboten='" + dogovorUpdate.Text + "', transakciska_smetka_vraboten='"+transakciskaUpdate.Text+"'";
                    string uslov = "korisnicko_ime = '" + korisnickoImeUpdate.Text + "'";
                    if (lozinkaCheckUpdate.Checked == true)
                    {
                        if(lozinkaUpdate.Text.Length > 3)
                        {
                            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(lozinkaUpdate.Text);
                            string dodajLozinka = ", lozinka='" + hashedPassword + "'";
                            objSql.Update(tableName, koloni+ dodajLozinka, uslov);
                        }
                        else
                        {
                            MessageBox.Show("Лозинката мора да содржи над 3 карактери !!!");
                        }

                    }
                    else
                    {
                        objSql.Update(tableName, koloni, uslov);
                    }

                    listView1.Items.Clear();

                    SqlDataReader sqlite_datareader = objSql.SelectFields(imnjaKoloni, tableName);
                    while (sqlite_datareader.Read())
                    {
                        string[] arr = new string[8];
                        ListViewItem itm;

                        arr[0] = sqlite_datareader.GetValue(0).ToString();
                        arr[1] = sqlite_datareader.GetValue(1).ToString();
                        arr[2] = sqlite_datareader.GetValue(2).ToString();
                        arr[3] = sqlite_datareader.GetDateTime(3).ToString("yyyy-MM-dd");
                        arr[4] = sqlite_datareader.GetValue(4).ToString();
                        arr[5] = sqlite_datareader.GetValue(5).ToString();
                        arr[6] = sqlite_datareader.GetValue(6).ToString();
                        arr[7] = sqlite_datareader.GetValue(7).ToString();

                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);

                    }
                    objSql.CloseConnection();
                    imeVrabotenUpdate.Clear();
                    prezimeVrabotenUpdate.Clear();
                    plataUpdate.Clear();
                    transakciskaUpdate.Clear();
                }
                else
                {
                    MessageBox.Show("Име и презимето мораат да содржат над 3 карактери !!!");
                }
               
            }
            else
            {
                MessageBox.Show("Сите полиња се задолжителни !!!");
            }
        }

        private void plataUpdate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                korisnickoImeUpdate.Text = selectedItem.SubItems[0].Text;
                imeVrabotenUpdate.Text = selectedItem.SubItems[1].Text;
                prezimeVrabotenUpdate.Text = selectedItem.SubItems[2].Text;
                datumVrabotenUpdate.Text = selectedItem.SubItems[3].Text;
                pozicijaUpdate.Text = selectedItem.SubItems[4].Text;
                plataUpdate.Text = selectedItem.SubItems[5].Text;
                dogovorUpdate.Text = selectedItem.SubItems[6].Text;
                transakciskaUpdate.Text= selectedItem.SubItems[7].Text; 
            }
            else
            {
                MessageBox.Show("Ве молам изберете од листата со која компанија сакате да промените вредност !!!");
            }
        }

        private void lozinkaCheckUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (lozinkaCheckUpdate.Checked)
            {
      
                lozinkaUpdate.Visible = true;
            }
            else
            {
                lozinkaUpdate.Visible = false;
            }
        }

        private void btnVnesi_Click(object sender, EventArgs e)
        {
            if (tbIme.Text != "" && tbPrezime.Text != "" && cbPozicija.Text != "" && tbKorisnickoIme.Text != "" && tbLozinka.Text != "" && tbPlata.Text != "" && cbDogovor.Text != "" && tbTransakciska.Text != "")
            {
                if (tbKorisnickoIme.Text.Length > 3 && tbLozinka.Text.Length > 3)
                {
                    int plata = 0;
                    bool daliEbroj = Int32.TryParse(tbPlata.Text, out plata);
                    if (daliEbroj)
                    {
                        try
                        {
                            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(tbLozinka.Text);
                            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                            SQLManager objSql = new SQLManager(connectionString);
                            objSql.InsertRowVraboteni(tbKorisnickoIme.Text, hashedPassword, tbIme.Text, tbPrezime.Text, cbPozicija.Text, plata, cbDogovor.Text, tbTransakciska.Text);

                            listView1.Items.Clear();
                            string imnjaKoloni = "korisnicko_ime,ime,prezime,datum_pocetok_rabota,pozicija,plata_vraboten,dogovor_vraboten,transakciska_smetka_vraboten";
                            string tableName = "Vraboteni";
                            SqlDataReader sqlite_datareader = objSql.SelectFields(imnjaKoloni, tableName);
                            while (sqlite_datareader.Read())
                            {
                                string[] arr = new string[8];
                                ListViewItem itm;

                                arr[0] = sqlite_datareader.GetValue(0).ToString();
                                arr[1] = sqlite_datareader.GetValue(1).ToString();
                                arr[2] = sqlite_datareader.GetValue(2).ToString();
                                arr[3] = sqlite_datareader.GetDateTime(3).ToString("yyyy-MM-dd");
                                arr[4] = sqlite_datareader.GetValue(4).ToString();
                                arr[5] = sqlite_datareader.GetValue(5).ToString();
                                arr[6] = sqlite_datareader.GetValue(6).ToString();
                                arr[7] = sqlite_datareader.GetValue(7).ToString();

                                itm = new ListViewItem(arr);
                                listView1.Items.Add(itm);
                            }
                            objSql.CloseConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Има проблем со внесувањето нов вработен !!!");
                        }
                        tbIme.Clear();
                        tbPrezime.Clear();
                        tbKorisnickoIme.Clear();
                        tbLozinka.Clear();
                        tbPlata.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Дозволени се само бројки. Ако не зема плата ставете 0 !!!!");
                    }

                }
                else
                {
                    MessageBox.Show("Корисничкото име и лозинка мораат да содржат над 3 карактери !!!");
                }

            }
            else
            {
                MessageBox.Show("Сите полиња се задолжителни !!!");
            }
        }

        private void tbPlata_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string imnjaKoloni = "korisnicko_ime,ime,prezime,datum_pocetok_rabota,pozicija,plata_vraboten,dogovor_vraboten,transakciska_smetka_vraboten";
            string tableName = "Vraboteni";
            SqlDataReader sqlite_datareader = objSql.SelectFields(imnjaKoloni, tableName);
            while (sqlite_datareader.Read())
            {
                string[] arr = new string[8];
                ListViewItem itm;

                arr[0] = sqlite_datareader.GetValue(0).ToString();
                arr[1] = sqlite_datareader.GetValue(1).ToString();
                arr[2] = sqlite_datareader.GetValue(2).ToString();
                arr[3] = sqlite_datareader.GetDateTime(3).ToString("yyyy-MM-dd");
                arr[4] = sqlite_datareader.GetValue(4).ToString();
                arr[5] = sqlite_datareader.GetValue(5).ToString();
                arr[6] = sqlite_datareader.GetValue(6).ToString();
                arr[7] = sqlite_datareader.GetValue(7).ToString();

                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);

            }
            objSql.CloseConnection();
        }

        private void Vraboteni_Load(object sender, EventArgs e)
        {

        }

        private void tbTransakciska_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbIme_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
