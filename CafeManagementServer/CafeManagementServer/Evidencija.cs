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

namespace CafeManagementServer
{
    public partial class Evidencija : Form
    {
        public Evidencija()
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

            lvEvidencijaSite.View = View.Details;
            lvEvidencijaSite.GridLines = true;
            lvEvidencijaSite.FullRowSelect = true;
            lvEvidencijaSite.Columns.Add("Датум", 200);
            lvEvidencijaSite.Columns.Add("Време најава", 200);
            lvEvidencijaSite.Columns.Add("Време одјава", 200);
            lvEvidencijaSite.Columns.Add("Пресметка на работно време во часови", 200);
            lvEvidencijaSite.Columns.Add("Корисничко име", 200);
            lvEvidencijaSite.Columns.Add("Име на вработен", 200);
            lvEvidencijaSite.Columns.Add("Презиме на вработен", 200);
            lvEvidencijaSite.Columns.Add("Позиција на вработен", 200);
            lvEvidencijaSite.Columns.Add("Забелешка", 200);

            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string tableName = "Vraboteni";
            SqlDataReader sqlite_datareader = objSql.SelectFrom(tableName);

            korisnickoIme.Items.Add("Сите вработени");
            while (sqlite_datareader.Read())
            {
                korisnickoIme.Items.Add(sqlite_datareader.GetString(0));    //Go polnam combobox so korisnicki iminja 
            }
            objSql.CloseConnection();

            string imnjaKoloni = "datum,vreme_najava,vreme_odjava,korisnicko_ime,ime,prezime,pozicija,zabeleshka_evidencija";
            string tableName1 = "Evidencija_rabotno_vreme inner join Vraboteni on Evidencija_rabotno_vreme.korisnicko_ime_evidencija=Vraboteni.korisnicko_ime ORDER BY id_evidencija_rabotno_vreme desc";
            lvEvidencijaSite.Items.Clear();
            SqlDataReader sqlite_datareader_site_dena = objSql.SelectFields(imnjaKoloni, tableName1);
            while (sqlite_datareader_site_dena.Read())
            {
                string vremeOdjava = "";
                if(sqlite_datareader_site_dena.GetValue(2).ToString() != "01.1.1900 00:00:00")
                {
                    vremeOdjava = sqlite_datareader_site_dena.GetValue(2).ToString();
                }
                string[] arr = new string[9];
                ListViewItem itm;

                arr[0] = sqlite_datareader_site_dena.GetDateTime(0).ToString("yyyy-MM-dd");
                arr[1] = sqlite_datareader_site_dena.GetValue(1).ToString();
                arr[2] = vremeOdjava;
                if (DateTime.TryParse(arr[1], out DateTime startDate) && DateTime.TryParse(arr[2], out DateTime endDate))
                {

                    TimeSpan timeDifference = endDate - startDate;
                    int hoursDifference = timeDifference.Hours;
                    int minutesDifference = timeDifference.Minutes;

                    string timeDifferenceStr = hoursDifference+" час и "+minutesDifference+" минути";

                    if (timeDifferenceStr[0] == '-')
                    {
                        arr[3] = "";
                    }
                    else
                    {
                        arr[3] = timeDifferenceStr;
                    }
            
                };
                arr[4] = sqlite_datareader_site_dena.GetValue(3).ToString();
                arr[5] = sqlite_datareader_site_dena.GetValue(4).ToString();
                arr[6] = sqlite_datareader_site_dena.GetValue(5).ToString();
                arr[7] = sqlite_datareader_site_dena.GetValue(6).ToString();
                arr[8] = sqlite_datareader_site_dena.GetValue(7).ToString();

                itm = new ListViewItem(arr);
                lvEvidencijaSite.Items.Add(itm);

            }
            objSql.CloseConnection();
            
            string denes = DateTime.Today.ToString("yyyy-MM-dd");

            string tableNameDenes = "Evidencija_rabotno_vreme inner join Vraboteni on Evidencija_rabotno_vreme.korisnicko_ime_evidencija=Vraboteni.korisnicko_ime where datum='"+denes+"' ORDER BY id_evidencija_rabotno_vreme desc";
            lvEvidencijaDenes.Items.Clear();
            SqlDataReader sqlite_datareader_denes = objSql.SelectFields(imnjaKoloni, tableNameDenes);
            while (sqlite_datareader_denes.Read())
            {
                string vremeOdjava = "";
                if (sqlite_datareader_denes.GetValue(2).ToString() != "01.1.1900 00:00:00")
                {
                    vremeOdjava = sqlite_datareader_denes.GetValue(2).ToString();
                }
                string[] arr = new string[9];
                ListViewItem itm;

                arr[0] = sqlite_datareader_denes.GetDateTime(0).ToString("yyyy-MM-dd");
                arr[1] = sqlite_datareader_denes.GetValue(1).ToString();
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
                }

