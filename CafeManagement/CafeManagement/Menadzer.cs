using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace CafeManagement
{
    public partial class Menadzer : Form
    {
       
        public Menadzer()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProverka_Click(object sender, EventArgs e)
        {
            MenadzerOtcituvanje objMenadzerOtcituvanje=new MenadzerOtcituvanje();
            objMenadzerOtcituvanje.ShowDialog();  
        }

        private void btnVnesiNovProizvod_Click(object sender, EventArgs e)
        {
            MenadzerVnesiNovProizvod objMenadzerVnesiNovProizvod = new MenadzerVnesiNovProizvod();
            objMenadzerVnesiNovProizvod.ShowDialog();
        }

        private void Menadzer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Дали навистина сакате да се одјавите ?", "Потврда за одјавување", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DateTime currentDate = DateTime.Now;
                    string vreme = currentDate.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string korisnikIme = Form1.korisnikIme;
                    string korisnikNajava = Form1.korisnikNajavaVreme;
                    Komunikacija objKomunikacija = new Komunikacija();
                    objKomunikacija.Odjava(vreme, tbZabeleshka.Text, korisnikNajava, korisnikIme);
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the form closing action
                }
            }
        }

        private void btnKompanii_Click(object sender, EventArgs e)
        {
            MenadzerKompanii objMenadzerKompanii=new MenadzerKompanii();    
            objMenadzerKompanii.ShowDialog();
        }

        private void Menadzer_Load(object sender, EventArgs e)
        {

        }

        private void tbZabeleshka_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
