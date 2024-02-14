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
    internal class Delete
    {
        private Excel.Application ExcelObj = null;
        public void DeleteKompanii(string id,string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string tableName = "Kompanii";
            string uslov = "id_kompanija=" + id;
            objSql.Delete(tableName,uslov);
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

        public void DeleteProizvodi(string id,string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string tableName = "Proizvodi";
            string uslov = "sifra_proizvodi=" + id;
            objSql.Delete(tableName, uslov);
            string imnjaKoloni = "sifra_proizvodi,ime_proizvodi,tip_proizvodi,kolicina_proizvodi,cena_proizvodi,Kompanii.ime_kompanija as ime_na_kompanija";
            string tableNameSelect = "Proizvodi INNER JOIN Kompanii ON kompanija_proizvodi_id=id_kompanija";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableNameSelect);
            try
            {
                Assets objAssets = new Assets();
                exportPath = objAssets.NapraviExcel(reader, exportPath, objSql, "Proizvodi");

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

        public void DeleteSmetki(string id)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string tableName = "Smetki";
            string uslov = "id_smetki=" + id;
            objSql.Delete(tableName, uslov);
            }
            catch (Exception ex)
            {

            }
        }

        public void DeletePlateniSmetki(string id)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);

                string tableName = "Plateni_smetki";
                string uslov = "smetka_id=" + id;
                objSql.Delete(tableName, uslov);
            }
            catch (Exception ex)
            {

            }
        }

        
         public void DeleteNaracki(string vreme,string den,string kelner, string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string uslov = "vreme_naracka='" + vreme+"'";
            objSql.Delete("Naracki", uslov);
            string imnjaKoloni = "id_naracka,korisnicko_ime_naracki,vreme_naracka,promet";
            string tableName = "Naracki WHERE vreme_naracka BETWEEN '" + den + " 00:00:00:000' AND '" + den + " 23:59:59.000' and korisnicko_ime_naracki='" + kelner + "' order by vreme_naracka desc";
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

            }
        }

        public void DeleteNarackiSank(string vreme, string den, string kelner, string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string uslov = "vreme_naracka_sank='" + vreme + "'";
            objSql.Delete("Naracki_sank", uslov);
            string imnjaKoloni = "vreme_naracka_sank,korisnicko_ime_naracki_sank,ime_proizvodi,kolicina_naracka_sank,cena_naracka_sank,cena_vkupna_naracka_sank";
            string tableName = "Naracki_sank inner join Proizvodi on sifra_naracka_sank=sifra_proizvodi WHERE vreme_naracka_sank BETWEEN '" + den + " 00:00:00:000' AND '" + den + " 23:59:59.000' and korisnicko_ime_naracki_sank='" + kelner + "' order by vreme_naracka_sank desc ";
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

            }
        }
    }
}

