using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CafeManagementServer.Database;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.IO;
using Org.BouncyCastle.Asn1.Cms;

namespace CafeManagementServer
{
    internal class Update
    {
        private Excel.Application ExcelObj = null;
        public void UpdateKompanii(string ime_kompanija, string transakciska_smetka, string datum_kompanija, string status,string id,string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string tableName = "Kompanii";

            string vrednost="ime_kompanija='"+ ime_kompanija+"' ,transakciska_smetka='"+transakciska_smetka+"',datum_kompanija='"+datum_kompanija+"',status='"+status+"'";
            string uslov = "id_kompanija=" + id;
            objSql.Update(tableName, vrednost, uslov);

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

        public void UpdateProizvodi(string sifra, string ime, string tip, string kolicina, string cena,string porakaPort,string status)
        {
            Komunikacija objKomunikacija = new Komunikacija();
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
  
                string exportPath = "";
                string tableName = "Proizvodi";

                string vrednost = "ime_proizvodi='" + ime + "',tip_proizvodi='" + tip + "' ,kolicina_proizvodi=" + kolicina + ", cena_proizvodi="+cena+ ", proizvodi_status='"+status+"'";
                string uslov = "sifra_proizvodi=" + sifra;
                objSql.Update(tableName, vrednost, uslov);

                string imnjaKoloni = "sifra_proizvodi,ime_proizvodi,tip_proizvodi,kolicina_proizvodi,cena_proizvodi,Kompanii.ime_kompanija as ime_na_kompanija,proizvodi_status";
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
                            objKomunikacija.IspratiExcel(exportPath, port);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
        }

        public void UpdateFakturi(string id_fakturi, string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string tableName = "Fakturi";

            string vrednost = "status_fakturi='primena'";
            string uslov = "id_fakturi=" + id_fakturi;
            objSql.Update(tableName, vrednost, uslov);

            string imnjaKoloni = "id_fakturi,datum_fakturi,vkupna_suma,korisnicko_ime,ime,prezime,pozicija,ime_kompanija,transakciska_smetka,status_fakturi,zabelshka_fakturi";
            string tableName1 = "Fakturi INNER JOIN Vraboteni on Fakturi.korisnicko_ime_fakturi=Vraboteni.korisnicko_ime INNER JOIN Kompanii ON Fakturi.id_kompanija_fakturi=Kompanii.id_kompanija WHERE Kompanii.status='aktivna' and status_fakturi='ispratena' ";
            SqlDataReader reader = objSql.SelectFields(imnjaKoloni, tableName1);
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
            }
        }

        public void UpdateBudzet(string vreme, string prihodString,string zabeleshka)//BUDZET PRILIV
        {
            try
            {
                int budzetString = 0;
                int prihodInteger, momentalnaSostojba;

                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Budzet";
                SqlDataReader sqlite_datareader = objSql.SelectFrom(tableName);
                while (sqlite_datareader.Read())
                {
                    budzetString = sqlite_datareader.GetInt32(2);
                }
                objSql.CloseConnection();

                bool daliEBrojPrihod = Int32.TryParse(prihodString, out prihodInteger);
                if ( daliEBrojPrihod == true)
                {
                    momentalnaSostojba = budzetString + prihodInteger;
                    objSql.Update("Budzet", "vreme_na_budzet='" + vreme + "',momentalna_sostojba_budzet=" + momentalnaSostojba + ", zabeleshka_budzet='" + zabeleshka + "'", "id_budzet=1");
                }
            }
            catch 
            {

            }
        }

        public void UpdateBudzetOdliv(string vreme, string odlivString, string zabeleshka)
        {
            try
            {
                int budzetInteger = 0;
                int odlivInteger, momentalnaSostojba;

                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Budzet";
                SqlDataReader sqlite_datareader = objSql.SelectFrom(tableName);
                while (sqlite_datareader.Read())
                {
                    budzetInteger = sqlite_datareader.GetInt32(2);//Tuka se vnesva vo integer
                }
                objSql.CloseConnection();

                bool daliEBrojPrihod = Int32.TryParse(odlivString, out odlivInteger);
                if (daliEBrojPrihod == true)
                {
                    momentalnaSostojba = budzetInteger - odlivInteger;
                    objSql.Update("Budzet", "vreme_na_budzet='" + vreme + "',momentalna_sostojba_budzet=" + momentalnaSostojba + ", zabeleshka_budzet='" + zabeleshka + "'", "id_budzet=1");
                }
            }
            catch
            {
 
            }
        }

        public void UpdateSlobodniDenovi(string korisnickoIme,string momentalnaSostojba,string zabeleshkaSd)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string tableName = "Slobodni_denovi";
            objSql.Update(tableName, "broj_slobodni_denovi='"+momentalnaSostojba+"',datum_slobodni_denovi=GETDATE(),zabeleshka_slobodni_denovi='"+zabeleshkaSd+"'", "korisnicko_ime_slobodni_denovi='" + korisnickoIme + "'");
        }

        public void UpdateSmetki(string idSmetki, string imeSmetki, string transakcijaSmetki, string zabelshkaSmetki)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Smetki";
                string uslov = "id_smetki=" + idSmetki;
                
                objSql.Update(tableName, "ime_smetki='" + imeSmetki + "',transakciska_smetka_smetki="+ transakcijaSmetki+", zabeleshka_smetka ='" + zabelshkaSmetki + "'", uslov);

            }
            catch{

            }
        }


        public void UpdateProizvodiKolicna(string sifra, string kolicinaSank)
        {
            try
            {
                int kolSank = 0;
                int momentalnaSostojba=0;

                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);

                SqlDataReader sqlite_datareader = objSql.SelectFrom("Proizvodi WHERE sifra_proizvodi=" + sifra);
                while (sqlite_datareader.Read())
                {
                    momentalnaSostojba = sqlite_datareader.GetInt32(3);//Tuka se vnesva vo integer
                }
                objSql.CloseConnection();

                bool daliEBroj= Int32.TryParse(kolicinaSank, out kolSank);
                if (daliEBroj == true)
                {
                    momentalnaSostojba = momentalnaSostojba - kolSank;
                    objSql.Update("Proizvodi", " kolicina_proizvodi=" + momentalnaSostojba, " sifra_proizvodi = " + sifra);
                }
            }
            catch
            {

            }
        }

        public void UpdatePredajSostojbaSank(string fileName)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            Assets objPublicFunction = new Assets();
            FileInfo excelFile = new FileInfo(fileName);
            ExcelObj = new Excel.Application();
            if (ExcelObj == null)
            {
                MessageBox.Show("Excel Application could not be initialized.");
                return;
            }

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
 
            for (int i = 2; i <= lastUsedRow; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);

                UpdateProizvodiKolicna(strArray[6], strArray[3]);
            }
        }


    }
}
