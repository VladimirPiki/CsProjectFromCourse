using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CafeManagementServer.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.IO;

namespace CafeManagementServer
{
    public partial class Smetki : Form
    {
        public Smetki()
        {
            InitializeComponent();

            lvSmetki.View = View.Details;
            lvSmetki.GridLines = true;
            lvSmetki.FullRowSelect = true;
            lvSmetki.Columns.Add("Уникатен број на сметка", 200);
            lvSmetki.Columns.Add("Име на компанија на примач на сметката", 200);
            lvSmetki.Columns.Add("Тип на сметка", 200);
            lvSmetki.Columns.Add("Трансакција на сметка", 200);
            lvSmetki.Columns.Add("Забелешка за сметката", 200);

            lvPlateniSmetki.View = View.Details;
            lvPlateniSmetki.GridLines = true;
            lvPlateniSmetki.FullRowSelect = true;
            lvPlateniSmetki.Columns.Add("Број на фактура", 200);
            lvPlateniSmetki.Columns.Add("Име на компанија на примач на сметката", 200);
            lvPlateniSmetki.Columns.Add("Тип на сметка", 200);
            lvPlateniSmetki.Columns.Add("Сума на сметка", 200);
            lvPlateniSmetki.Columns.Add("Датум и време на плаќање",200);
            lvPlateniSmetki.Columns.Add("Име и презиме тој што уплатил", 200);
            lvPlateniSmetki.Columns.Add("Забелешка за сметката", 200);
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);

                DataTable comboData = new DataTable();
                comboData.Columns.Add("id_smetki");
                comboData.Columns.Add("tip_smetki");
                comboData.Columns.Add("ime_smetki");
                comboData.Columns.Add("transakciska_smetka_smetki");
                comboData.Columns.Add("zabeleshka_smetki");

                lvSmetki.Items.Clear();
                SqlDataReader sqlite_datareader_smetki = objSql.SelectFrom("Smetki");
                while (sqlite_datareader_smetki.Read())
                {
                    string[] arr = new string[5];
                    ListViewItem itm;

                    arr[0] = sqlite_datareader_smetki.GetValue(5).ToString() + "-" + sqlite_datareader_smetki.GetValue(0).ToString();
                    arr[1] = sqlite_datareader_smetki.GetValue(1).ToString();
                    arr[2] = sqlite_datareader_smetki.GetValue(2).ToString();
                    arr[3] = sqlite_datareader_smetki.GetInt64(3).ToString();
                    arr[4] = sqlite_datareader_smetki.GetValue(4).ToString();

                    itm = new ListViewItem(arr);
                    lvSmetki.Items.Add(itm);

                    comboData.Rows.Add(sqlite_datareader_smetki.GetValue(0).ToString(), $" уникатен бр: {sqlite_datareader_smetki.GetValue(0)} - {sqlite_datareader_smetki.GetValue(2)} - {sqlite_datareader_smetki.GetValue(1)} ", sqlite_datareader_smetki.GetValue(1).ToString(), sqlite_datareader_smetki.GetInt64(3).ToString(), sqlite_datareader_smetki.GetValue(4).ToString());
                }
                tipPlati.DataSource = comboData;
                tipPlati.DisplayMember = "tip_smetki";
                tipPlati.ValueMember = "id_smetki";

                tipPromeni.DataSource = comboData;
                tipPromeni.DisplayMember = "tip_smetki";
                tipPromeni.ValueMember = "id_smetki";

                imePrebaraj.DataSource = comboData;
                imePrebaraj.DisplayMember = "tip_smetki";
                imePrebaraj.ValueMember = "id_smetki";
                imePrebaraj.Visible = false;
                imePrebaraj.Text = "";
                objSql.CloseConnection();

                string koloni = "id_plateni_smetki,ime_smetki,tip_smetki,suma_plateni_smetki,datum_plateni_smetki,ime,prezime,zabeleshka_plateni_smetki,broj_smetki,slika_smetki,id_smetki";
                string tableNamePlateniSmetki = "Plateni_smetki inner join Smetki on Plateni_smetki.smetka_id=Smetki.id_smetki inner join Vraboteni on Plateni_smetki.korisnicko_ime_plateni_smetki=Vraboteni.korisnicko_ime order by datum_plateni_smetki desc";//order by date
                lvPlateniSmetki.Items.Clear();
                SqlDataReader sqlite_datareader_plateni_smetki = objSql.SelectFields(koloni, tableNamePlateniSmetki);
                while (sqlite_datareader_plateni_smetki.Read())
                {
                    string[] arr = new string[7];
                    ListViewItem itm;

                    arr[0] = sqlite_datareader_plateni_smetki.GetValue(8).ToString() + "/" + sqlite_datareader_plateni_smetki.GetValue(10).ToString() + "-" + sqlite_datareader_plateni_smetki.GetValue(0).ToString();
                    arr[1] = sqlite_datareader_plateni_smetki.GetValue(1).ToString();
                    arr[2] = sqlite_datareader_plateni_smetki.GetValue(2).ToString();
                    arr[3] = sqlite_datareader_plateni_smetki.GetValue(3).ToString();
                    arr[4] = sqlite_datareader_plateni_smetki.GetValue(4).ToString();
                    arr[5] = sqlite_datareader_plateni_smetki.GetValue(5).ToString() + " " + sqlite_datareader_plateni_smetki.GetValue(6).ToString();
                    arr[6] = sqlite_datareader_plateni_smetki.GetValue(7).ToString();

                    itm = new ListViewItem(arr);
                    lvPlateniSmetki.Items.Add(itm);

                }
                objSql.CloseConnection();

