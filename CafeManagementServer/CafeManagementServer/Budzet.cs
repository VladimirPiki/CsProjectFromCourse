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
    public partial class Budzet : Form
    {
        public Budzet()
        {
            InitializeComponent();

            lvBudzet.View = View.Details;
            lvBudzet.GridLines = true;
            lvBudzet.FullRowSelect = true;
            lvBudzet.Columns.Add("Време на последна промена", 200);
            lvBudzet.Columns.Add("Моментална состојба на буџетот во денари", 200);
            lvBudzet.Columns.Add("Забелешка за буџетот", 200);

            lvOdliv.View = View.Details;
            lvOdliv.GridLines = true;
            lvOdliv.FullRowSelect = true;
            lvOdliv.Columns.Add("Време на одлив", 200);
            lvOdliv.Columns.Add("Сума на одлив", 200);
            lvOdliv.Columns.Add("Корисничко име кој изврши одлив", 200);
            lvOdliv.Columns.Add("Трансакциска сметка", 200);
            lvOdliv.Columns.Add("Забелешка за одлив", 200);

            lvPriliv.View = View.Details;
            lvPriliv.GridLines = true;
            lvPriliv.FullRowSelect = true;
            lvPriliv.Columns.Add("Време на прилив", 200);
            lvPriliv.Columns.Add("Сума на прилив", 200);
            lvPriliv.Columns.Add("Корисничко име кој изврши прилив", 200);//се мисли на келнерот
            lvPriliv.Columns.Add("Забелешка за прилив", 200);

            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);

            string tableName = "Budzet";
            lvBudzet.Items.Clear();
            SqlDataReader sqlite_datareader = objSql.SelectFrom(tableName);
            while (sqlite_datareader.Read())
            {
                string[] arr = new string[3];
                ListViewItem itm;

                arr[0] = sqlite_datareader.GetValue(1).ToString();
                arr[1] = sqlite_datareader.GetValue(2).ToString();
                arr[2] = sqlite_datareader.GetValue(3).ToString();

                itm = new ListViewItem(arr);
                lvBudzet.Items.Add(itm);

            }
            objSql.CloseConnection();

            string tableNamePriliv = "Priliv order by vreme_na_priliv desc";
            lvPriliv.Items.Clear();
            SqlDataReader sqlite_datareader_priliv = objSql.SelectFrom(tableNamePriliv);
            while (sqlite_datareader_priliv.Read())
            {
                string[] arr = new string[4];
                ListViewItem itm;

                arr[0] = sqlite_datareader_priliv.GetValue(0).ToString();
                arr[1] = sqlite_datareader_priliv.GetValue(1).ToString();
                arr[2] = sqlite_datareader_priliv.GetValue(2).ToString();
                arr[3] = sqlite_datareader_priliv.GetValue(3).ToString();

                itm = new ListViewItem(arr);
                lvPriliv.Items.Add(itm);

            }
            objSql.CloseConnection();

            string tableNameOdliv = "Odliv order by vreme_na_odliv desc";
            lvOdliv.Items.Clear();
            SqlDataReader sqlite_datareader_odliv = objSql.SelectFrom(tableNameOdliv);
            while (sqlite_datareader_odliv.Read())
            {
                string[] arr = new string[5];
                ListViewItem itm;

                arr[0] = sqlite_datareader_odliv.GetValue(0).ToString();
                arr[1] = sqlite_datareader_odliv.GetValue(1).ToString();
                arr[2] = sqlite_datareader_odliv.GetValue(2).ToString();
                arr[3] = sqlite_datareader_odliv.GetValue(3).ToString();
                arr[4] = sqlite_datareader_odliv.GetValue(4).ToString();

                itm = new ListViewItem(arr);
                lvOdliv.Items.Add(itm);

            }
            objSql.CloseConnection();
        }

        private void Budzet_Load(object sender, EventArgs e)
        {

        }

        private void lvBudzet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void tbBudzet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnSaveBudzetUpd_Click(object sender, EventArgs e)
        {
            if (tbBudzetUpd.Text != "")
            {
                DialogResult result = MessageBox.Show("Дали навистина сте сигурни дека внесувате приход од " + tbBudzetUpd.Text + " во целокупниот буџет на кафулето ?", "Потврда за внесување приход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool daliImaBudzet = false;
                    Insert objInsert = new Insert();
                    Update objUpdate = new Update();
                    DateTime date = DateTime.Now;
                    string vreme = date.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                    SQLManager objSql = new SQLManager(connectionString);
                    SqlDataReader readerProverka = objSql.SelectFrom("Budzet");
                    if (readerProverka.HasRows)
                    {
                        daliImaBudzet = true;
                    }
                    objSql.CloseConnection();
                    if (daliImaBudzet == false)
                    {
                        List<string> koloni = new List<string>() { "vreme_na_budzet", "momentalna_sostojba_budzet", "zabeleshka_budzet" };
                        List<string> vrednosti = new List<string>() { vreme, tbBudzetUpd.Text, zabeleshkaBudzetUpd.Text };
                        objSql.InsertRow(koloni, vrednosti, "Budzet");
                        objInsert.InsertPriliv(vreme, tbBudzetUpd.Text, Form1.korisnikIme, zabeleshkaBudzetUpd.Text);

                        lvBudzet.Items.Clear();
                        SqlDataReader sqlite_datareader = objSql.SelectFrom("Budzet");
                        while (sqlite_datareader.Read())
                        {
                            string[] arr = new string[3];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader.GetValue(1).ToString();
                            arr[1] = sqlite_datareader.GetValue(2).ToString();
                            arr[2] = sqlite_datareader.GetValue(3).ToString();

                            itm = new ListViewItem(arr);
                            lvBudzet.Items.Add(itm);

                        }
                        objSql.CloseConnection();

                        string tableNamePriliv = "Priliv order by vreme_na_priliv desc";
                        lvPriliv.Items.Clear();
                        SqlDataReader sqlite_datareader_priliv = objSql.SelectFrom(tableNamePriliv);
                        while (sqlite_datareader_priliv.Read())
                        {
                            string[] arr = new string[4];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader_priliv.GetValue(0).ToString();
                            arr[1] = sqlite_datareader_priliv.GetValue(1).ToString();
                            arr[2] = sqlite_datareader_priliv.GetValue(2).ToString();
                            arr[3] = sqlite_datareader_priliv.GetValue(3).ToString();

                            itm = new ListViewItem(arr);
                            lvPriliv.Items.Add(itm);

                        }
                        objSql.CloseConnection();

                    }
                    else
                    {
                        objInsert.InsertPriliv(vreme, tbBudzetUpd.Text, Form1.korisnikIme, zabeleshkaBudzetUpd.Text);
                        objUpdate.UpdateBudzet(vreme, tbBudzetUpd.Text, zabeleshkaBudzetUpd.Text);

                        lvBudzet.Items.Clear();
                        SqlDataReader sqlite_datareader = objSql.SelectFrom("Budzet");
                        while (sqlite_datareader.Read())
                        {
                            string[] arr = new string[3];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader.GetValue(1).ToString();
                            arr[1] = sqlite_datareader.GetValue(2).ToString();
                            arr[2] = sqlite_datareader.GetValue(3).ToString();

                            itm = new ListViewItem(arr);
                            lvBudzet.Items.Add(itm);

                        }
                        objSql.CloseConnection();

                        string tableNamePriliv = "Priliv order by vreme_na_priliv desc";
                        lvPriliv.Items.Clear();
                        SqlDataReader sqlite_datareader_priliv = objSql.SelectFrom(tableNamePriliv);
                        while (sqlite_datareader_priliv.Read())
                        {
                            string[] arr = new string[4];
                            ListViewItem itm;

                            arr[0] = sqlite_datareader_priliv.GetValue(0).ToString();
                            arr[1] = sqlite_datareader_priliv.GetValue(1).ToString();
                            arr[2] = sqlite_datareader_priliv.GetValue(2).ToString();
                            arr[3] = sqlite_datareader_priliv.GetValue(3).ToString();

                            itm = new ListViewItem(arr);
                            lvPriliv.Items.Add(itm);

                        }
                        objSql.CloseConnection();

                    }
                }

            }
            else
            {
                MessageBox.Show("Задолжително внесете ја сумата на приходот !!!");
            }
        }

        private void lvOdliv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbBudzetUpd_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbBudzetUpd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
