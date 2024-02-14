using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace CafeManagementServer
{
    internal class Database
    {
        public class SQLManager
        {
            private SqlConnection connection;

            public SQLManager(string connectionString)
            {
                connection = new SqlConnection(connectionString);
            }

            public void OpenConnection()
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }

            public void CloseConnection()
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }

            public void CreateTables()
            {
                OpenConnection();

                ////// Create Table Korisnici
                using (SqlCommand cmd = new SqlCommand(
                    "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Vraboteni') " +
                    "BEGIN " +
                    "   CREATE TABLE Vraboteni( korisnicko_ime VARCHAR(50) NOT NULL PRIMARY KEY,lozinka TEXT, ime VARCHAR(50), prezime VARCHAR(50), datum_pocetok_rabota DATETIME, pozicija VARCHAR(10) NOT NULL CHECK (pozicija IN('sopstvenik','menadzer', 'kelner','sanker')),plata_vraboten INT, dogovor_vraboten VARCHAR(50),transakciska_smetka_vraboten BIGINT   ) " +
                    " END ", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                //Evidencija_rabotno_vreme
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Evidencija_rabotno_vreme') " +
                        "BEGIN " +
                        "   CREATE TABLE Evidencija_rabotno_vreme (id_evidencija_rabotno_vreme INTEGER IDENTITY(1,1) PRIMARY KEY,datum DATE, vreme_najava DATETIME, vreme_odjava DATETIME,zabeleshka_evidencija TEXT, korisnicko_ime_evidencija VARCHAR(50), FOREIGN KEY(korisnicko_ime_evidencija) REFERENCES Vraboteni(korisnicko_ime)) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                //Kompanii za Menadzero
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Kompanii') " +
                        "BEGIN " +
                        "   CREATE TABLE Kompanii (id_kompanija INTEGER IDENTITY(1,1) PRIMARY KEY,ime_kompanija VARCHAR(50), transakciska_smetka BIGINT,datum_kompanija DATE, status VARCHAR(20) ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                //Proizvodi za Menadzer
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Proizvodi') " +
                        "BEGIN " +
                        "   CREATE TABLE Proizvodi (sifra_proizvodi INTEGER PRIMARY KEY, ime_proizvodi VARCHAR(50), tip_proizvodi VARCHAR(100),kolicina_proizvodi INTEGER, cena_proizvodi INTEGER, kompanija_proizvodi_id INTEGER,proizvodi_status VARCHAR(20), FOREIGN KEY(kompanija_proizvodi_id) REFERENCES Kompanii(id_kompanija) ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                //Naracki od kelner
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Naracki') " +
                        "BEGIN " +
                        "   CREATE TABLE Naracki (id_naracka INTEGER IDENTITY(1,1) PRIMARY KEY, korisnicko_ime_naracki VARCHAR(50), vreme_naracka DATETIME,sifra_naracka TEXT, kolicina_naracka TEXT, cena_naracka TEXT,cena_vkupna_naracka TEXT, promet INTEGER, FOREIGN KEY(korisnicko_ime_naracki) REFERENCES Vraboteni(korisnicko_ime) ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                //Naracki od kelner za sanker
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Naracki_sank') " +
                        "BEGIN " +
                        "   CREATE TABLE Naracki_sank (vreme_naracka_sank DATETIME, korisnicko_ime_naracki_sank VARCHAR(50),sifra_naracka_sank INTEGER, kolicina_naracka_sank INTEGER, cena_naracka_sank INTEGER,cena_vkupna_naracka_sank INTEGER, FOREIGN KEY(korisnicko_ime_naracki_sank) REFERENCES Vraboteni(korisnicko_ime),FOREIGN KEY(sifra_naracka_sank) REFERENCES Proizvodi(sifra_proizvodi)  ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                //Budzet
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Budzet') " +
                        "BEGIN " +
                        "   CREATE TABLE Budzet (id_budzet INTEGER  IDENTITY(1,1) PRIMARY KEY,vreme_na_budzet DATETIME , momentalna_sostojba_budzet INTEGER, zabeleshka_budzet TEXT) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                ////Priliv
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Priliv') " +
                        "BEGIN " +
                        "   CREATE TABLE Priliv (vreme_na_priliv DATETIME PRIMARY KEY, suma_na_priliv INTEGER, korisnicko_ime_priliv VARCHAR(50), zabeleshka_priliv TEXT ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                ////Odliv
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Odliv') " +
                        "BEGIN " +
                        "   CREATE TABLE Odliv (vreme_na_odliv DATETIME PRIMARY KEY, suma_na_odliv INTEGER, korisnicko_ime_odliv VARCHAR(50),  transakciska_smetka_odliv BIGINT, zabeleshka_odliv TEXT ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                ////Plata
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Plata') " +
                        "BEGIN " +
                        "   CREATE TABLE Plata (datum_plata DATE, korisnicko_ime_plata VARCHAR(50), osnovna_plata INTEGER,  bonus_plata INTEGER, redovnost_plata INTEGER, bolovanje_plata INTEGER, zadrshki_plata INTEGER,zabelshka_plata TEXT,  vkupno_za_isplata INTEGER, FOREIGN KEY(korisnicko_ime_plata) REFERENCES Vraboteni(korisnicko_ime) ) " +
                        "END", connection))//ZADRSHKI SE MISLI NA PRIMER KUPENI RABOTI OD PRODAVNICA, KAZNI I TN...
                {
                    cmd.ExecuteNonQuery();
                }

                ////Fakturi od sopstevnikot napraveni za poracka na proizvodi
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Fakturi') " +
                        "BEGIN " +
                        "   CREATE TABLE Fakturi ( id_fakturi INTEGER IDENTITY(1,1) PRIMARY KEY, datum_fakturi DATETIME,vkupna_suma INTEGER, korisnicko_ime_fakturi VARCHAR(50), id_kompanija_fakturi INTEGER, status_fakturi VARCHAR(20), zabelshka_fakturi TEXT,  FOREIGN KEY(korisnicko_ime_fakturi) REFERENCES Vraboteni(korisnicko_ime), FOREIGN KEY(id_kompanija_fakturi) REFERENCES  Kompanii (id_kompanija)  ) " +
                        "END", connection))// VO STATUSOT ISPRATENO I PRIMENO. Isprateno od sopstvenikot do menadzerot, primeno menadzerot
                {
                    cmd.ExecuteNonQuery();
                }

                ////Вкупно слободни денови
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Slobodni_denovi') " +
                        "BEGIN " +
                        "   CREATE TABLE Slobodni_denovi ( korisnicko_ime_slobodni_denovi VARCHAR(50), broj_slobodni_denovi INTEGER, datum_slobodni_denovi DATE, zabeleshka_slobodni_denovi TEXT,  FOREIGN KEY(korisnicko_ime_slobodni_denovi) REFERENCES Vraboteni(korisnicko_ime)  ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                ////Dodeleni slobodni denovi
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Dodeluvanje_slobodni_denovi') " +
                        "BEGIN " +
                        "   CREATE TABLE Dodeluvanje_slobodni_denovi ( id_dodeluvanje_slobodni_denovi INTEGER IDENTITY(1,1) PRIMARY KEY, korisnicko_ime_dodeluvanje_slobodni_denovi VARCHAR(50), broj_dodeluvanje_slobodni_denovi INTEGER, datum_dodeluvanje_slobodni_denovi DATE, korisnicko_ime_vnesuvanje VARCHAR(50), pricina_dodeluvanje_slobodni_denovi TEXT, zabeleshka_dodeluvanje_slobodni_denovi TEXT,  FOREIGN KEY(korisnicko_ime_dodeluvanje_slobodni_denovi) REFERENCES Vraboteni(korisnicko_ime), FOREIGN KEY(korisnicko_ime_vnesuvanje) REFERENCES Vraboteni(korisnicko_ime)  ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                ////Iskoristuvanje slobodni denovi
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Iskoristeni_denovi') " +
                        "BEGIN " +
                        "   CREATE TABLE Iskoristeni_denovi ( id_iskoristeni_denovi INTEGER IDENTITY(1,1) PRIMARY KEY, korisnicko_ime_iskoristeni_denovi VARCHAR(50), pocetok_iskoristeni_denovi DATE, zavrshetok_iskoristeni_denovi DATE, vrakjanje_iskoristeni_denovi DATE, vkupno_denovi_iskoristeni_denovi INTEGER, pricina_iskoristeni_denovi TEXT, kreirano_iskoristeni_denovi DATE, korisnicko_ime_kreiranje VARCHAR(50), zabeleshka_iskoristeni_denovi TEXT, FOREIGN KEY(korisnicko_ime_iskoristeni_denovi) REFERENCES Vraboteni(korisnicko_ime), FOREIGN KEY(korisnicko_ime_kreiranje)  REFERENCES Vraboteni(korisnicko_ime)  ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                ////Smetki
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Smetki') " +
                        "BEGIN " +
                        "   CREATE TABLE Smetki ( id_smetki INTEGER IDENTITY(1,1) PRIMARY KEY, ime_smetki VARCHAR(50), tip_smetki VARCHAR(50), transakciska_smetka_smetki BIGINT, zabeleshka_smetka TEXT,broj_smetki VARCHAR(10), slika_smetki TEXT  ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                ////Plateni smetki
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Plateni_smetki') " +
                        "BEGIN " +
                        "   CREATE TABLE Plateni_smetki ( id_plateni_smetki INTEGER IDENTITY(1,1) PRIMARY KEY, smetka_id INTEGER, datum_plateni_smetki DATETIME,suma_plateni_smetki INTEGER, zabeleshka_plateni_smetki TEXT, korisnicko_ime_plateni_smetki VARCHAR(50), FOREIGN KEY(smetka_id) REFERENCES Smetki(id_smetki), FOREIGN KEY(korisnicko_ime_plateni_smetki)  REFERENCES Vraboteni(korisnicko_ime)  ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                ////Predaena_sostojba_sank
                using (SqlCommand cmd = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Predaena_sostojba_sank') " +
                        "BEGIN " +
                        "   CREATE TABLE Predaena_sostojba_sank ( datum_predaena_sostojba DATETIME, korisnicko_ime_predaena_sostojba VARCHAR(50),zabeleshka_predaena_sostojba TEXT, FOREIGN KEY(korisnicko_ime_predaena_sostojba)  REFERENCES Vraboteni(korisnicko_ime)  ) " +
                        "END", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                CloseConnection();
            }

            public void InsertRow(List<string> listView, List<string> listValues, string imeNaTabela)
            {
                OpenConnection();
                try
                {
                    string insertInto = "INSERT INTO " + imeNaTabela + "(";
                    for (int i = 0; i < listView.Count; i++)
                    {
                        if (i < listView.Count - 1)
                        {
                            insertInto = insertInto + listView[i] + ", ";
                        }
                        else
                        {
                            insertInto = insertInto + listView[i] + " )";
                        }
                    }
                    insertInto = insertInto + " VALUES(";
                    for (int i = 0; i < listValues.Count; i++)
                    {
                        if (i < listValues.Count - 1)
                        {
                            if (listValues[i] != "GETDATE()")
                            {
                                insertInto = insertInto + "'" + listValues[i] + "', ";
                            }
                            else
                            {
                                insertInto = insertInto + " " + listValues[i] + " , ";
                            }
                        }
                        else
                        {
                            if (listValues[i] != "GETDATE()")
                            {
                                insertInto = insertInto + "'" + listValues[i] + "' )";
                            }
                            else
                            {
                                insertInto = insertInto + " " + listValues[i] + " )";
                            }
           
                        }

                    }

                    using (SqlCommand cmd = new SqlCommand(
                    insertInto, connection))
                    {
                        for (int a = 0; a < listView.Count; a++)
                        {
                            for (int j = a; j < listValues.Count; j++)
                            {
                                cmd.Parameters.AddWithValue(listView[a], listValues[j]);
                                break;
                            }

                        }
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (System.Exception excpt)
                {
                    if(imeNaTabela == "Proizvodi")
                    {

                    }

                }
                CloseConnection();
            
            }

            public void Update(string imeNaTabela,string koloni, string uslov)
            {
                try
                {
                    OpenConnection();

                    using (SqlCommand cmd = new SqlCommand(
                      "UPDATE "+ imeNaTabela+" SET "+ koloni + " WHERE "+ uslov , connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    CloseConnection();
                }
                catch (System.Exception excpt)
                {
                    MessageBox.Show("Има проблем со промената !!!");
                }

            }

            public void Delete(string imeNaTabela, string uslov)
            {
                try
                {
                    OpenConnection();

                    using (SqlCommand cmd = new SqlCommand(
                      "DELETE FROM " + imeNaTabela + " WHERE " + uslov, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    CloseConnection();
                }
                catch (System.Exception excpt)
                {
                    MessageBox.Show("Има проблем со бришењето !!!");
                }

            }

            public void InsertRowVraboteni(string korisnicko_ime, string lozinka,string ime,string prezime, string pozicija,int plata,string dogovor,string transakciska_smetka_vraboten)
            {
                try
                {
                    OpenConnection();

                    using (SqlCommand cmd = new SqlCommand(
                      "Insert into Vraboteni(korisnicko_ime,lozinka,ime,prezime,datum_pocetok_rabota,pozicija,plata_vraboten,dogovor_vraboten,transakciska_smetka_vraboten) values(@korisnicko_ime,@lozinka,@ime,@prezime,GETDATE(),@pozicija,@plata_vraboten,@dogovor_vraboten,@transakciska_smetka_vraboten)", connection))
                    {
                        cmd.Parameters.AddWithValue("@korisnicko_ime", korisnicko_ime);
                        cmd.Parameters.AddWithValue("@lozinka", lozinka);
                        cmd.Parameters.AddWithValue("@ime", ime);
                        cmd.Parameters.AddWithValue("@prezime", prezime);
                        cmd.Parameters.AddWithValue("@pozicija", pozicija);
                        cmd.Parameters.AddWithValue("@plata_vraboten", plata);
                        cmd.Parameters.AddWithValue("@dogovor_vraboten", dogovor);
                        cmd.Parameters.AddWithValue("@transakciska_smetka_vraboten", transakciska_smetka_vraboten);

                        cmd.ExecuteNonQuery();
                    }

                    CloseConnection();
                    MessageBox.Show("Успешно внесивте нов вработен !!!");
                }
                catch (System.Exception excpt) {
                    MessageBox.Show("Внесеното корисничко име постои. Ве молам внесете друго корисничко име !!!");
                }
               
            }

            public SqlDataReader SelectFrom(string imeNaTabela)
            {
                OpenConnection();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM " + imeNaTabela, connection))
                {
                    reader = cmd.ExecuteReader();
                }
                return reader;
            }

            public SqlDataReader SelectFields(string iminjaKoloni, string imeNaTabela)
            {
                OpenConnection();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT "+iminjaKoloni+" FROM " + imeNaTabela, connection))
                {
                    reader = cmd.ExecuteReader();
                }
                return reader;
            }
            public SqlDataReader SelectNajava(string korisnicko_ime)
            {
                OpenConnection();
                SqlDataReader reader;
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT korisnicko_ime,pozicija,lozinka FROM Vraboteni WHERE korisnicko_ime like '"+ korisnicko_ime+"'", connection))
                {
                    reader = cmd.ExecuteReader();
                }
                return reader;

            }


        }
    }
}
