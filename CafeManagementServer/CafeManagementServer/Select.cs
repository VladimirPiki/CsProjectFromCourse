using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CafeManagementServer.Database;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CafeManagementServer
{
    internal class Select
    {
        private Excel.Application ExcelObj = null;
        public void selectKompanii(string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string tableName = "Kompanii";
            SqlDataReader reader = objSql.SelectFrom(tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "KompaniiVnesi");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void selectKompaniiAktivna(string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string tableName = "Kompanii where status='aktivna'";
            SqlDataReader reader = objSql.SelectFrom(tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "KompaniiVnesi");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }

                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Има проблем со испраќањето на фајлот за внесување на комапниите !!!");
            }
        }
        public void selectProizvodi(string porakaPort)//(port:1234-kelner)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string imnjaKoloni = "sifra_proizvodi,ime_proizvodi,tip_proizvodi,kolicina_proizvodi,cena_proizvodi,Kompanii.ime_kompanija as ime_na_kompanija,proizvodi_status";
            string tableName = "Proizvodi INNER JOIN Kompanii ON kompanija_proizvodi_id=id_kompanija";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni,tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "selectProizvodi");

                if (exportPath != "")
                {
                    int port;
                    bool porta=Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath,port);
                      }

                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Има проблем со испраќањето на фајлот за производите !!!");
            }
        }

        public void selectProizvodiAktivni(string porakaPort)//(port:1234-kelner)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string imnjaKoloni = "sifra_proizvodi,ime_proizvodi,tip_proizvodi,kolicina_proizvodi,cena_proizvodi,Kompanii.ime_kompanija as ime_na_kompanija";
            string tableName = "Proizvodi INNER JOIN Kompanii ON kompanija_proizvodi_id=id_kompanija where proizvodi_status='Активен'";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "selectProizvodi");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }

                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Има проблем со испраќањето на фајлот за производите !!!");
            }
        }

        public void selectProizvodiWhere(string where,string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string imnjaKoloni = "sifra_proizvodi,ime_proizvodi,tip_proizvodi,kolicina_proizvodi,cena_proizvodi,Kompanii.ime_kompanija as ime_na_kompanija";
            string tableName = "Proizvodi INNER JOIN Kompanii ON kompanija_proizvodi_id=id_kompanija "+where;
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "selectProizvodiWhere");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }

                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Има проблем со испраќањето на фајлот за производите !!!");
            }
        }

        public void SelectNaracki(string kelner,string porakaPort)//kelner (port:1235-kelner kelnerNarackiSite)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            DateTime currentDate = DateTime.Now;
            string vreme = currentDate.ToString("yyyy-MM-dd");
            string exportPath = "";
            string imnjaKoloni = "id_naracka,korisnicko_ime_naracki,vreme_naracka,promet";
            string tableName = "Naracki WHERE vreme_naracka BETWEEN '" + vreme + " 00:00:00:000' AND '" + vreme + " 23:59:59.000' and korisnicko_ime_naracki='"+kelner+"' order by vreme_naracka desc";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "SelectNaracki");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Има проблем со испраќањето на фајлот за нарачките на келнерот !!!");
            }
        }

        public void SelectNarackiKelner(string kelner,string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            DateTime currentDate = DateTime.Now;
            string vreme = currentDate.ToString("yyyy-MM-dd");
            string exportPath = "";
            string imnjaKoloni = "vreme_naracka_sank,korisnicko_ime_naracki_sank,ime_proizvodi,kolicina_naracka_sank,cena_naracka_sank,cena_vkupna_naracka_sank";
            string tableName = "Naracki_sank inner join Proizvodi on sifra_naracka_sank=sifra_proizvodi WHERE vreme_naracka_sank BETWEEN '" + vreme + " 00:00:00:000' AND '" + vreme + " 23:59:59.000' and korisnicko_ime_naracki_sank='"+kelner+"' order by vreme_naracka_sank desc ";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "SelectNarackiKelner");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Има проблем со испраќањето на фајлот за нарачките во шанкот !!!");
            }
        }


        public void SelectNarackaSank(string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            DateTime currentDate = DateTime.Now;
            string vreme = currentDate.ToString("yyyy-MM-dd");
            string exportPath = "";
            string imnjaKoloni = "vreme_naracka_sank,korisnicko_ime_naracki_sank,ime_proizvodi,kolicina_naracka_sank,cena_naracka_sank,cena_vkupna_naracka_sank,sifra_proizvodi";
            string tableName = "Naracki_sank inner join Proizvodi on sifra_naracka_sank=sifra_proizvodi WHERE vreme_naracka_sank BETWEEN '"+vreme+ " 00:00:00:000' AND '"+vreme+ " 23:59:59.000' order by vreme_naracka_sank desc ";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "selectNarackaSank");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Има проблем со испраќањето на фајлот за нарачките во шанкот !!!");
            }
        }


        public void SelectNarackiVkupenPromet(string kelner)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            DateTime currentDate = DateTime.Now;
            string vreme = currentDate.ToString("yyyy-MM-dd");
            string imnjaKoloni = "SUM(promet) as prometZaDen";
            string tableName = "Naracki WHERE korisnicko_ime_naracki='"+kelner+"' and vreme_naracka BETWEEN '" + vreme + " 00:00:00.000' AND '" + vreme + " 23:59:59.000'";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                string porakaNazad = "vkupenPromet";
                while (reader.Read())
                {
                    if (reader.IsDBNull(0))
                    {
                        porakaNazad = porakaNazad + "#0";
                    }
                    else
                    {
                        porakaNazad = porakaNazad + "#" + reader[0].ToString();
                    }
                    
                }
                objSql.CloseConnection();

                Komunikacija objKomunikacija = new Komunikacija();

                int port = 8089;
                objKomunikacija.IspratiMessageSoPort(port, porakaNazad);

            }
            catch (Exception ex)
            {
               // MessageBox.Show("Има проблем со испраќањето на фајлот за вкупниот промет !!!");
            }
        }

        public void SelectFakturi(string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string exportPath = "";
            string imnjaKoloni = "id_fakturi,datum_fakturi,vkupna_suma,korisnicko_ime,ime,prezime,pozicija,ime_kompanija,transakciska_smetka,status_fakturi,zabelshka_fakturi";
            string tableName = "Fakturi INNER JOIN Vraboteni on Fakturi.korisnicko_ime_fakturi=Vraboteni.korisnicko_ime INNER JOIN Kompanii ON Fakturi.id_kompanija_fakturi=Kompanii.id_kompanija WHERE Kompanii.status='aktivna' and status_fakturi='ispratena' ";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "selectFakturi");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Има проблем со испраќањето на фајлот за фактури !!!");
            }
        }

        public void SelectEvidencijaRabotnici(string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            DateTime currentDate = DateTime.Now;
            string vreme = currentDate.ToString("yyyy-MM-dd");
            string exportPath = "";
            string imnjaKoloni = "datum,vreme_najava,vreme_odjava,korisnicko_ime,ime,prezime,pozicija,zabeleshka_evidencija";
            string tableName = "Evidencija_rabotno_vreme inner join Vraboteni on Evidencija_rabotno_vreme.korisnicko_ime_evidencija=Vraboteni.korisnicko_ime where datum='"+ vreme+"' and (pozicija='kelner' or pozicija='sanker') ";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "SelectEvidencijaRabotnici");

                if (exportPath != "")
                {

                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("Има проблем со испраќањето на фајлот за евиденција на работниците !!!");
            }
        }

        public void SelectVkupenPrometKelneri(string porakaPort)//kelneri
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            DateTime currentDate = DateTime.Now;
            string vreme = currentDate.ToString("yyyy-MM-dd");
            string exportPath = "";
            string imnjaKoloni = "suma_na_priliv,vreme_na_priliv,korisnicko_ime,ime,prezime";
            string tableName = "Priliv inner join Vraboteni on Priliv.korisnicko_ime_priliv=Vraboteni.korisnicko_ime where pozicija='kelner' and vreme_na_priliv between '" + vreme + " 00:00:00' and '" + vreme + " 23:59:59'";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "SelectVkupenPrometKelneri");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Има проблем со испраќањето на фајлот за вкупниот промет на келнерите !!!");
            }
        }

        public void SelectPredaenaSostojbaSank(string porakaPort)//predaena sostojba na sank
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            //  objSql = new SQLManager(connectionString);

            string exportPath = "";
            string imnjaKoloni = "datum_predaena_sostojba,korisnicko_ime_predaena_sostojba,ime,prezime,zabeleshka_predaena_sostojba";
            string tableName = "Predaena_sostojba_sank inner join Vraboteni on Predaena_sostojba_sank.korisnicko_ime_predaena_sostojba=Vraboteni.korisnicko_ime order by datum_predaena_sostojba desc";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "SelectPredaenaSostojbaSank");

                if (exportPath != "")
                {
                    int port;
                    bool porta = Int32.TryParse(porakaPort, out port);
                    if (porta)
                    {
                        Komunikacija objKomunikacija = new Komunikacija();
                        objKomunikacija.IspratiExcel(exportPath, port);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Има проблем со испраќањето на фајлот за вкупниот промет на келнерите !!!");
            }
        }
        

    }
}
