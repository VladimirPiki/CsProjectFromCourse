using System;
using System.Collections;
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
using static OfficeOpenXml.ExcelErrorValue;

namespace CafeManagementServer
{
    public partial class Plata : Form
    {
        public Plata()
        {
            InitializeComponent();

            lvVraboteni.View = View.Details;
            lvVraboteni.GridLines = true;
            lvVraboteni.FullRowSelect = true;
            lvVraboteni.Columns.Add("Корисничко име", 200);
            lvVraboteni.Columns.Add("Име на вработен", 200);
            lvVraboteni.Columns.Add("Презиме на вработен", 200);
            lvVraboteni.Columns.Add("Позиција", 200);
            lvVraboteni.Columns.Add("Основна плата", 200);
            lvVraboteni.Columns.Add("Трансакциска сметка", 200);

            lvPlata.View = View.Details;
            lvPlata.GridLines = true;
            lvPlata.FullRowSelect = true;
            lvPlata.Columns.Add("Датум на исплаќање на плата", 100);
            lvPlata.Columns.Add("Корисничко име", 100);
            lvPlata.Columns.Add("Основна плата", 100);
            lvPlata.Columns.Add("Бонус на основна плата", 100);
            lvPlata.Columns.Add("Додаток за редовност", 100);
            lvPlata.Columns.Add("Боловање", 100);
            lvPlata.Columns.Add("Задршки", 100);
            lvPlata.Columns.Add("Забелешка", 100);
            lvPlata.Columns.Add("Вкупна сум на плата", 200);

            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string imnjaKoloni = "korisnicko_ime,ime,prezime,pozicija,plata_vraboten,transakciska_smetka_vraboten";
            string tableName = "Vraboteni";
            SqlDataReader sqlite_datareader = objSql.SelectFields(imnjaKoloni, tableName);
            DataTable comboData = new DataTable();
            comboData.Columns.Add("korisnicko_ime");
            comboData.Columns.Add("plata_vraboten");
            comboData.Columns.Add("transakciska_smetka_vraboten");
            while (sqlite_datareader.Read())
            {
                string[] arr = new string[6];
                ListViewItem itm;

                arr[0] = sqlite_datareader.GetValue(0).ToString();
                arr[1] = sqlite_datareader.GetValue(1).ToString();
                arr[2] = sqlite_datareader.GetValue(2).ToString();
                arr[3] = sqlite_datareader.GetValue(3).ToString();
                arr[4] = sqlite_datareader.GetValue(4).ToString();
                arr[5] = sqlite_datareader.GetValue(5).ToString();

                itm = new ListViewItem(arr);
                lvVraboteni.Items.Add(itm);

                comboData.Rows.Add(sqlite_datareader.GetValue(0).ToString(), sqlite_datareader.GetValue(4).ToString(), sqlite_datareader.GetValue(5).ToString());
            }

            vraboten.DataSource = comboData;
            vraboten.DisplayMember = "korisnicko_ime";
            vraboten.ValueMember = "plata_vraboten";
            objSql.CloseConnection();

            string tableNamePlata = "Plata order by datum_plata desc";
            lvPlata.Items.Clear();
            SqlDataReader sqlite_datareader_plata = objSql.SelectFrom(tableNamePlata);
            while (sqlite_datareader_plata.Read())
            {
                string[] arr = new string[9];
                ListViewItem itm;

                arr[0] = sqlite_datareader_plata.GetDateTime(0).ToString("yyyy-MM-dd");
                arr[1] = sqlite_datareader_plata.GetValue(1).ToString();
                arr[2] = sqlite_datareader_plata.GetValue(2).ToString();
                arr[3] = sqlite_datareader_plata.GetValue(3).ToString();
                arr[4] = sqlite_datareader_plata.GetValue(4).ToString();
                arr[5] = sqlite_datareader_plata.GetValue(5).ToString();
                arr[6] = sqlite_datareader_plata.GetValue(6).ToString();
                arr[7] = sqlite_datareader_plata.GetValue(7).ToString();
                arr[8] = sqlite_datareader_plata.GetValue(8).ToString();

                itm = new ListViewItem(arr);
                lvPlata.Items.Add(itm);

            }
            objSql.CloseConnection();

            bonusPlata.Text = "0";
            redovnostPlata.Text = "0";
            bolovanje.Text = "0";
            zadrshki.Text = "0";

        }

