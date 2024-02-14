using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CafeManagementServer.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;

namespace CafeManagementServer
{
    internal class Login
    {
        private Excel.Application ExcelObj = null;

        public void NajavaClient(string kornickoIme, string korisnickaLozinka)
        {
            string porakaNazad = "";
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string korisnickoIme = "";
            string pozicija = "";
            string lozinka = "";
            SqlDataReader sqlite_datareader = objSql.SelectNajava(kornickoIme);
            while (sqlite_datareader.Read())
            {
                korisnickoIme = sqlite_datareader.GetValue(0).ToString();
                pozicija = sqlite_datareader.GetValue(1).ToString();
                lozinka = sqlite_datareader.GetValue(2).ToString();

            }
            objSql.CloseConnection();

            if (korisnickoIme != "" && pozicija != "" && lozinka != "")
            {
                bool daliEtocenaLozinkata = BCrypt.Net.BCrypt.Verify(korisnickaLozinka, lozinka);

                if (daliEtocenaLozinkata)
                {
                    DateTime currentDate = DateTime.Now;
                    string vreme = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    List<string> evidencijaKoloni = new List<string>() { "datum", "vreme_najava", "vreme_odjava", "zabeleshka_evidencija", "korisnicko_ime_evidencija" };
                    List<string> evidencijaVrednosti = new List<string>() { "GETDATE()", vreme, "", "", korisnickoIme };
                    objSql.InsertRow(evidencijaKoloni, evidencijaVrednosti, "Evidencija_rabotno_vreme");
                    porakaNazad = "najavaUspesna#" + korisnickoIme + "#" + pozicija + "#" + vreme;
                }
                else
                {
                    porakaNazad = "najavaPogresnaLozinka";
                }
            }
            else
            {
                porakaNazad = "najavaPogresenoKorisnickoIme";
            }
            Komunikacija objKomunikacija = new Komunikacija();
            objKomunikacija.IspratiMessage(porakaNazad);
        }

        public void OdjavaClient(string vreme, string zabeleshka, string korisnikNajava, string korisnikIme)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            objSql.Update("Evidencija_rabotno_vreme", "vreme_odjava='" + vreme + "' , zabeleshka_evidencija='" + zabeleshka + "'", "vreme_najava='" + korisnikNajava + "' AND korisnicko_ime_evidencija='" + korisnikIme + "'");
        }

    }
}
