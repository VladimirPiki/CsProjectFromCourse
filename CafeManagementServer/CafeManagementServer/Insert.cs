using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CafeManagementServer.Database;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;



namespace CafeManagementServer
{
    internal class Insert
    {
        private Excel.Application ExcelObj = null;
        public void InsertKompanii(string ime_kompanija, string transakciska_smetka, string datum_kompanija, string status, string porakaPort)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string exportPath = "";
            string tableName = "Kompanii";

            List<string> koloniKompanii = new List<string>() { "ime_kompanija", "transakciska_smetka", "datum_kompanija", "status" };
            List<string> vrednostiKompanii = new List<string>() { ime_kompanija, transakciska_smetka, datum_kompanija, status };
            objSql.InsertRow(koloniKompanii, vrednostiKompanii, tableName);
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

        public void InsertProizvodi(string sifra, string ime, string tip, string kolicina, string cena, string kompanijaId, string porakaPort)
        {
            string porakaNazad = "";
            Komunikacija objKomunikacija = new Komunikacija();
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            SqlDataReader readerProverka = objSql.SelectFrom("Proizvodi WHERE sifra_proizvodi=" + sifra);
            if (readerProverka.HasRows)
            {
                porakaNazad = "proizvodiSifraExist";
            }
            objSql.CloseConnection();
            if (porakaNazad != "")
            {
                int port = 8086;
                objKomunikacija.IspratiMessageSoPort(port, porakaNazad);
            }
            else
            {
                string exportPath = "";
                string tableName = "Proizvodi";

                List<string> koloni = new List<string>() { "sifra_proizvodi", "ime_proizvodi", "tip_proizvodi", "kolicina_proizvodi", "cena_proizvodi", "kompanija_proizvodi_id","proizvodi_status" };
                List<string> vrednosti = new List<string>() { sifra, ime, tip, kolicina, cena, kompanijaId,"Активен" };
                objSql.InsertRow(koloni, vrednosti, tableName);
       
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
        }

        public void InsertNaracki(string korisnickoIme, string vreme, string sifra, string kolicinaProdaeni, string cena, string cenaVkupno, string promet)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string tableName = "Naracki";
            List<string> koloniKompanii = new List<string>() { "korisnicko_ime_naracki", "vreme_naracka", "sifra_naracka", "kolicina_naracka", "cena_naracka", "cena_vkupna_naracka", "promet" };
            List<string> vrednostiKompanii = new List<string>() { korisnickoIme, vreme, sifra, kolicinaProdaeni, cena, cenaVkupno, promet };
            objSql.InsertRow(koloniKompanii, vrednostiKompanii, tableName);
        }

        public void InsertNarackiSank(string fileName)
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
            string vreme = "";
            string tableName = "Naracki_sank";

            bool poslednaRedica = true;
            if (poslednaRedica)
            {
                Excel.Range range = worksheet.get_Range("A" + lastUsedRow.ToString(), columnName + lastUsedRow.ToString());//problem
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] lastRedica = objPublicFunction.ConvertToStringArray(myvalues);
                DateTime date = DateTime.Parse(lastRedica[0]);
                vreme = date.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
         
            for (int i = 2; i <= lastUsedRow-1; i++)
            {
                Excel.Range range = worksheet.get_Range("A" + i.ToString(), columnName + i.ToString());
                System.Array myvalues = (System.Array)range.Cells.Value;
                string[] strArray = objPublicFunction.ConvertToStringArray(myvalues);
      
                List<string> koloni= new List<string>() { "vreme_naracka_sank", "korisnicko_ime_naracki_sank", "sifra_naracka_sank", "kolicina_naracka_sank", "cena_naracka_sank", "cena_vkupna_naracka_sank" };
                List<string> vrednosti = new List<string>() { vreme, strArray[0], strArray[1], strArray[3], strArray[4], strArray[5] };
                objSql.InsertRow(koloni, vrednosti, tableName);
            }
        }