        private void btnPlata_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(vremePlata.Text);
            string vreme = date.ToString("yyyy-MM-dd");
            if (vraboten.Text != "" && bonusPlata.Text != "" && redovnostPlata.Text != "" && bolovanje.Text != "" && zadrshki.Text != "" && prikaziPlata.Text !="" && transakciskaSmetka.Text !="" && vreme != "")
            {
                DialogResult result = MessageBox.Show("Дали навистина сте сигурни дека внесувате плата за корсник " + vraboten.Text + " ?", "Потврда за внесување плата", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
                    SQLManager objSql = new SQLManager(connectionString);
                    SqlDataReader readerProverka = objSql.SelectFrom("Plata WHERE datum_plata='" + vreme + "' AND korisnicko_ime_plata='" + vraboten.Text + "'");
                    if (readerProverka.HasRows)
                    {
                        MessageBox.Show("Имате внесено плата за корисникот");
                    }
                    else
                    {
                        objSql.CloseConnection();
                        int vkupnoPlata = 0;
                        int osnovnaInt, bonusInt, redovnostInt, bolovanjeInt, zadrshkiInt;
                        bool daliEbroj = Int32.TryParse(prikaziPlata.Text, out osnovnaInt);
                        bool daliEbroj2 = Int32.TryParse(bonusPlata.Text, out bonusInt);
                        bool daliEbroj3 = Int32.TryParse(redovnostPlata.Text, out redovnostInt);
                        bool daliEbroj4 = Int32.TryParse(bolovanje.Text, out bolovanjeInt);
                        bool daliEbroj5 = Int32.TryParse(zadrshki.Text, out zadrshkiInt);
                        if (daliEbroj && daliEbroj2 && daliEbroj3 && daliEbroj4 && daliEbroj5)
                        {
                            vkupnoPlata = osnovnaInt + bonusInt + redovnostInt - bolovanjeInt - zadrshkiInt;
                            Insert objInsert = new Insert();
                            Update objUpdate= new Update(); 
                            objInsert.InsertPlata(vreme, vraboten.Text, prikaziPlata.Text, bonusPlata.Text, redovnostPlata.Text, bolovanje.Text, zadrshki.Text, zabeleshka.Text, vkupnoPlata.ToString());
                            objInsert.InsertOdliv(vreme, vkupnoPlata.ToString(), Form1.korisnikIme, transakciskaSmetka.Text, "Исплата на плата на вработен " + vraboten.Text);
                            objUpdate.UpdateBudzetOdliv(vreme, vkupnoPlata.ToString(), "Исплата на плата на вработен " + vraboten.Text);

                            string tableNamePlata = "Plata order by datum_plata desc";
                            lvPlata.Items.Clear();
                            SqlDataReader sqlite_datareader_plata = objSql.SelectFrom(tableNamePlata);
                            while (sqlite_datareader_plata.Read())
                            {
                                string[] arr = new string[9];
                                ListViewItem itm;

                                arr[0] = sqlite_datareader_plata.GetDateTime(0).ToString("yyyy-MM-dd");
                                arr[1] = sqlite_datareader_plata.GetValue(1).ToString();
                                arr[2] = sqlite_datareader_plata.GetValue(2).ToString();
                                arr[3] = sqlite_datareader_plata.GetValue(3).ToString();
                                arr[4] = sqlite_datareader_plata.GetValue(4).ToString();
                                arr[5] = sqlite_datareader_plata.GetValue(5).ToString();
                                arr[6] = sqlite_datareader_plata.GetValue(6).ToString();
                                arr[7] = sqlite_datareader_plata.GetValue(7).ToString();
                                arr[8] = sqlite_datareader_plata.GetValue(8).ToString();

                                itm = new ListViewItem(arr);
                                lvPlata.Items.Add(itm);

                            }
                            objSql.CloseConnection();

                        }
                        else
                        {
                            MessageBox.Show("Внесете бројки во полињата. Минимална бројка 0 !!!");
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Внесете бројки во полињата. Минимална бројка 0 !!!");
            }
        }

        private void vraboten_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void vraboten_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void vraboten_SelectedValueChanged(object sender, EventArgs e)
        {
            DataRowView selectedDataRow = (DataRowView)vraboten.SelectedItem;
            prikaziPlata.Text = vraboten.SelectedValue.ToString();
            transakciskaSmetka.Text= selectedDataRow["transakciska_smetka_vraboten"].ToString();
        }

        private void lvVraboteni_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvVraboteni_DoubleClick(object sender, EventArgs e)
        {
            if (lvVraboteni.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvVraboteni.SelectedItems[0];
                vraboten.Text = selectedItem.SubItems[0].Text;
                transakciskaSmetka.Text = selectedItem.SubItems[5].Text;
                bonusPlata.Text = "0";
                redovnostPlata.Text = "0";
                bolovanje.Text = "0";
                zadrshki.Text = "0";
            }
        }

        private void bonusPlata_KeyPress(object sender, KeyPressEventArgs e)
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

        private void redovnostPlata_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bolovanje_KeyPress(object sender, KeyPressEventArgs e)
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

        private void zadrshki_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string connectionString = "Server= localhost\\SQLExpress; Database= CafeMenagement; Integrated Security=True;";
            SQLManager objSql = new SQLManager(connectionString);
            string tableNamePlata = "Plata order by datum_plata desc";
            lvPlata.Items.Clear();
            SqlDataReader sqlite_datareader_plata = objSql.SelectFrom(tableNamePlata);
            while (sqlite_datareader_plata.Read())
            {
                string[] arr = new string[9];
                ListViewItem itm;

                arr[0] = sqlite_datareader_plata.GetDateTime(0).ToString("yyyy-MM-dd");
                arr[1] = sqlite_datareader_plata.GetValue(1).ToString();
                arr[2] = sqlite_datareader_plata.GetValue(2).ToString();
                arr[3] = sqlite_datareader_plata.GetValue(3).ToString();
                arr[4] = sqlite_datareader_plata.GetValue(4).ToString();
                arr[5] = sqlite_datareader_plata.GetValue(5).ToString();
                arr[6] = sqlite_datareader_plata.GetValue(6).ToString();
                arr[7] = sqlite_datareader_plata.GetValue(7).ToString();
                arr[8] = sqlite_datareader_plata.GetValue(8).ToString();

                itm = new ListViewItem(arr);
                lvPlata.Items.Add(itm);

            }
            objSql.CloseConnection();
        }

        private void Plata_Load(object sender, EventArgs e)
        {

        }
    }
}
