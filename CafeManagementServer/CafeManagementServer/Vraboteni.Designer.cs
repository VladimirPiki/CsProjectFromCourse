namespace CafeManagementServer
{
    partial class Vraboteni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnIzbrisiVraboten = new System.Windows.Forms.Button();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.korisnickoImeUpdate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pozicijaUpdate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.datumVrabotenUpdate = new System.Windows.Forms.DateTimePicker();
            this.prezimeVrabotenUpdate = new System.Windows.Forms.TextBox();
            this.imeVrabotenUpdate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plataUpdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dogovorUpdate = new System.Windows.Forms.ComboBox();
            this.lozinkaCheckUpdate = new System.Windows.Forms.CheckBox();
            this.lozinkaUpdate = new System.Windows.Forms.TextBox();
            this.tbPlata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDogovor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbLozinka = new System.Windows.Forms.TextBox();
            this.tbKorisnickoIme = new System.Windows.Forms.TextBox();
            this.btnVnesi = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbPozicija = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbTransakciska = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.transakciskaUpdate = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(199, 48);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1153, 624);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // btnIzbrisiVraboten
            // 
            this.btnIzbrisiVraboten.Location = new System.Drawing.Point(471, 678);
            this.btnIzbrisiVraboten.Name = "btnIzbrisiVraboten";
            this.btnIzbrisiVraboten.Size = new System.Drawing.Size(190, 63);
            this.btnIzbrisiVraboten.TabIndex = 10;
            this.btnIzbrisiVraboten.Text = "Избриши вработен";
            this.btnIzbrisiVraboten.UseVisualStyleBackColor = true;
            this.btnIzbrisiVraboten.Click += new System.EventHandler(this.btnIzbrisiVraboten_Click);
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Location = new System.Drawing.Point(1395, 586);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(149, 64);
            this.btnSaveUpdate.TabIndex = 35;
            this.btnSaveUpdate.Text = "Зачувај променети вредности";
            this.btnSaveUpdate.UseVisualStyleBackColor = true;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // korisnickoImeUpdate
            // 
            this.korisnickoImeUpdate.Location = new System.Drawing.Point(1383, 48);
            this.korisnickoImeUpdate.Name = "korisnickoImeUpdate";
            this.korisnickoImeUpdate.Size = new System.Drawing.Size(175, 20);
            this.korisnickoImeUpdate.TabIndex = 34;
            this.korisnickoImeUpdate.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1399, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Промени позиција";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // pozicijaUpdate
            // 
            this.pozicijaUpdate.FormattingEnabled = true;
            this.pozicijaUpdate.Items.AddRange(new object[] {
            "sopstvenik",
            "menadzer",
            "sanker",
            "kelner"});
            this.pozicijaUpdate.Location = new System.Drawing.Point(1369, 322);
            this.pozicijaUpdate.Name = "pozicijaUpdate";
            this.pozicijaUpdate.Size = new System.Drawing.Size(175, 21);
            this.pozicijaUpdate.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1358, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Промени датум на почеток на работа";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1366, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Промени го презиме на вработен";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1382, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Промени име на вработен";
            // 
            // datumVrabotenUpdate
            // 
            this.datumVrabotenUpdate.CustomFormat = "yyyy-MM-dd";
            this.datumVrabotenUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumVrabotenUpdate.Location = new System.Drawing.Point(1369, 276);
            this.datumVrabotenUpdate.Name = "datumVrabotenUpdate";
            this.datumVrabotenUpdate.Size = new System.Drawing.Size(175, 20);
            this.datumVrabotenUpdate.TabIndex = 27;
            // 
            // prezimeVrabotenUpdate
            // 
            this.prezimeVrabotenUpdate.Location = new System.Drawing.Point(1369, 215);
            this.prezimeVrabotenUpdate.Name = "prezimeVrabotenUpdate";
            this.prezimeVrabotenUpdate.Size = new System.Drawing.Size(175, 20);
            this.prezimeVrabotenUpdate.TabIndex = 26;
            // 
            // imeVrabotenUpdate
            // 
            this.imeVrabotenUpdate.Location = new System.Drawing.Point(1369, 159);
            this.imeVrabotenUpdate.Name = "imeVrabotenUpdate";
            this.imeVrabotenUpdate.Size = new System.Drawing.Size(175, 20);
            this.imeVrabotenUpdate.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1402, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Промени плата";
            // 
            // plataUpdate
            // 
            this.plataUpdate.Location = new System.Drawing.Point(1369, 363);
            this.plataUpdate.Name = "plataUpdate";
            this.plataUpdate.Size = new System.Drawing.Size(178, 20);
            this.plataUpdate.TabIndex = 36;
            this.plataUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.plataUpdate_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1402, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Промени договор";
            // 
            // dogovorUpdate
            // 
            this.dogovorUpdate.FormattingEnabled = true;
            this.dogovorUpdate.Items.AddRange(new object[] {
            "3",
            "6",
            "9",
            "neopredeleno"});
            this.dogovorUpdate.Location = new System.Drawing.Point(1369, 411);
            this.dogovorUpdate.Name = "dogovorUpdate";
            this.dogovorUpdate.Size = new System.Drawing.Size(178, 21);
            this.dogovorUpdate.TabIndex = 40;
            // 
            // lozinkaCheckUpdate
            // 
            this.lozinkaCheckUpdate.AutoSize = true;
            this.lozinkaCheckUpdate.Location = new System.Drawing.Point(1439, 498);
            this.lozinkaCheckUpdate.Name = "lozinkaCheckUpdate";
            this.lozinkaCheckUpdate.Size = new System.Drawing.Size(70, 17);
            this.lozinkaCheckUpdate.TabIndex = 42;
            this.lozinkaCheckUpdate.Text = "Лозинка";
            this.lozinkaCheckUpdate.UseVisualStyleBackColor = true;
            this.lozinkaCheckUpdate.CheckedChanged += new System.EventHandler(this.lozinkaCheckUpdate_CheckedChanged);
            // 
            // lozinkaUpdate
            // 
            this.lozinkaUpdate.Location = new System.Drawing.Point(1369, 531);
            this.lozinkaUpdate.Name = "lozinkaUpdate";
            this.lozinkaUpdate.Size = new System.Drawing.Size(186, 20);
            this.lozinkaUpdate.TabIndex = 43;
            this.lozinkaUpdate.UseSystemPasswordChar = true;
            this.lozinkaUpdate.Visible = false;
            // 
            // tbPlata
            // 
            this.tbPlata.Location = new System.Drawing.Point(12, 445);
            this.tbPlata.Name = "tbPlata";
            this.tbPlata.Size = new System.Drawing.Size(165, 20);
            this.tbPlata.TabIndex = 59;
            this.tbPlata.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPlata_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Договор";
            // 
            // cbDogovor
            // 
            this.cbDogovor.FormattingEnabled = true;
            this.cbDogovor.Items.AddRange(new object[] {
            "3",
            "6",
            "9",
            "12",
            "neopredeleno",
            "proba"});
            this.cbDogovor.Location = new System.Drawing.Point(11, 494);
            this.cbDogovor.Name = "cbDogovor";
            this.cbDogovor.Size = new System.Drawing.Size(166, 21);
            this.cbDogovor.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 429);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Плата";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 55;
            this.label11.Text = "Корисничко име";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "Лозинка";
            // 
            // tbLozinka
            // 
            this.tbLozinka.Location = new System.Drawing.Point(12, 249);
            this.tbLozinka.Name = "tbLozinka";
            this.tbLozinka.Size = new System.Drawing.Size(161, 20);
            this.tbLozinka.TabIndex = 53;
            this.tbLozinka.UseSystemPasswordChar = true;
            // 
            // tbKorisnickoIme
            // 
            this.tbKorisnickoIme.Location = new System.Drawing.Point(12, 199);
            this.tbKorisnickoIme.Name = "tbKorisnickoIme";
            this.tbKorisnickoIme.Size = new System.Drawing.Size(165, 20);
            this.tbKorisnickoIme.TabIndex = 52;
            // 
            // btnVnesi
            // 
            this.btnVnesi.Location = new System.Drawing.Point(8, 586);
            this.btnVnesi.Name = "btnVnesi";
            this.btnVnesi.Size = new System.Drawing.Size(174, 71);
            this.btnVnesi.TabIndex = 51;
            this.btnVnesi.Text = "Внеси нов вработен";
            this.btnVnesi.UseVisualStyleBackColor = true;
            this.btnVnesi.Click += new System.EventHandler(this.btnVnesi_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(135, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Презиме на вработениот";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(54, 381);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Позиција";
            // 
            // cbPozicija
            // 
            this.cbPozicija.FormattingEnabled = true;
            this.cbPozicija.Items.AddRange(new object[] {
            "sopstvenik",
            "menadzer",
            "kelner",
            "sanker"});
            this.cbPozicija.Location = new System.Drawing.Point(12, 397);
            this.cbPozicija.Name = "cbPozicija";
            this.cbPozicija.Size = new System.Drawing.Size(161, 21);
            this.cbPozicija.TabIndex = 48;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 283);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "Име на вработениот";
            // 
            // tbPrezime
            // 
            this.tbPrezime.Location = new System.Drawing.Point(11, 347);
            this.tbPrezime.Name = "tbPrezime";
            this.tbPrezime.Size = new System.Drawing.Size(162, 20);
            this.tbPrezime.TabIndex = 46;
            // 
            // tbIme
            // 
            this.tbIme.Location = new System.Drawing.Point(11, 299);
            this.tbIme.Name = "tbIme";
            this.tbIme.Size = new System.Drawing.Size(161, 20);
            this.tbIme.TabIndex = 45;
            this.tbIme.TextChanged += new System.EventHandler(this.tbIme_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(-1, 140);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(194, 24);
            this.label16.TabIndex = 44;
            this.label16.Text = "Внеси нов вработен";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(783, 678);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(201, 63);
            this.btnSelect.TabIndex = 60;
            this.btnSelect.Text = "Прикажи ги сите вработени";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tbTransakciska
            // 
            this.tbTransakciska.Location = new System.Drawing.Point(12, 554);
            this.tbTransakciska.Name = "tbTransakciska";
            this.tbTransakciska.Size = new System.Drawing.Size(170, 20);
            this.tbTransakciska.TabIndex = 61;
            this.tbTransakciska.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTransakciska_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(38, 531);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "Трансакциска сметка";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1377, 445);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(167, 13);
            this.label18.TabIndex = 64;
            this.label18.Text = "Промени трансакциска сметка";
            // 
            // transakciskaUpdate
            // 
            this.transakciskaUpdate.Location = new System.Drawing.Point(1369, 471);
            this.transakciskaUpdate.Name = "transakciskaUpdate";
            this.transakciskaUpdate.Size = new System.Drawing.Size(186, 20);
            this.transakciskaUpdate.TabIndex = 63;
            this.transakciskaUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(714, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(238, 24);
            this.label19.TabIndex = 65;
            this.label19.Text = "Листа со сите вработени";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 6);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(191, 39);
            this.label20.TabIndex = 66;
            this.label20.Text = "Вработени";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(1381, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(182, 24);
            this.label21.TabIndex = 67;
            this.label21.Text = "Промени вработен";
            // 
            // Vraboteni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1567, 753);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.transakciskaUpdate);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbTransakciska);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.tbPlata);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbDogovor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbLozinka);
            this.Controls.Add(this.tbKorisnickoIme);
            this.Controls.Add(this.btnVnesi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbPozicija);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbPrezime);
            this.Controls.Add(this.tbIme);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lozinkaUpdate);
            this.Controls.Add(this.lozinkaCheckUpdate);
            this.Controls.Add(this.dogovorUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plataUpdate);
            this.Controls.Add(this.btnSaveUpdate);
            this.Controls.Add(this.korisnickoImeUpdate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pozicijaUpdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.datumVrabotenUpdate);
            this.Controls.Add(this.prezimeVrabotenUpdate);
            this.Controls.Add(this.imeVrabotenUpdate);
            this.Controls.Add(this.btnIzbrisiVraboten);
            this.Controls.Add(this.listView1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Vraboteni";
            this.Text = "Vraboteni";
            this.Load += new System.EventHandler(this.Vraboteni_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnIzbrisiVraboten;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.TextBox korisnickoImeUpdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox pozicijaUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datumVrabotenUpdate;
        private System.Windows.Forms.TextBox prezimeVrabotenUpdate;
        private System.Windows.Forms.TextBox imeVrabotenUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox plataUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dogovorUpdate;
        private System.Windows.Forms.CheckBox lozinkaCheckUpdate;
        private System.Windows.Forms.TextBox lozinkaUpdate;
        private System.Windows.Forms.TextBox tbPlata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDogovor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbLozinka;
        private System.Windows.Forms.TextBox tbKorisnickoIme;
        private System.Windows.Forms.Button btnVnesi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbPozicija;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbPrezime;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox tbTransakciska;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox transakciskaUpdate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
    }
}