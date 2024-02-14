using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CafeManagementServer.Database;

namespace CafeManagementServer
{
    public partial class Sopstvenik : Form
    {
        public Sopstvenik()
        {
            InitializeComponent();
          
        }

        private void btnVraboteni_Click(object sender, EventArgs e)
        {
            Vraboteni objVraboteni = new Vraboteni();
            objVraboteni.ShowDialog();
        }

        private void btnPlata_Click(object sender, EventArgs e)
        {
            Plata objPlata = new Plata();
            objPlata.ShowDialog();
        }

        private void Sopstvenik_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDenovi_Click(object sender, EventArgs e)
        {
            Denovi objDenovi = new Denovi();
            objDenovi.ShowDialog();
        }

        private void btnEvidencija_Click(object sender, EventArgs e)
        {
            Evidencija objEvidencija = new Evidencija();
            objEvidencija.ShowDialog();
        }


        private void Sopstvenik_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Дали навистина сакате да се одјавите ?", "Потврда за одјавување", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                    SQLManager objSql = new SQLManager(connectionString);
                    DateTime currentDate = DateTime.Now;
                    string vreme = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string korisnikIme= Form1.korisnikIme;
                    string korisnikNajava= Form1.korisnikNajava;
                    objSql.Update("Evidencija_rabotno_vreme", "vreme_odjava='" + vreme + "' , zabeleshka_evidencija='"+tbZabeleshka.Text+"'", "vreme_najava='" + korisnikNajava + "' AND korisnicko_ime_evidencija='" + korisnikIme + "'");
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the form closing action
                }
            }
        }

        private void tbZabeleshka_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBudzet_Click(object sender, EventArgs e)
        {
            Budzet objBudzet = new Budzet();
            objBudzet.ShowDialog();
        }

        private void btnNabavka_Click(object sender, EventArgs e)
        {
            Nabavka objNabavka = new Nabavka();
            objNabavka.ShowDialog();
        }

        private void btnSmetki_Click(object sender, EventArgs e)
        {
            Smetki objSmetki = new Smetki();
            objSmetki.ShowDialog(); 
        }

        private void btnZacuvajZabeleshka_Click(object sender, EventArgs e)
        {

        }
    }
}
