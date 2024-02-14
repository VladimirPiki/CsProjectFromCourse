using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement
{
    public partial class MenadzerEvidencijaRabVreme : Form
    {
        public MenadzerEvidencijaRabVreme()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Датум на најава", 200);
            listView1.Columns.Add("Време на најава", 200);
            listView1.Columns.Add("Време на одјава", 200);
            listView1.Columns.Add("Работни часови", 200);
            listView1.Columns.Add("Име на вработен", 200);
            listView1.Columns.Add("Презиме на вработен", 200);
            listView1.Columns.Add("Позиција на вработен", 200);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