                ///Combo box za sopsvenik so ke mi treba za prebaruvanjeto
                DataTable comboDataSopstvenik = new DataTable();
                comboDataSopstvenik.Columns.Add("korisnicko_ime");
                comboDataSopstvenik.Columns.Add("ime_prezime");

                SqlDataReader sql_datareader_sopstvenik = objSql.SelectFields("korisnicko_ime,ime,prezime", "Vraboteni where pozicija='sopstvenik'");
                while (sql_datareader_sopstvenik.Read())
                {
                    comboDataSopstvenik.Rows.Add(sql_datareader_sopstvenik.GetValue(0).ToString(), $"{sql_datareader_sopstvenik.GetValue(1)} {sql_datareader_sopstvenik.GetValue(2)}"); 
                }
                sopstvenikPrebaraj.DataSource = comboDataSopstvenik;
                sopstvenikPrebaraj.DisplayMember = "ime_prezime";
                sopstvenikPrebaraj.ValueMember = "korisnicko_ime";
                sopstvenikPrebaraj.Visible = false;
                objSql.CloseConnection();
            }
            catch { MessageBox.Show("Има проблем со вчитувањето на Сметки !!!"); }  
          
        }


        private void Smetki_Load(object sender, EventArgs e)
        {

        }

        private void imePromeni_TextChanged(object sender, EventArgs e)
        {

        }

        private void transakcijaVnesi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sumaVnesi_KeyPress(object sender, KeyPressEventArgs e)
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

        private void transakcijaPlati_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sumaPlati_KeyPress(object sender, KeyPressEventArgs e)
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

        private void transakcijaPromeni_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sumaPromeni_KeyPress(object sender, KeyPressEventArgs e)
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

        private void brojPrebaraj_KeyPress(object sender, KeyPressEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupPlati_Enter(object sender, EventArgs e)
        {

        }

        private void sumaOdPrebaraj_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sumaDoPrebaraj_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnVnesi_Click(object sender, EventArgs e)
        {
            if(imeVnesi.Text != "" && tipVnesi.Text != "" && transakcijaVnesi.Text != "")
            {
                if(transakcijaVnesi.Text.Length == 15)
                {
                    if (tbSlika.Text != "")
                    {
                        try
                        {
                            long transakciskaSmetka;
                            bool daliEbroj = Int64.TryParse(transakcijaVnesi.Text, out transakciskaSmetka);
                            if (daliEbroj)
                            {
                                Insert objInsert = new Insert();
                                Assets objAssets = new Assets();
                                string brojNaPlatenaSmetka=objAssets.RandomBrojNaFaktura();
                                objInsert.InsertSmetki(imeVnesi.Text, tipVnesi.Text, transakciskaSmetka.ToString(), zabeleshkaVnesi.Text, brojNaPlatenaSmetka,tbSlika.Text);

                                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                                SQLManager objSql = new SQLManager(connectionString);

                                tipPlati.DataSource = null;
                                tipPromeni.DataSource = null;

                                tipPlati.Items.Clear();
                                tipPromeni.Items.Clear();

                                DataTable comboData = new DataTable();
                                comboData.Columns.Add("id_smetki");
                                comboData.Columns.Add("tip_smetki");
                                comboData.Columns.Add("ime_smetki");
                                comboData.Columns.Add("transakciska_smetka_smetki");
                                comboData.Columns.Add("zabeleshka_smetki");

                                lvSmetki.Items.Clear();
                                SqlDataReader sqlite_datareader_smetki = objSql.SelectFrom("Smetki");
                                while (sqlite_datareader_smetki.Read())
                                {
                                    string[] arr = new string[5];
                                    ListViewItem itm;

                                    arr[0] = sqlite_datareader_smetki.GetValue(5).ToString()+"-"+ sqlite_datareader_smetki.GetValue(0).ToString();
                                    arr[1] = sqlite_datareader_smetki.GetValue(1).ToString();
                                    arr[2] = sqlite_datareader_smetki.GetValue(2).ToString();
                                    arr[3] = sqlite_datareader_smetki.GetInt64(3).ToString();
                                    arr[4] = sqlite_datareader_smetki.GetValue(4).ToString();

                                    itm = new ListViewItem(arr);
                                    lvSmetki.Items.Add(itm);

                                    comboData.Rows.Add(sqlite_datareader_smetki.GetValue(0).ToString(), $" уникатен бр: {sqlite_datareader_smetki.GetValue(0)} - {sqlite_datareader_smetki.GetValue(2)} - {sqlite_datareader_smetki.GetValue(1)} ", sqlite_datareader_smetki.GetValue(1).ToString(), sqlite_datareader_smetki.GetInt64(3).ToString(), sqlite_datareader_smetki.GetValue(4).ToString()); //polnam za vo combo box so da izlezi
                                }

                                tipPlati.DataSource = comboData;
                                tipPlati.DisplayMember = "tip_smetki";
                                tipPlati.ValueMember = "id_smetki";

                                tipPromeni.DataSource = comboData;
                                tipPromeni.DisplayMember = "tip_smetki";
                                tipPromeni.ValueMember = "id_smetki";

                                imePrebaraj.DataSource = comboData;
                                imePrebaraj.DisplayMember = "tip_smetki";
                                imePrebaraj.ValueMember = "id_smetki";
                                imePrebaraj.Visible = false;
                                objSql.CloseConnection();


                                tipVnesi.Text = "";
                                imeVnesi.Text = "";
                                transakcijaVnesi.Text = "";
                                zabeleshkaVnesi.Text = "";
                                tbSlika.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Дозволени се само бројки цифри !!! Ве молам внесете 15 цифрен број на трансакциска сметка !!!");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Има проблеми со внесувањето на сметката ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Задолжително изберете слика за компанијата !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Внесете 15 цифрен број на трансакциска сметка !!!");
                }
            }
            else
            {
                MessageBox.Show("Сите полиња, освен полето за забелешка се задолжителни  !!!");
            }
        }

        private void btnPlati_Click(object sender, EventArgs e)
        {

            if(tipPlati.Text != "" && imePlati.Text !="" && transakcijaPlati.Text !="" && sumaPlati.Text != "")
            {
                try
                {
                    DateTime date = DateTime.Now;
                    string vreme = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string proveriMesec = date.ToString("yyyy-MM");
                    bool daliEplatena = false;

                    Insert objInsert = new Insert();
                    Update objUpdate = new Update();
                    Assets objAssets = new Assets();

                    string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                    SQLManager objSql = new SQLManager(connectionString);

                    SqlDataReader sqlite_datareader_poveriMesec = objSql.SelectFrom("Plateni_smetki where smetka_id="+ tipPlati.SelectedValue.ToString());
                    while (sqlite_datareader_poveriMesec.Read())
                    {
                         if (sqlite_datareader_poveriMesec.GetDateTime(2).ToString("yyyy-MM") == proveriMesec)
                         {
                             daliEplatena=true;  
                         }
                    }
                    objSql.CloseConnection();

                    if(daliEplatena == false)
                    {

                        objInsert.InsertPlateniSmetki(tipPlati.SelectedValue.ToString(), vreme, sumaPlati.Text, zabeleshkaPlati.Text);
                        objInsert.InsertOdliv(vreme, sumaPlati.Text, Form1.korisnikIme, transakcijaPlati.Text, "Плаќање сметка на компанија: " + imePlati.Text);
                        objUpdate.UpdateBudzetOdliv(vreme, sumaPlati.Text, "Плаќање сметка на компанија: " + imePlati.Text);

                        string koloni = "id_plateni_smetki,ime_smetki,tip_smetki,suma_plateni_smetki,datum_plateni_smetki,ime,prezime,zabeleshka_plateni_smetki,broj_smetki,slika_smetki,id_smetki";
                        string tableNamePlateniSmetki = "Plateni_smetki inner join Smetki on Plateni_smetki.smetka_id=Smetki.id_smetki inner join Vraboteni on Plateni_smetki.korisnicko_ime_plateni_smetki=Vraboteni.korisnicko_ime order by datum_plateni_smetki desc";//order by date
                        lvPlateniSmetki.Items.Clear();
                        SqlDataReader sqlite_datareader_plateni_smetki = objSql.SelectFields(koloni, tableNamePlateniSmetki);
                        while (sqlite_datareader_plateni_smetki.Read())
                        {
                            string[] arr = new string[7];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader_plateni_smetki.GetValue(8).ToString() + "/" + sqlite_datareader_plateni_smetki.GetValue(10).ToString() + "-" + sqlite_datareader_plateni_smetki.GetValue(0).ToString();
                            arr[1] = sqlite_datareader_plateni_smetki.GetValue(1).ToString();
                            arr[2] = sqlite_datareader_plateni_smetki.GetValue(2).ToString();
                            arr[3] = sqlite_datareader_plateni_smetki.GetValue(3).ToString();
                            arr[4] = sqlite_datareader_plateni_smetki.GetValue(4).ToString();
                            arr[5] = sqlite_datareader_plateni_smetki.GetValue(5).ToString() + " " + sqlite_datareader_plateni_smetki.GetValue(6).ToString();
                            arr[6] = sqlite_datareader_plateni_smetki.GetValue(7).ToString();

                            itm = new ListViewItem(arr);
                            lvPlateniSmetki.Items.Add(itm);

                        }
                        objSql.CloseConnection();

                        string platenaSmetka = "                                                   PLATENA SMETKA\n\n";
                        string brojNaPlatenaSmetka = "";
                        string slikaPath = "";
                        SqlDataReader sqlite_datareader = objSql.SelectFields("*", "Plateni_smetki inner join Smetki on Plateni_smetki.smetka_id=Smetki.id_smetki inner join Vraboteni on Plateni_smetki.korisnicko_ime_plateni_smetki=Vraboteni.korisnicko_ime WHERE datum_plateni_smetki='" + vreme + "'");
                        while (sqlite_datareader.Read())
                        {
                            int vkupnaCena = sqlite_datareader.GetInt32(3);
                            double ddv = objAssets.PremsetajDanok(vkupnaCena, 18);
                            double cenaBezDdv = vkupnaCena - ddv;

                            slikaPath += sqlite_datareader.GetValue(12);
                            brojNaPlatenaSmetka += sqlite_datareader.GetValue(0);
                            platenaSmetka += "                                                   FAKTURA " + sqlite_datareader.GetValue(11) + "/" + sqlite_datareader.GetValue(1) + "-" + sqlite_datareader.GetValue(0) + "\n\n";
                            platenaSmetka += "Naziv na primachot: " + sqlite_datareader.GetValue(7) + "   Naziv na proizvodot: " + sqlite_datareader.GetValue(8) + "   Danok od 18%: " + ddv + "   Cena bez danok od 18%: " + cenaBezDdv + "   Cena so danok: " + sqlite_datareader.GetValue(3) + "\n\n";
                            platenaSmetka += "Isplatil: " + sqlite_datareader.GetValue(15) + " " + sqlite_datareader.GetValue(16) + "\nDatum i vreme na isplakjanje: " + sqlite_datareader.GetValue(17) + "\n\nTransakciska smetka na primachot: " + sqlite_datareader.GetValue(9);
                        }
                        objSql.CloseConnection();
                        string path = "C:\\Users\\Vladimir Piki\\mikrosamProekti\\Project\\CafeManagementServer\\CafeManagementServer\\smetki\\";
                        objAssets.PdfSmetka(brojNaPlatenaSmetka, platenaSmetka, slikaPath, path);

                        tipPlati.Text = "";
                        imePlati.Text = "";
                        transakcijaPlati.Text = "";
                        zabeleshkaPlati.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Платена е сметка за месец " + proveriMesec);
                    }

 
                }
                catch
                {
                    MessageBox.Show("Има проблем со плаќањето на сметката !!!");
                }
              
            }
            else
            {
                MessageBox.Show("Задолжително изберете тип на сметка и внесете сума !!!");
            }

        }

        private void lvSmetki_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvSmetki.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = lvSmetki.SelectedItems[0];
                    string id = "";
                    List<string> lista = new List<string>(); 
                    Assets objAssets=new Assets();
                    lista=objAssets.split(selectedItem.SubItems[0].Text,"-");
                    id = lista[1];  
                    tipPromeni.SelectedValue = id;
                    imePromeni.Text = selectedItem.SubItems[1].Text;
                    transakcijaPromeni.Text = selectedItem.SubItems[3].Text;
                    zabeleshkaPromeni.Text = selectedItem.SubItems[4].Text;
                }
            }
            catch
            {
                MessageBox.Show("Има проблем со селектирањето на сите сметки");
            }

        }

        private void btnPromeni_Click(object sender, EventArgs e)
        {
            if(tipPromeni.Text !="" && imePromeni.Text !="" && transakcijaPromeni.Text != "" )
            {
                if (transakcijaPromeni.Text.Length == 15)
                { 
                    try
                    {
                        long transakciskaSmetka;
                        bool daliEbroj = Int64.TryParse(transakcijaPromeni.Text, out transakciskaSmetka);
                        if (daliEbroj)
                        {
                            Update objUpdate = new Update();
                            objUpdate.UpdateSmetki(tipPromeni.SelectedValue.ToString(), imePromeni.Text, transakciskaSmetka.ToString(), zabeleshkaPromeni.Text);

                            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                            SQLManager objSql = new SQLManager(connectionString);

                            tipPlati.DataSource = null;
                            tipPromeni.DataSource = null;

                            tipPlati.Items.Clear();
                            tipPromeni.Items.Clear();

                            DataTable comboData = new DataTable();
                            comboData.Columns.Add("id_smetki");
                            comboData.Columns.Add("tip_smetki");
                            comboData.Columns.Add("ime_smetki");
                            comboData.Columns.Add("transakciska_smetka_smetki");
                            comboData.Columns.Add("zabeleshka_smetki");

                            lvSmetki.Items.Clear();
                            SqlDataReader sqlite_datareader_smetki = objSql.SelectFrom("Smetki");
                            while (sqlite_datareader_smetki.Read())
                            {
                                string[] arr = new string[5];
                                ListViewItem itm;

                                arr[0] = sqlite_datareader_smetki.GetValue(5).ToString()+"-"+ sqlite_datareader_smetki.GetValue(0).ToString();
                                arr[1] = sqlite_datareader_smetki.GetValue(1).ToString();
                                arr[2] = sqlite_datareader_smetki.GetValue(2).ToString();
                                arr[3] = sqlite_datareader_smetki.GetInt64(3).ToString();
                                arr[4] = sqlite_datareader_smetki.GetValue(4).ToString();

                                itm = new ListViewItem(arr);
                                lvSmetki.Items.Add(itm);

                                comboData.Rows.Add(sqlite_datareader_smetki.GetValue(0).ToString(), $" уникатен бр: {sqlite_datareader_smetki.GetValue(0)} - {sqlite_datareader_smetki.GetValue(2)} - {sqlite_datareader_smetki.GetValue(1)} ", sqlite_datareader_smetki.GetValue(1).ToString(), sqlite_datareader_smetki.GetInt64(3).ToString(), sqlite_datareader_smetki.GetValue(4).ToString()); //polnam za vo combo box so da izlezi
                            }

                            tipPlati.DataSource = comboData;
                            tipPlati.DisplayMember = "tip_smetki";
                            tipPlati.ValueMember = "id_smetki";

                            tipPromeni.DataSource = comboData;
                            tipPromeni.DisplayMember = "tip_smetki";
                            tipPromeni.ValueMember = "id_smetki";

                            imePrebaraj.DataSource = comboData;
                            imePrebaraj.DisplayMember = "tip_smetki";
                            imePrebaraj.ValueMember = "id_smetki";
                            imePrebaraj.Visible= false; 

                            objSql.CloseConnection();

                            tipPromeni.Text = "";
                            imePromeni.Text = "";
                            transakcijaPromeni.Text = "";
                            zabeleshkaPromeni.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("Дозволени се само бројки цифри !!! Ве молам внесете 15 цифрен број на трансакциска сметка !!!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Има проблеми со внесувањето на сметката ");
                    }

                }
                else
                {
                    MessageBox.Show("Внесете 15 цифрен број на трансакциска сметка !!!");
                }
            }
            else
            {
                MessageBox.Show("Сите полиња, освен полето за забелешка се задолжителни  !!!");
            }
        }

        private void tipPromeni_SelectedValueChanged(object sender, EventArgs e)
        {
            if (tipPromeni.SelectedItem != null)
            {
            DataRowView selectedDataRow = (DataRowView)tipPromeni.SelectedItem;
            imePromeni.Text = selectedDataRow["ime_smetki"].ToString();
            transakcijaPromeni.Text = selectedDataRow["transakciska_smetka_smetki"].ToString();
            zabeleshkaPromeni.Text = selectedDataRow["zabeleshka_smetki"].ToString();
            }
            else
            {
                imePromeni.Text = "";
                transakcijaPromeni.Text = "";
                zabeleshkaPromeni.Text = "";
            }
        }

        private void btnIzbrisi_Click(object sender, EventArgs e)
        {
            if(lvSmetki.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvSmetki.SelectedItems[0];
                string id_smetka="";
                Assets objAssets = new Assets();
                List<string> lista =objAssets.split(selectedItem.SubItems[0].Text, "-");
                id_smetka = lista[1];
                DialogResult result = MessageBox.Show("Дали сакате да ја избришете сметката со уникатен број "+ selectedItem.SubItems[0].Text + " и име на компанијата "+ selectedItem.SubItems[1].Text+" ? ", "Потврда за бришење сметка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Delete objDelete = new Delete();
                        objDelete.DeletePlateniSmetki(id_smetka);
                        objDelete.DeleteSmetki(id_smetka);

                        string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                        SQLManager objSql = new SQLManager(connectionString);

                        tipPlati.DataSource = null;
                        tipPromeni.DataSource = null;

                        tipPlati.Items.Clear();
                        tipPromeni.Items.Clear();

                        DataTable comboData = new DataTable();
                        comboData.Columns.Add("id_smetki");
                        comboData.Columns.Add("tip_smetki");
                        comboData.Columns.Add("ime_smetki");
                        comboData.Columns.Add("transakciska_smetka_smetki");
                        comboData.Columns.Add("zabeleshka_smetki");

                        lvSmetki.Items.Clear();
                        SqlDataReader sqlite_datareader_smetki = objSql.SelectFrom("Smetki");
                        while (sqlite_datareader_smetki.Read())
                        {
                            string[] arr = new string[5];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader_smetki.GetValue(5).ToString() + "-" + sqlite_datareader_smetki.GetValue(0).ToString();
                            arr[1] = sqlite_datareader_smetki.GetValue(1).ToString();
                            arr[2] = sqlite_datareader_smetki.GetValue(2).ToString();
                            arr[3] = sqlite_datareader_smetki.GetInt64(3).ToString();
                            arr[4] = sqlite_datareader_smetki.GetValue(4).ToString();

                            itm = new ListViewItem(arr);
                            lvSmetki.Items.Add(itm);

                            comboData.Rows.Add(sqlite_datareader_smetki.GetValue(0).ToString(), $" уникатен бр: {sqlite_datareader_smetki.GetValue(0)} - {sqlite_datareader_smetki.GetValue(2)} - {sqlite_datareader_smetki.GetValue(1)} ", sqlite_datareader_smetki.GetValue(1).ToString(), sqlite_datareader_smetki.GetInt64(3).ToString(), sqlite_datareader_smetki.GetValue(4).ToString()); 
                        }

                        tipPlati.DataSource = comboData;
                        tipPlati.DisplayMember = "tip_smetki";
                        tipPlati.ValueMember = "id_smetki";

                        tipPromeni.DataSource = comboData;
                        tipPromeni.DisplayMember = "tip_smetki";
                        tipPromeni.ValueMember = "id_smetki";

                        imePrebaraj.DataSource = comboData;
                        imePrebaraj.DisplayMember = "tip_smetki";
                        imePrebaraj.ValueMember = "id_smetki";

                        objSql.CloseConnection();

                        string koloni = "id_plateni_smetki,ime_smetki,tip_smetki,suma_plateni_smetki,datum_plateni_smetki,ime,prezime,zabeleshka_plateni_smetki,broj_smetki,slika_smetki,id_smetki";
                        string tableNamePlateniSmetki = "Plateni_smetki inner join Smetki on Plateni_smetki.smetka_id=Smetki.id_smetki inner join Vraboteni on Plateni_smetki.korisnicko_ime_plateni_smetki=Vraboteni.korisnicko_ime order by datum_plateni_smetki  desc";//order by date
                        lvPlateniSmetki.Items.Clear();
                        SqlDataReader sqlite_datareader_plateni_smetki = objSql.SelectFields(koloni, tableNamePlateniSmetki);
                        while (sqlite_datareader_plateni_smetki.Read())
                        {
                            string[] arr = new string[7];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader_plateni_smetki.GetValue(8).ToString() + "/" + sqlite_datareader_plateni_smetki.GetValue(10).ToString() + "-" + sqlite_datareader_plateni_smetki.GetValue(0).ToString();
                            arr[1] = sqlite_datareader_plateni_smetki.GetValue(1).ToString();
                            arr[2] = sqlite_datareader_plateni_smetki.GetValue(2).ToString();
                            arr[3] = sqlite_datareader_plateni_smetki.GetValue(3).ToString();
                            arr[4] = sqlite_datareader_plateni_smetki.GetValue(4).ToString();
                            arr[5] = sqlite_datareader_plateni_smetki.GetValue(5).ToString() + " " + sqlite_datareader_plateni_smetki.GetValue(6).ToString();
                            arr[6] = sqlite_datareader_plateni_smetki.GetValue(7).ToString();

                            itm = new ListViewItem(arr);
                            lvPlateniSmetki.Items.Add(itm);

                        }
                        objSql.CloseConnection();

                        tipPromeni.SelectedValue = "";
                        imePromeni.Text = "";
                        transakcijaPromeni.Text = "";
                        zabeleshkaPromeni.Text = "";

                        tipPlati.SelectedValue = "";
                        imePlati.Text = "";
                        transakcijaPlati.Text = "";
                        zabeleshkaPlati.Text = "";

                        imePrebaraj.SelectedValue = "";
                        brojPrebaraj.Text = "";
                        tipPrebaraj.SelectedValue = "";
                        sumaOdPrebaraj.Text = "";
                        sumaDoPrebaraj.Text = "";
                    }
                    catch {
                        MessageBox.Show("Има проблем со бришењето на сметката !!!");
                    }
                 
                }
            }
            else
            {
                MessageBox.Show("Доколку сакате да избришете сметка ве молам изберете ја од листата сите сметки со клик");
            }
        
        }

        private void tipPromeni_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tipPlati_SelectedValueChanged(object sender, EventArgs e)
        {
            if (tipPlati.SelectedItem != null)
            {
                DataRowView selectedDataRow = (DataRowView)tipPlati.SelectedItem;
                imePlati.Text = selectedDataRow["ime_smetki"].ToString();
                transakcijaPlati.Text = selectedDataRow["transakciska_smetka_smetki"].ToString();
            }
            else
            {
                imePlati.Text = "";
                transakcijaPlati.Text = "";
            }
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

        private void lvPlateniSmetki_DockChanged(object sender, EventArgs e)
        {

        }

        private void lvPlateniSmetki_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = lvPlateniSmetki.SelectedItems[0];

                if (selectedItem.Text != "")
                {
                    string id_smetka = "";
                    Assets objAssets = new Assets();
                    List<string> lista = objAssets.split(selectedItem.SubItems[0].Text, "-");
                    id_smetka = lista[1];
                    string imeNaPdf = id_smetka + ".pdf";
                    axAcroPDF1.src = "C:\\Users\\Vladimir Piki\\mikrosamProekti\\Project\\CafeManagementServer\\CafeManagementServer\\smetki\\" + "broj_na_platena_smetka-" + imeNaPdf;
                }
            }
            catch
            {
                MessageBox.Show("Има проблем во прегледувањето на сметката");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnPrebaraj_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> koloni = new List<string>();

                if (brojPrebaraj.Text != "" && cbBroj.Checked)
                {
                    koloni.Add("id_plateni_smetki="+brojPrebaraj.Text);
                }
                if (imePrebaraj.Text != "" && cbIme.Checked)
                {
                    koloni.Add("smetka_id="+ imePrebaraj.SelectedValue.ToString());
                }
                if (tipPrebaraj.Text != "" && cbTip.Checked)
                {
                    koloni.Add("tip_smetki='"+ tipPrebaraj.Text+"'");
                }
                if (cbDatum.Checked)
                {
                    if (DateTime.TryParse(datumOdPrebaraj.Text, out DateTime datumPocetok) && DateTime.TryParse(datumDoPrebaraj.Text, out DateTime datumKraj))
                    {
                        if(datumPocetok <= datumKraj)
                        {
                            koloni.Add("datum_plateni_smetki between '"+ datumPocetok.ToString("yyyy-MM-dd") + " 00:00:00' and '"+ datumKraj.ToString("yyyy-MM-dd") + " 23:59:59'");
                        }
                        else
                        {
                            MessageBox.Show("Внесувате неправилен датум !!! Нема да пребарува по датум !!!");
                        }
                    }
                }
                if (sumaOdPrebaraj.Text != "" && sumaDoPrebaraj.Text != "" && cbSuma.Checked)
                { 
                    koloni.Add("suma_plateni_smetki between "+ sumaOdPrebaraj.Text+" and "+ sumaDoPrebaraj.Text);
                }
                if (sopstvenikPrebaraj.Text != ""  && cbSopstvenik.Checked)
                {
                    koloni.Add("korisnicko_ime='"+ sopstvenikPrebaraj.SelectedValue.ToString() + "'");
                }


                string where = " WHERE ";
                for (int i = 0; i < koloni.Count; i++)
                {
                    if (i < koloni.Count - 1)
                    {
                        where = where + koloni[i]+ " AND ";

                    }
                    else
                    {
                        where = where + koloni[i];
                    }
                }

                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);

                string koloni1 = "id_plateni_smetki,ime_smetki,tip_smetki,suma_plateni_smetki,datum_plateni_smetki,ime,prezime,zabeleshka_plateni_smetki,broj_smetki,slika_smetki,id_smetki";
                string tableNamePlateniSmetki = "Plateni_smetki inner join Smetki on Plateni_smetki.smetka_id=Smetki.id_smetki inner join Vraboteni on Plateni_smetki.korisnicko_ime_plateni_smetki=Vraboteni.korisnicko_ime "+where+" order by datum_plateni_smetki desc";//order by date
                lvPlateniSmetki.Items.Clear();
                SqlDataReader sqlite_datareader_plateni_smetki = objSql.SelectFields(koloni1, tableNamePlateniSmetki);
                while (sqlite_datareader_plateni_smetki.Read())
                {
                    string[] arr = new string[7];
                    ListViewItem itm;

                    arr[0] = sqlite_datareader_plateni_smetki.GetValue(8).ToString() + "/" + sqlite_datareader_plateni_smetki.GetValue(10).ToString() + "-" + sqlite_datareader_plateni_smetki.GetValue(0).ToString();
                    arr[1] = sqlite_datareader_plateni_smetki.GetValue(1).ToString();
                    arr[2] = sqlite_datareader_plateni_smetki.GetValue(2).ToString();
                    arr[3] = sqlite_datareader_plateni_smetki.GetValue(3).ToString();
                    arr[4] = sqlite_datareader_plateni_smetki.GetValue(4).ToString();
                    arr[5] = sqlite_datareader_plateni_smetki.GetValue(5).ToString() + " " + sqlite_datareader_plateni_smetki.GetValue(6).ToString();
                    arr[6] = sqlite_datareader_plateni_smetki.GetValue(7).ToString();

                    itm = new ListViewItem(arr);
                    lvPlateniSmetki.Items.Add(itm);

                }
                objSql.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Има проблем со пребарувањето на платените сметки");
            }
        }

        private void cbBroj_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBroj.Checked)
            {
                labelBroj.Visible= true;
                brojPrebaraj.Visible = true;
            }
            else
            {
                labelBroj.Visible = false;
                brojPrebaraj.Visible = false;
                brojPrebaraj.Text = "";
            }
        }

        private void cbIme_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIme.Checked)
            {
                imePrebaraj.Visible = true;
            }
            else
            {
                imePrebaraj.Visible = false;
                imePrebaraj.Text = "";
            }
        }

        private void cbTip_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTip.Checked)
            {
                tipPrebaraj.Visible = true;
            }
            else
            {
                tipPrebaraj.Visible = false;
                tipPrebaraj.Text = "";
            }
        }

        private void cbDatum_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDatum.Checked)
            {
                labelDatumOd.Visible = true;
                labelDatumDo.Visible = true;
                datumOdPrebaraj.Visible = true;
                datumDoPrebaraj.Visible = true;
            }
            else
            {
                labelDatumOd.Visible = false;
                labelDatumDo.Visible = false;
                datumOdPrebaraj.Visible = false;
                datumDoPrebaraj.Visible = false;
            }
        }

        private void cbSuma_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSuma.Checked)
            {
                labelSumaOd.Visible = true;
                labelSumaDo.Visible = true;
                sumaOdPrebaraj.Visible = true;
                sumaDoPrebaraj.Visible = true;
            }
            else
            {
                labelSumaOd.Visible = false;
                labelSumaDo.Visible = false;
                sumaOdPrebaraj.Visible = false;
                sumaDoPrebaraj.Visible = false;
                sumaOdPrebaraj.Text = "";
                sumaDoPrebaraj.Text = "";
            }
        }

        private void tipPlati_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void imePrebaraj_SelectedValueChanged(object sender, EventArgs e)
        {
            if (imePrebaraj.SelectedItem != null)
            {
                DataRowView selectedDataRow = (DataRowView)imePrebaraj.SelectedItem;
                tipPlati.Text = "";
                tipPromeni.Text = "";
            }
            else
            {
                imePrebaraj.Text = "";
            }
        }

        private void cbSopstvenik_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSopstvenik.Checked)
            {
                sopstvenikPrebaraj.Visible = true;
            }
            else
            {
                sopstvenikPrebaraj.Visible = false;
                sopstvenikPrebaraj.Text = "";
            }
        }

        private void btnPrebarajSite_Click(object sender, EventArgs e)
        {
            try
            {

                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string koloni = "id_plateni_smetki,ime_smetki,tip_smetki,suma_plateni_smetki,datum_plateni_smetki,ime,prezime,zabeleshka_plateni_smetki,broj_smetki,slika_smetki,id_smetki";
                string tableNamePlateniSmetki = "Plateni_smetki inner join Smetki on Plateni_smetki.smetka_id=Smetki.id_smetki inner join Vraboteni on Plateni_smetki.korisnicko_ime_plateni_smetki=Vraboteni.korisnicko_ime order by datum_plateni_smetki desc";//order by date
                lvPlateniSmetki.Items.Clear();
                SqlDataReader sqlite_datareader_plateni_smetki = objSql.SelectFields(koloni, tableNamePlateniSmetki);
                while (sqlite_datareader_plateni_smetki.Read())
                {
                    string[] arr = new string[7];
                    ListViewItem itm;

                    arr[0] = sqlite_datareader_plateni_smetki.GetValue(8).ToString() + "/" + sqlite_datareader_plateni_smetki.GetValue(10).ToString() + "-" + sqlite_datareader_plateni_smetki.GetValue(0).ToString();
                    arr[1] = sqlite_datareader_plateni_smetki.GetValue(1).ToString();
                    arr[2] = sqlite_datareader_plateni_smetki.GetValue(2).ToString();
                    arr[3] = sqlite_datareader_plateni_smetki.GetValue(3).ToString();
                    arr[4] = sqlite_datareader_plateni_smetki.GetValue(4).ToString();
                    arr[5] = sqlite_datareader_plateni_smetki.GetValue(5).ToString() + " " + sqlite_datareader_plateni_smetki.GetValue(6).ToString();
                    arr[6] = sqlite_datareader_plateni_smetki.GetValue(7).ToString();

                    itm = new ListViewItem(arr);
                    lvPlateniSmetki.Items.Add(itm);

                }
                objSql.CloseConnection();
            }
            catch {
                MessageBox.Show("Има проблем со пребарувањето на сите Платени сметки");
            }  
        }

        private void lvPlateniSmetki_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void imeVnesi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
