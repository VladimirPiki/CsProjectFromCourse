using iTextSharp.text.pdf.parser.clipper;
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
using System.Xml;
using static CafeManagementServer.Database;

namespace CafeManagementServer
{
    public partial class Denovi : Form
    {
        public Denovi()
        {
            InitializeComponent();

            lvMomentalnaSostojba.View = View.Details;
            lvMomentalnaSostojba.GridLines = true;
            lvMomentalnaSostojba.FullRowSelect = true;
            lvMomentalnaSostojba.Columns.Add("Корисничко име", 200);
            lvMomentalnaSostojba.Columns.Add("Име на вработен", 200);
            lvMomentalnaSostojba.Columns.Add("Презиме на вработен", 200);
            lvMomentalnaSostojba.Columns.Add("Вкупен број на слободни дена", 200);
            lvMomentalnaSostojba.Columns.Add("Датум на последна промена на слободен ден", 200);
            lvMomentalnaSostojba.Columns.Add("Забелешка за вкупниот број на слобoдни денови", 200);

            lvDodeleniDenovi.View = View.Details;
            lvDodeleniDenovi.GridLines = true;
            lvDodeleniDenovi.FullRowSelect = true;
            lvDodeleniDenovi.Columns.Add("Корисничко име", 200);
            lvDodeleniDenovi.Columns.Add("Име на вработен", 200);
            lvDodeleniDenovi.Columns.Add("Презиме на вработен", 200);
            lvDodeleniDenovi.Columns.Add("Вкупен број на доделување денови", 200);
            lvDodeleniDenovi.Columns.Add("Датум на доделување на денови", 200);
            lvDodeleniDenovi.Columns.Add("Причина за доделување на денови", 200);
            lvDodeleniDenovi.Columns.Add("Забелешка за доделување на денови", 200);
            lvDodeleniDenovi.Columns.Add("Кој ги доделил слободните денови", 200);

            lvIskoristeniDenovi.View = View.Details;
            lvIskoristeniDenovi.GridLines = true;
            lvIskoristeniDenovi.FullRowSelect = true;
            lvIskoristeniDenovi.Columns.Add("Корисничко име", 200);
            lvIskoristeniDenovi.Columns.Add("Име на вработен", 200);
            lvIskoristeniDenovi.Columns.Add("Презиме на вработен", 200);
            lvIskoristeniDenovi.Columns.Add("Датум почеток на користење ден", 200);
            lvIskoristeniDenovi.Columns.Add("Датум завршеток на користење ден", 200);
            lvIskoristeniDenovi.Columns.Add("Датум враќање на работа", 200);
            lvIskoristeniDenovi.Columns.Add("Вкупен број искористени денови", 200);
            lvIskoristeniDenovi.Columns.Add("Причина за користење ден", 200);
            lvIskoristeniDenovi.Columns.Add("Датум на креирање", 200);
            lvIskoristeniDenovi.Columns.Add("Забелешка за користење ден", 200);
            lvIskoristeniDenovi.Columns.Add("Кој ги креирал искористените денови", 200);

            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string tableName = "Vraboteni";
            SqlDataReader sqlite_datareader = objSql.SelectFrom(tableName);

            prebarajVraboteni.Items.Add("Сите вработени");
            iskoristiSdVraboteni.Items.Add("Сите вработени");
            dodeliVraboteni.Items.Add("Сите вработени");
            while (sqlite_datareader.Read())
            {
                prebarajVraboteni.Items.Add(sqlite_datareader.GetString(0));   
                iskoristiSdVraboteni.Items.Add(sqlite_datareader.GetString(0));
                dodeliVraboteni.Items.Add(sqlite_datareader.GetString(0));
            }
            objSql.CloseConnection();

            string imnjaKoloni1 = "korisnicko_ime,ime,prezime,broj_slobodni_denovi,datum_slobodni_denovi,zabeleshka_slobodni_denovi";
            string tableName1 = "Slobodni_denovi inner join Vraboteni on Slobodni_denovi.korisnicko_ime_slobodni_denovi=Vraboteni.korisnicko_ime";
            lvMomentalnaSostojba.Items.Clear();
            SqlDataReader sqlite_datareader_1 = objSql.SelectFields(imnjaKoloni1, tableName1);
            while (sqlite_datareader_1.Read())
            {
                string[] arr = new string[6];
                ListViewItem itm;

                arr[0] = sqlite_datareader_1.GetValue(0).ToString();
                arr[1] = sqlite_datareader_1.GetValue(1).ToString();
                arr[2] = sqlite_datareader_1.GetValue(2).ToString();
                arr[3] = sqlite_datareader_1.GetValue(3).ToString();
                arr[4] = sqlite_datareader_1.GetDateTime(4).ToString("yyyy-MM-dd");
                arr[5] = sqlite_datareader_1.GetValue(5).ToString();

                itm = new ListViewItem(arr);
                lvMomentalnaSostojba.Items.Add(itm);

            }
            objSql.CloseConnection();

            string imnjaKoloni_2 = "korisnicko_ime,ime,prezime,broj_dodeluvanje_slobodni_denovi,datum_dodeluvanje_slobodni_denovi,pricina_dodeluvanje_slobodni_denovi,zabeleshka_dodeluvanje_slobodni_denovi,korisnicko_ime_vnesuvanje";
            string tableName_2 = "Dodeluvanje_slobodni_denovi inner join Vraboteni ON Dodeluvanje_slobodni_denovi.korisnicko_ime_dodeluvanje_slobodni_denovi=Vraboteni.korisnicko_ime order by datum_dodeluvanje_slobodni_denovi";
            lvDodeleniDenovi.Items.Clear();
            SqlDataReader sqlite_datareader_2 = objSql.SelectFields(imnjaKoloni_2, tableName_2);
            while (sqlite_datareader_2.Read())
            {
                string[] arr = new string[8];
                ListViewItem itm;

                arr[0] = sqlite_datareader_2.GetValue(0).ToString();
                arr[1] = sqlite_datareader_2.GetValue(1).ToString();
                arr[2] = sqlite_datareader_2.GetValue(2).ToString();
                arr[3] = sqlite_datareader_2.GetValue(3).ToString();
                arr[4] = sqlite_datareader_2.GetDateTime(4).ToString("yyyy-MM-dd");
                arr[5] = sqlite_datareader_2.GetValue(5).ToString();
                arr[6] = sqlite_datareader_2.GetValue(6).ToString();
                arr[7] = sqlite_datareader_2.GetValue(7).ToString();

                itm = new ListViewItem(arr);
                lvDodeleniDenovi.Items.Add(itm);

            }
            objSql.CloseConnection();

            string imnjaKoloni_3 = "korisnicko_ime,ime,prezime,pocetok_iskoristeni_denovi,zavrshetok_iskoristeni_denovi,vrakjanje_iskoristeni_denovi,vkupno_denovi_iskoristeni_denovi,pricina_iskoristeni_denovi, kreirano_iskoristeni_denovi, zabeleshka_iskoristeni_denovi,korisnicko_ime_kreiranje";
            string tableName_3 = "Iskoristeni_denovi inner Join Vraboteni on Iskoristeni_denovi.korisnicko_ime_iskoristeni_denovi=Vraboteni.korisnicko_ime order by kreirano_iskoristeni_denovi";
            lvIskoristeniDenovi.Items.Clear();
            SqlDataReader sqlite_datareader_3 = objSql.SelectFields(imnjaKoloni_3, tableName_3);
            while (sqlite_datareader_3.Read())
            {
                string[] arr = new string[11];
                ListViewItem itm;

                arr[0] = sqlite_datareader_3.GetValue(0).ToString();
                arr[1] = sqlite_datareader_3.GetValue(1).ToString();
                arr[2] = sqlite_datareader_3.GetValue(2).ToString();
                arr[3] = sqlite_datareader_3.GetDateTime(3).ToString("yyyy-MM-dd");
                arr[4] = sqlite_datareader_3.GetDateTime(4).ToString("yyyy-MM-dd");
                arr[5] = sqlite_datareader_3.GetDateTime(5).ToString("yyyy-MM-dd");
                arr[6] = sqlite_datareader_3.GetValue(6).ToString();
                arr[7] = sqlite_datareader_3.GetValue(7).ToString();
                arr[8] = sqlite_datareader_3.GetDateTime(8).ToString("yyyy-MM-dd");
                arr[9] = sqlite_datareader_3.GetValue(9).ToString();
                arr[10] = sqlite_datareader_3.GetValue(10).ToString();

                itm = new ListViewItem(arr);
                lvIskoristeniDenovi.Items.Add(itm);

            }
            objSql.CloseConnection();

        }