        public void InsertPriliv(string vreme,string budzet, string korisnickoIme,string zabeleshka)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Priliv";
                List<string> koloni = new List<string>() { "vreme_na_priliv", "suma_na_priliv", "korisnicko_ime_priliv", "zabeleshka_priliv" };
                List<string> vrednosti = new List<string>() { vreme, budzet, korisnickoIme, zabeleshka };
                objSql.InsertRow(koloni, vrednosti, tableName);

            }catch (Exception ex) {
               // MessageBox.Show("Има проблем со приливот на наменетите средства !!!");
            }
        }

        public void InsertPlata(string datum, string korisnickoIme, string osnovnaPlata, string bonusPlata, string redovnostPlata,string bolovanjePlata,string zadrshkiPlata,string zabeleshkaPlata,string vkupnoZaIspalata)
        {
            try
            {         
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Plata";
                List<string> koloni = new List<string>() { "datum_plata", "korisnicko_ime_plata", "osnovna_plata", "bonus_plata", "redovnost_plata", "bolovanje_plata", "zadrshki_plata", "zabelshka_plata", "vkupno_za_isplata" };
                List<string> vrednosti = new List<string>() { datum, korisnickoIme, osnovnaPlata, bonusPlata, redovnostPlata, bolovanjePlata, zadrshkiPlata, zabeleshkaPlata, vkupnoZaIspalata };
                objSql.InsertRow(koloni, vrednosti, tableName);

            }
            catch (Exception ex)
            {

            }
        }

        public void InsertOdliv(string vreme, string budzet, string korisnickoIme,string transakciskaSmetka, string zabeleshka)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Odliv";
                List<string> koloni = new List<string>() { "vreme_na_odliv", "suma_na_odliv", "korisnicko_ime_odliv","transakciska_smetka_odliv", "zabeleshka_odliv" };
                List<string> vrednosti = new List<string>() { vreme, budzet, korisnickoIme, transakciskaSmetka, zabeleshka };
                objSql.InsertRow(koloni, vrednosti, tableName);

            }
            catch (Exception ex)
            {

            }
        }

        public void InsertFakturi(string vreme,string vkupnaSuma, string korisnickoIme, string idKompanija, string zabeleshkaFakturi)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Fakturi";
                List<string> koloni = new List<string>() { "datum_fakturi", "vkupna_suma", "korisnicko_ime_fakturi", "id_kompanija_fakturi", "status_fakturi", "zabelshka_fakturi" };
                List<string> vrednosti = new List<string>() { vreme, vkupnaSuma, korisnickoIme, idKompanija, "ispratena", zabeleshkaFakturi};
                objSql.InsertRow(koloni, vrednosti, tableName);

            }
            catch (Exception ex)
            {

            }
        }

        public void InsertSlobodniDenovi(string korisnickoIme,string brojSd,string zabeleshkaSd)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Slobodni_denovi";
                List<string> koloni = new List<string>() { "korisnicko_ime_slobodni_denovi","broj_slobodni_denovi","datum_slobodni_denovi","zabeleshka_slobodni_denovi" };
                List<string> vrednosti = new List<string>() { korisnickoIme, brojSd,"GETDATE()", zabeleshkaSd };
                objSql.InsertRow(koloni, vrednosti, tableName);
            }
            catch (Exception ex)
            {
 
            }
        }

        public void InsertDodeluvanjeSlobodniDenovi(string korisnickoIme, string brojSd,string pricinaSd, string zabeleshkaSd)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Dodeluvanje_slobodni_denovi";       
                List<string> koloni = new List<string>() { "korisnicko_ime_dodeluvanje_slobodni_denovi", "broj_dodeluvanje_slobodni_denovi", "datum_dodeluvanje_slobodni_denovi", "korisnicko_ime_vnesuvanje", "pricina_dodeluvanje_slobodni_denovi", "zabeleshka_dodeluvanje_slobodni_denovi" };
                List<string> vrednosti = new List<string>() { korisnickoIme, brojSd, "GETDATE()",Form1.korisnikIme,pricinaSd, zabeleshkaSd };
                objSql.InsertRow(koloni, vrednosti, tableName);
            }
            catch (Exception ex)
            {
 
            }
        }

        public void InsertIskoristeniSlobodniDenovi(string korisnickoIme,string pocetok,string zavrshetok,string vrakjanje, string brojSd, string pricinaSd, string zabeleshkaSd)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Iskoristeni_denovi";
                                
                List<string> koloni = new List<string>() { "korisnicko_ime_iskoristeni_denovi", "pocetok_iskoristeni_denovi", "zavrshetok_iskoristeni_denovi", "vrakjanje_iskoristeni_denovi", "vkupno_denovi_iskoristeni_denovi", "pricina_iskoristeni_denovi", "kreirano_iskoristeni_denovi", "korisnicko_ime_kreiranje", "zabeleshka_iskoristeni_denovi" };
                List<string> vrednosti = new List<string>() { korisnickoIme, pocetok,zavrshetok,vrakjanje, brojSd, pricinaSd, "GETDATE()", Form1.korisnikIme, zabeleshkaSd };
                objSql.InsertRow(koloni, vrednosti, tableName);
            }
            catch (Exception ex)
            {

            }
        }

        public void InsertSmetki(string imeSmetki, string tipSmetki, string transakcijaSmetki, string zabeleshkaSmetki, string brojNaSmetki, string slikaSmetki)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Smetki";
                      
                List<string> koloni = new List<string>() { "ime_smetki", "tip_smetki", "transakciska_smetka_smetki", "zabeleshka_smetka", "broj_smetki", "slika_smetki" };
                List<string> vrednosti = new List<string>() { imeSmetki, tipSmetki, transakcijaSmetki, zabeleshkaSmetki, brojNaSmetki, slikaSmetki };
                objSql.InsertRow(koloni, vrednosti, tableName);
            }
            catch (Exception ex)
            {

            }
        }

        public void InsertPlateniSmetki(string smetkaId,string vreme,string sumaPlateniSmetki,string zabeleshkaPlateniSmetki)
        {
            try
            {
                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                string tableName = "Plateni_smetki";
                
                List<string> koloni = new List<string>() { "smetka_id", "datum_plateni_smetki", "suma_plateni_smetki", "zabeleshka_plateni_smetki", "korisnicko_ime_plateni_smetki" };
                List<string> vrednosti = new List<string>() { smetkaId, vreme, sumaPlateniSmetki, zabeleshkaPlateniSmetki, Form1.korisnikIme };
                objSql.InsertRow(koloni, vrednosti, tableName);
            }
            catch (Exception ex)
            {
   
            }
        }

        public void InsertNarackiVkupenPromet(string vreme, string budzet, string korisnickoIme, string zabeleshka,string den)
        {
            string porakaNazad = "";
            int port = 8089;
            Komunikacija objKomunikacija = new Komunikacija();
            Update objUpdate = new Update();
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            SqlDataReader readerProverka = objSql.SelectFrom("Priliv where korisnicko_ime_priliv='"+ korisnickoIme+"' and vreme_na_priliv between '"+den+ " 00:00:00' and '"+den+" 23:59:59' ");
            if (readerProverka.HasRows)
            {
                porakaNazad = "vkupenPrometPredaden";
            }
            objSql.CloseConnection();
            if (porakaNazad != "")
            {
                objKomunikacija.IspratiMessageSoPort(port, porakaNazad);
            }
            else
            {
                try
                {
                    InsertPriliv(vreme, budzet, korisnickoIme, zabeleshka);
                    objUpdate.UpdateBudzet(vreme, budzet, zabeleshka);
                    porakaNazad = "vkupenPrometUspesnoPredaden";
                    objKomunikacija.IspratiMessageSoPort(port, porakaNazad);
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void InsertPredajSostojbaSank(string vreme, string korisnik, string zabeleshka,string den)
        {
            try
            {
                Komunikacija objKomunikacija = new Komunikacija();
                int port = 8084;

                string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                SQLManager objSql = new SQLManager(connectionString);
                SqlDataReader readerProverka = objSql.SelectFrom("Predaena_sostojba_sank where datum_predaena_sostojba between '"+ den+"' and '"+ den+" 23:59:59' ");
                if (readerProverka.HasRows)
                { 
                    objKomunikacija.IspratiMessageSoPort(port, "neuspesnoPredaenaSostojba");
                }
                else
                {
                    objSql.CloseConnection();
                    string tableName = "Predaena_sostojba_sank";

                    List<string> koloni = new List<string>() { "datum_predaena_sostojba", "korisnicko_ime_predaena_sostojba", "zabeleshka_predaena_sostojba" };
                    List<string> vrednosti = new List<string>() { vreme, korisnik, zabeleshka };
                    objSql.InsertRow(koloni, vrednosti, tableName);

                    objKomunikacija.IspratiMessageSoPort(port, "uspesnoPredaenaSostojba");
                }  
            }
            catch (Exception ex)
            {

            }
        }

    }
}