                arr[4] = sqlite_datareader_denes.GetValue(3).ToString();
                arr[5] = sqlite_datareader_denes.GetValue(4).ToString();
                arr[6] = sqlite_datareader_denes.GetValue(5).ToString();
                arr[7] = sqlite_datareader_denes.GetValue(6).ToString();
                arr[8] = sqlite_datareader_denes.GetValue(7).ToString();

                itm = new ListViewItem(arr);
                lvEvidencijaDenes.Items.Add(itm);

            }
            objSql.CloseConnection();
        }

        private void btnPrebaraj_Click(object sender, EventArgs e)
        {
            if(korisnickoIme.Text != "")
            {
                try
                {

                    if (DateTime.TryParse(datumOd.Text, out DateTime datumPocetok) && DateTime.TryParse(datumDo.Text, out DateTime datumKraj))
                    {
                        if (datumPocetok <= datumKraj)
                        {
                            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                            SQLManager objSql = new SQLManager(connectionString);
                            string imnjaKoloni = "datum,vreme_najava,vreme_odjava,korisnicko_ime,ime,prezime,pozicija,zabeleshka_evidencija";
                            string tableName1 = "";
                            if (korisnickoIme.Text != "Сите вработени")
                            {
                                 tableName1 = "Evidencija_rabotno_vreme inner join Vraboteni on Evidencija_rabotno_vreme.korisnicko_ime_evidencija=Vraboteni.korisnicko_ime where korisnicko_ime='" + korisnickoIme.Text + "' AND datum BETWEEN '" + datumPocetok.ToString("yyyy-MM-dd") + " 00:00:00' AND '" + datumKraj.ToString("yyyy-MM-dd") + " 23:59:59' ORDER BY id_evidencija_rabotno_vreme desc";        
                            }
                            else
                            {
                                 tableName1 = "Evidencija_rabotno_vreme inner join Vraboteni on Evidencija_rabotno_vreme.korisnicko_ime_evidencija=Vraboteni.korisnicko_ime where datum BETWEEN '" + datumPocetok.ToString("yyyy-MM-dd") + " 00:00:00' AND '" + datumKraj.ToString("yyyy-MM-dd") + " 23:59:59' ORDER BY id_evidencija_rabotno_vreme desc";
                            }
                            lvEvidencijaSite.Items.Clear();
                            SqlDataReader sqlite_datareader_site_dena = objSql.SelectFields(imnjaKoloni, tableName1);
                            while (sqlite_datareader_site_dena.Read())
                            {
                                string vremeOdjava = "";
                                if (sqlite_datareader_site_dena.GetValue(2).ToString() != "01.1.1900 00:00:00")
                                {
                                    vremeOdjava = sqlite_datareader_site_dena.GetValue(2).ToString();
                                }
                                string[] arr = new string[9];
                                ListViewItem itm;

                                arr[0] = sqlite_datareader_site_dena.GetDateTime(0).ToString("yyyy-MM-dd");
                                arr[1] = sqlite_datareader_site_dena.GetValue(1).ToString();
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

                                }
                                arr[4] = sqlite_datareader_site_dena.GetValue(3).ToString();
                                arr[5] = sqlite_datareader_site_dena.GetValue(4).ToString();
                                arr[6] = sqlite_datareader_site_dena.GetValue(5).ToString();
                                arr[7] = sqlite_datareader_site_dena.GetValue(6).ToString();
                                arr[8] = sqlite_datareader_site_dena.GetValue(7).ToString();

                                itm = new ListViewItem(arr);
                                lvEvidencijaSite.Items.Add(itm);

                            }
                            objSql.CloseConnection();
                        }
                        else
                        {
                            MessageBox.Show("Ве молам внесете правилен датум !!!");
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Има проблем со пребарувањето !!!");
                }
            }
            else
            {
                MessageBox.Show("Задолжително изберете корисничко име за пребарување !!!");
            }
        }

        private void Evidencija_Load(object sender, EventArgs e)
        {

        }
    }
}