        private void dodeliSd_KeyPress(object sender, KeyPressEventArgs e)
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

        private void iskoristiSdBroj_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rbDodeliSd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDodeliSd.Checked)
            {

                groupDodeli.Visible = true;
            }
            else
            {
                groupDodeli.Visible = false;
            }
        }

        private void rbIskoristiSd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIskoristiSd.Checked)
            {

                groupIskoristeniDena.Visible = true;
            }
            else
            {
                groupIskoristeniDena.Visible = false;
            }
        }

        private void rbPrebarajSd_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPrebarajSd.Checked)
            {

                groupPrebaraj.Visible = true;
            }
            else
            {
                groupPrebaraj.Visible = false;
            }
        }

        private void btnPrebaraj_Click(object sender, EventArgs e)
        {
            if (prebarajVraboteni.Text != "")
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);

                string imnjaKoloni1 = "korisnicko_ime,ime,prezime,broj_slobodni_denovi,datum_slobodni_denovi,zabeleshka_slobodni_denovi";
                string tableName1 = "";
                if (prebarajVraboteni.Text!="Сите вработени")
                {
                    tableName1 = "Slobodni_denovi inner join Vraboteni on Slobodni_denovi.korisnicko_ime_slobodni_denovi=Vraboteni.korisnicko_ime WHERE korisnicko_ime='" + prebarajVraboteni.Text + "'";
                }
                else
                {
                     tableName1 = "Slobodni_denovi inner join Vraboteni on Slobodni_denovi.korisnicko_ime_slobodni_denovi=Vraboteni.korisnicko_ime ";
                }
               
                lvMomentalnaSostojba.Items.Clear();
                SqlDataReader sqlite_datareader_1 = objSql.SelectFields(imnjaKoloni1, tableName1);
                while (sqlite_datareader_1.Read())
                {
                    string[] arr = new string[6];
                    ListViewItem itm;

                    arr[0] = sqlite_datareader_1.GetValue(0).ToString();
                    arr[1] = sqlite_datareader_1.GetValue(1).ToString();
                    arr[2] = sqlite_datareader_1.GetValue(2).ToString();
                    arr[3] = sqlite_datareader_1.GetValue(3).ToString();
                    arr[4] = sqlite_datareader_1.GetDateTime(4).ToString("yyyy-MM-dd");
                    arr[5] = sqlite_datareader_1.GetValue(5).ToString();

                    itm = new ListViewItem(arr);
                    lvMomentalnaSostojba.Items.Add(itm);

                }
                objSql.CloseConnection();

                    string imnjaKoloni_2 = "korisnicko_ime,ime,prezime,broj_dodeluvanje_slobodni_denovi,datum_dodeluvanje_slobodni_denovi,pricina_dodeluvanje_slobodni_denovi,zabeleshka_dodeluvanje_slobodni_denovi,korisnicko_ime_vnesuvanje";
                string tableName_2 = "";
                if (prebarajVraboteni.Text != "Сите вработени")
                {
                    tableName_2 = "Dodeluvanje_slobodni_denovi inner join Vraboteni ON Dodeluvanje_slobodni_denovi.korisnicko_ime_dodeluvanje_slobodni_denovi=Vraboteni.korisnicko_ime  WHERE korisnicko_ime='" + prebarajVraboteni.Text + "' order by datum_dodeluvanje_slobodni_denovi";
                }
                else
                {
                    tableName_2 = "Dodeluvanje_slobodni_denovi inner join Vraboteni ON Dodeluvanje_slobodni_denovi.korisnicko_ime_dodeluvanje_slobodni_denovi=Vraboteni.korisnicko_ime ";
                }
               
                lvDodeleniDenovi.Items.Clear();
                SqlDataReader sqlite_datareader_2 = objSql.SelectFields(imnjaKoloni_2, tableName_2);
                while (sqlite_datareader_2.Read())
                {
                    string[] arr = new string[8];
                    ListViewItem itm;

                    arr[0] = sqlite_datareader_2.GetValue(0).ToString();
                    arr[1] = sqlite_datareader_2.GetValue(1).ToString();
                    arr[2] = sqlite_datareader_2.GetValue(2).ToString();
                    arr[3] = sqlite_datareader_2.GetValue(3).ToString();
                    arr[4] = sqlite_datareader_2.GetDateTime(4).ToString("yyyy-MM-dd");
                    arr[5] = sqlite_datareader_2.GetValue(5).ToString();
                    arr[6] = sqlite_datareader_2.GetValue(6).ToString();
                    arr[7] = sqlite_datareader_2.GetValue(7).ToString();

                    itm = new ListViewItem(arr);
                    lvDodeleniDenovi.Items.Add(itm);

                }
                objSql.CloseConnection();

                string imnjaKoloni_3 = "korisnicko_ime,ime,prezime,pocetok_iskoristeni_denovi,zavrshetok_iskoristeni_denovi,vrakjanje_iskoristeni_denovi,vkupno_denovi_iskoristeni_denovi,pricina_iskoristeni_denovi, kreirano_iskoristeni_denovi, zabeleshka_iskoristeni_denovi,korisnicko_ime_kreiranje";
                string tableName_3 = "";
                if (prebarajVraboteni.Text != "Сите вработени")
                {
                    tableName_3 = "Iskoristeni_denovi inner Join Vraboteni on Iskoristeni_denovi.korisnicko_ime_iskoristeni_denovi=Vraboteni.korisnicko_ime  WHERE korisnicko_ime='" + prebarajVraboteni.Text + "'  order by kreirano_iskoristeni_denovi";
                }
                else
                {
                    tableName_3 = "Iskoristeni_denovi inner Join Vraboteni on Iskoristeni_denovi.korisnicko_ime_iskoristeni_denovi=Vraboteni.korisnicko_ime ";
                }
    
                lvIskoristeniDenovi.Items.Clear();
                SqlDataReader sqlite_datareader_3 = objSql.SelectFields(imnjaKoloni_3, tableName_3);
                while (sqlite_datareader_3.Read())
                {
                    string[] arr = new string[11];
                    ListViewItem itm;

                    arr[0] = sqlite_datareader_3.GetValue(0).ToString();
                    arr[1] = sqlite_datareader_3.GetValue(1).ToString();
                    arr[2] = sqlite_datareader_3.GetValue(2).ToString();
                    arr[3] = sqlite_datareader_3.GetDateTime(3).ToString("yyyy-MM-dd");
                    arr[4] = sqlite_datareader_3.GetDateTime(4).ToString("yyyy-MM-dd");
                    arr[5] = sqlite_datareader_3.GetDateTime(5).ToString("yyyy-MM-dd");
                    arr[6] = sqlite_datareader_3.GetValue(6).ToString();
                    arr[7] = sqlite_datareader_3.GetValue(7).ToString();
                    arr[8] = sqlite_datareader_3.GetDateTime(8).ToString("yyyy-MM-dd");
                    arr[9] = sqlite_datareader_3.GetValue(9).ToString();
                    arr[10] = sqlite_datareader_3.GetValue(10).ToString();

                    itm = new ListViewItem(arr);
                    lvIskoristeniDenovi.Items.Add(itm);

                }
                objSql.CloseConnection();
            }
            else
            {
                MessageBox.Show("Ве молам изберете корисничко име кој сакате да го пребарате");
            }
        }

        private void btnDodeli_Click(object sender, EventArgs e)
        {
            if (dodeliVraboteni.Text != "" && dodeliSd.Text != "" && dodeliPricina.Text != "")
            {
                Insert objInsert = new Insert();
                Update objUpdate = new Update();
                bool daliIma = false;
                int vnesenBroj = 0;
                int momentalnaSostojba = 0;
                bool daliEbroj1 = Int32.TryParse(dodeliSd.Text, out vnesenBroj);
                if (daliEbroj1)
                {
                    try
                    {
                        string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                        SQLManager objSql = new SQLManager(connectionString);
                        SqlDataReader sqlite_datareader = objSql.SelectFrom("Slobodni_denovi WHERE korisnicko_ime_slobodni_denovi='" + dodeliVraboteni.Text + "'");
                        if (sqlite_datareader.HasRows)
                        {
                            daliIma = true;
                            while (sqlite_datareader.Read())
                            {
                                momentalnaSostojba = sqlite_datareader.GetInt32(1);
                            }
                            momentalnaSostojba += vnesenBroj;
                        }
                        objSql.CloseConnection();

                        if (daliIma == true)
                        {
                            objUpdate.UpdateSlobodniDenovi(dodeliVraboteni.Text, momentalnaSostojba.ToString(), "Последна промена: додадени се " + vnesenBroj + " слободни денови");
                        }
                        else
                        {
                            objInsert.InsertSlobodniDenovi(dodeliVraboteni.Text, vnesenBroj.ToString(), "Додадени се " + vnesenBroj + " слободни денови");
                        }
                        objInsert.InsertDodeluvanjeSlobodniDenovi(dodeliVraboteni.Text, vnesenBroj.ToString(), dodeliPricina.Text, dodeliZabeleshka.Text);

                        string imnjaKoloni1 = "korisnicko_ime,ime,prezime,broj_slobodni_denovi,datum_slobodni_denovi,zabeleshka_slobodni_denovi";
                        string tableName1 = "Slobodni_denovi inner join Vraboteni on Slobodni_denovi.korisnicko_ime_slobodni_denovi=Vraboteni.korisnicko_ime";
                        lvMomentalnaSostojba.Items.Clear();
                        SqlDataReader sqlite_datareader_1 = objSql.SelectFields(imnjaKoloni1, tableName1);
                        while (sqlite_datareader_1.Read())
                        {
                            string[] arr = new string[6];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader_1.GetValue(0).ToString();
                            arr[1] = sqlite_datareader_1.GetValue(1).ToString();
                            arr[2] = sqlite_datareader_1.GetValue(2).ToString();
                            arr[3] = sqlite_datareader_1.GetValue(3).ToString();
                            arr[4] = sqlite_datareader_1.GetDateTime(4).ToString("yyyy-MM-dd");
                            arr[5] = sqlite_datareader_1.GetValue(5).ToString();

                            itm = new ListViewItem(arr);
                            lvMomentalnaSostojba.Items.Add(itm);

                        }
                        objSql.CloseConnection();

                        string imnjaKoloni_2 = "korisnicko_ime,ime,prezime,broj_dodeluvanje_slobodni_denovi,datum_dodeluvanje_slobodni_denovi,pricina_dodeluvanje_slobodni_denovi,zabeleshka_dodeluvanje_slobodni_denovi,korisnicko_ime_vnesuvanje";
                        string tableName_2 = "Dodeluvanje_slobodni_denovi inner join Vraboteni ON Dodeluvanje_slobodni_denovi.korisnicko_ime_dodeluvanje_slobodni_denovi=Vraboteni.korisnicko_ime order by datum_dodeluvanje_slobodni_denovi";
                        lvDodeleniDenovi.Items.Clear();
                        SqlDataReader sqlite_datareader_2 = objSql.SelectFields(imnjaKoloni_2, tableName_2);
                        while (sqlite_datareader_2.Read())
                        {
                            string[] arr = new string[8];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader_2.GetValue(0).ToString();
                            arr[1] = sqlite_datareader_2.GetValue(1).ToString();
                            arr[2] = sqlite_datareader_2.GetValue(2).ToString();
                            arr[3] = sqlite_datareader_2.GetValue(3).ToString();
                            arr[4] = sqlite_datareader_2.GetDateTime(4).ToString("yyyy-MM-dd");
                            arr[5] = sqlite_datareader_2.GetValue(5).ToString();
                            arr[6] = sqlite_datareader_2.GetValue(6).ToString();
                            arr[7] = sqlite_datareader_2.GetValue(7).ToString();

                            itm = new ListViewItem(arr);
                            lvDodeleniDenovi.Items.Add(itm);

                        }
                        objSql.CloseConnection();
                    }
                    catch
                    {
                        MessageBox.Show("Има проблем со доделувањето на слободни дена !!!");
                    }
                }
                else
                {
                    MessageBox.Show("Дозволени се само бројки !!!");
                }

            }
            else
            {
                MessageBox.Show("Ве молам изберете корисничко име, внесете број на денови и изберете намена на доделување на денови!!!");
            }
        }

        private void lvMomentalnaSostojba_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvDodeleniDenovi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnIskoristiSd_Click(object sender, EventArgs e)
        {
            if (iskoristiSdVraboteni.Text != "" && iskoristiSdBroj.Text != "" && iskoristiSdBrojNamena.Text != "" && datumOd.Text != "" && datumDo.Text != "" && datumVrakjanje.Text != "")
            {
                try
                {

                    string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                    SQLManager objSql = new SQLManager(connectionString);
                    Insert objInsert = new Insert();
                    Update objUpdate = new Update();

                    if (DateTime.TryParse(datumOd.Text, out DateTime datumPocetok) && DateTime.TryParse(datumDo.Text, out DateTime datumKraj) && DateTime.TryParse(datumVrakjanje.Text, out DateTime datumVrakjanjeNaRabota))
                    {
                        string pocetok, zavrshetok, vrakjanje;
                        pocetok = datumPocetok.ToString("yyyy-MM-dd");
                        zavrshetok = datumKraj.ToString("yyyy-MM-dd");
                        vrakjanje = datumVrakjanjeNaRabota.ToString("yyyy-MM-dd");
                        bool proveriDaliKoristiDen=false;   

                        SqlDataReader periodKoristeniDenovi = objSql.SelectFrom("Iskoristeni_denovi WHERE korisnicko_ime_iskoristeni_denovi='" + iskoristiSdVraboteni.Text + "' AND pocetok_iskoristeni_denovi BETWEEN  '" + pocetok + "' AND '" + zavrshetok + "'");
                        if (periodKoristeniDenovi.HasRows)
                        {
                            proveriDaliKoristiDen = true;
                        }
                        objSql.CloseConnection();

                        SqlDataReader periodKoristeniDenoviPoKorisnik = objSql.SelectFrom("Iskoristeni_denovi WHERE korisnicko_ime_iskoristeni_denovi='" + iskoristiSdVraboteni.Text + "'" );
                        if (periodKoristeniDenoviPoKorisnik.HasRows)
                        {
                            while (periodKoristeniDenoviPoKorisnik.Read())
                            {
                                if (periodKoristeniDenoviPoKorisnik.GetDateTime(3) >= datumPocetok)
                                {
                                    proveriDaliKoristiDen = true;
                                }
                            }
                        }
                        objSql.CloseConnection();

                        if (datumPocetok > datumKraj || datumVrakjanjeNaRabota <= datumPocetok || datumVrakjanjeNaRabota <= datumKraj)
                        {
                            MessageBox.Show("Внесете правилен датум !!!");
                        }
                        else if (proveriDaliKoristiDen == true)
                        {
                            MessageBox.Show("Вработениот користи ден во тој период !!!");
                        }
                        else
                        {
                                bool daliIma = false;
                                int vnesenBroj = 0;
                                int momentalnaSostojba = 0;

                                bool daliEbroj1 = Int32.TryParse(iskoristiSdBroj.Text, out vnesenBroj);
                                if (daliEbroj1)
                                {

                                        SqlDataReader sqlite_datareader = objSql.SelectFrom("Slobodni_denovi WHERE korisnicko_ime_slobodni_denovi='" + iskoristiSdVraboteni.Text + "'");
                                        if (sqlite_datareader.HasRows)
                                        {
                                            daliIma = true;
                                            while (sqlite_datareader.Read())
                                            {
                                                momentalnaSostojba = sqlite_datareader.GetInt32(1);
                                            }
                                        }
                                        objSql.CloseConnection();

                                        momentalnaSostojba = momentalnaSostojba - vnesenBroj;
                                        if (daliIma == true)
                                        {
                                            objUpdate.UpdateSlobodniDenovi(iskoristiSdVraboteni.Text, momentalnaSostojba.ToString(), "Последна промена: искористени се " + vnesenBroj + " слободни денови");
                                        }
                                        else
                                        {
                                            objInsert.InsertSlobodniDenovi(iskoristiSdVraboteni.Text, momentalnaSostojba.ToString(), "Искористени се " + vnesenBroj + " слободни денови");
                                        }

                                        objInsert.InsertIskoristeniSlobodniDenovi(iskoristiSdVraboteni.Text, pocetok, zavrshetok, vrakjanje, vnesenBroj.ToString(), iskoristiSdBrojNamena.Text, iskoristiSdZabeleshka.Text);

                                        string imnjaKoloni1 = "korisnicko_ime,ime,prezime,broj_slobodni_denovi,datum_slobodni_denovi,zabeleshka_slobodni_denovi";
                                        string tableName1 = "Slobodni_denovi inner join Vraboteni on Slobodni_denovi.korisnicko_ime_slobodni_denovi=Vraboteni.korisnicko_ime";
                                        lvMomentalnaSostojba.Items.Clear();
                                        SqlDataReader sqlite_datareader_1 = objSql.SelectFields(imnjaKoloni1, tableName1);
                                        while (sqlite_datareader_1.Read())
                                        {
                                            string[] arr = new string[6];
                                            ListViewItem itm;

                                            arr[0] = sqlite_datareader_1.GetValue(0).ToString();
                                            arr[1] = sqlite_datareader_1.GetValue(1).ToString();
                                            arr[2] = sqlite_datareader_1.GetValue(2).ToString();
                                            arr[3] = sqlite_datareader_1.GetValue(3).ToString();
                                            arr[4] = sqlite_datareader_1.GetDateTime(4).ToString("yyyy-MM-dd");
                                            arr[5] = sqlite_datareader_1.GetValue(5).ToString();

                                            itm = new ListViewItem(arr);
                                            lvMomentalnaSostojba.Items.Add(itm);

                                        }
                                        objSql.CloseConnection();

                                        string imnjaKoloni_3 = "korisnicko_ime,ime,prezime,pocetok_iskoristeni_denovi,zavrshetok_iskoristeni_denovi,vrakjanje_iskoristeni_denovi,vkupno_denovi_iskoristeni_denovi,pricina_iskoristeni_denovi, kreirano_iskoristeni_denovi, zabeleshka_iskoristeni_denovi,korisnicko_ime_kreiranje";
                                        string tableName_3 = "Iskoristeni_denovi inner Join Vraboteni on Iskoristeni_denovi.korisnicko_ime_iskoristeni_denovi=Vraboteni.korisnicko_ime order by kreirano_iskoristeni_denovi";
                                        lvIskoristeniDenovi.Items.Clear();
                                        SqlDataReader sqlite_datareader_3 = objSql.SelectFields(imnjaKoloni_3, tableName_3);
                                        while (sqlite_datareader_3.Read())
                                        {
                                            string[] arr = new string[11];
                                            ListViewItem itm;

                                            arr[0] = sqlite_datareader_3.GetValue(0).ToString();
                                            arr[1] = sqlite_datareader_3.GetValue(1).ToString();
                                            arr[2] = sqlite_datareader_3.GetValue(2).ToString();
                                            arr[3] = sqlite_datareader_3.GetDateTime(3).ToString("yyyy-MM-dd");
                                            arr[4] = sqlite_datareader_3.GetDateTime(4).ToString("yyyy-MM-dd");
                                            arr[5] = sqlite_datareader_3.GetDateTime(5).ToString("yyyy-MM-dd");
                                            arr[6] = sqlite_datareader_3.GetValue(6).ToString();
                                            arr[7] = sqlite_datareader_3.GetValue(7).ToString();
                                            arr[8] = sqlite_datareader_3.GetDateTime(8).ToString("yyyy-MM-dd");
                                            arr[9] = sqlite_datareader_3.GetValue(9).ToString();
                                            arr[10] = sqlite_datareader_3.GetValue(10).ToString();

                                            itm = new ListViewItem(arr);
                                            lvIskoristeniDenovi.Items.Add(itm);

                                        }

                                        objSql.CloseConnection();

                                }
                                else
                                {
                                    MessageBox.Show("Дозволени се само бројки !!!");
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Има проблем со внесувањето на датуми !!!");
                    }
                }
                catch
                {
                    MessageBox.Show("Има проблем со користењето на денови !!!");
                }
            }
            else
            {
                MessageBox.Show("Ве молам изберете корисничко име, внесете број на денови и изберете намена на користење на денови !!!");
            }
        }

        private void iskoristiSdBrojNamena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(iskoristiSdBrojNamena.Text != "Приватни намени")
            {
                iskoristiSdBroj.Text = "0";
                iskoristiSdBroj.Enabled = false;
            }
            else
            {
                iskoristiSdBroj.Text = "";
                iskoristiSdBroj.Enabled = true;
            }
        }

        private void btnOsvezi_Click(object sender, EventArgs e)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
          
            string imnjaKoloni1 = "korisnicko_ime,ime,prezime,broj_slobodni_denovi,datum_slobodni_denovi,zabeleshka_slobodni_denovi";
            string tableName1 = "Slobodni_denovi inner join Vraboteni on Slobodni_denovi.korisnicko_ime_slobodni_denovi=Vraboteni.korisnicko_ime";
            lvMomentalnaSostojba.Items.Clear();
            SqlDataReader sqlite_datareader_1 = objSql.SelectFields(imnjaKoloni1, tableName1);
            while (sqlite_datareader_1.Read())
            {
                string[] arr = new string[6];
                ListViewItem itm;

                arr[0] = sqlite_datareader_1.GetValue(0).ToString();
                arr[1] = sqlite_datareader_1.GetValue(1).ToString();
                arr[2] = sqlite_datareader_1.GetValue(2).ToString();
                arr[3] = sqlite_datareader_1.GetValue(3).ToString();
                arr[4] = sqlite_datareader_1.GetDateTime(4).ToString("yyyy-MM-dd");
                arr[5] = sqlite_datareader_1.GetValue(5).ToString();

                itm = new ListViewItem(arr);
                lvMomentalnaSostojba.Items.Add(itm);

            }
            objSql.CloseConnection();

            string imnjaKoloni_2 = "korisnicko_ime,ime,prezime,broj_dodeluvanje_slobodni_denovi,datum_dodeluvanje_slobodni_denovi,pricina_dodeluvanje_slobodni_denovi,zabeleshka_dodeluvanje_slobodni_denovi,korisnicko_ime_vnesuvanje";
            string tableName_2 = "Dodeluvanje_slobodni_denovi inner join Vraboteni ON Dodeluvanje_slobodni_denovi.korisnicko_ime_dodeluvanje_slobodni_denovi=Vraboteni.korisnicko_ime order by datum_dodeluvanje_slobodni_denovi";
            lvDodeleniDenovi.Items.Clear();
            SqlDataReader sqlite_datareader_2 = objSql.SelectFields(imnjaKoloni_2, tableName_2);
            while (sqlite_datareader_2.Read())
            {
                string[] arr = new string[8];
                ListViewItem itm;

                arr[0] = sqlite_datareader_2.GetValue(0).ToString();
                arr[1] = sqlite_datareader_2.GetValue(1).ToString();
                arr[2] = sqlite_datareader_2.GetValue(2).ToString();
                arr[3] = sqlite_datareader_2.GetValue(3).ToString();
                arr[4] = sqlite_datareader_2.GetDateTime(4).ToString("yyyy-MM-dd");
                arr[5] = sqlite_datareader_2.GetValue(5).ToString();
                arr[6] = sqlite_datareader_2.GetValue(6).ToString();
                arr[7] = sqlite_datareader_2.GetValue(7).ToString();

                itm = new ListViewItem(arr);
                lvDodeleniDenovi.Items.Add(itm);

            }
            objSql.CloseConnection();

            string imnjaKoloni_3 = "korisnicko_ime,ime,prezime,pocetok_iskoristeni_denovi,zavrshetok_iskoristeni_denovi,vrakjanje_iskoristeni_denovi,vkupno_denovi_iskoristeni_denovi,pricina_iskoristeni_denovi, kreirano_iskoristeni_denovi, zabeleshka_iskoristeni_denovi,korisnicko_ime_kreiranje";
            string tableName_3 = "Iskoristeni_denovi inner Join Vraboteni on Iskoristeni_denovi.korisnicko_ime_iskoristeni_denovi=Vraboteni.korisnicko_ime order by kreirano_iskoristeni_denovi";
            lvIskoristeniDenovi.Items.Clear();
            SqlDataReader sqlite_datareader_3 = objSql.SelectFields(imnjaKoloni_3, tableName_3);
            while (sqlite_datareader_3.Read())
            {
                string[] arr = new string[11];
                ListViewItem itm;

                arr[0] = sqlite_datareader_3.GetValue(0).ToString();
                arr[1] = sqlite_datareader_3.GetValue(1).ToString();
                arr[2] = sqlite_datareader_3.GetValue(2).ToString();
                arr[3] = sqlite_datareader_3.GetDateTime(3).ToString("yyyy-MM-dd");
                arr[4] = sqlite_datareader_3.GetDateTime(4).ToString("yyyy-MM-dd");
                arr[5] = sqlite_datareader_3.GetDateTime(5).ToString("yyyy-MM-dd");
                arr[6] = sqlite_datareader_3.GetValue(6).ToString();
                arr[7] = sqlite_datareader_3.GetValue(7).ToString();
                arr[8] = sqlite_datareader_3.GetDateTime(8).ToString("yyyy-MM-dd");
                arr[9] = sqlite_datareader_3.GetValue(9).ToString();
                arr[10] = sqlite_datareader_3.GetValue(10).ToString();

                itm = new ListViewItem(arr);
                lvIskoristeniDenovi.Items.Add(itm);

            }
            objSql.CloseConnection();
        }

        private void Denovi_Load(object sender, EventArgs e)
        {

        }

        private void groupIskoristeniDena_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
