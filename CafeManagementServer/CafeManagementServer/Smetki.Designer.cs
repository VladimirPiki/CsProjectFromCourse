namespace CafeManagementServer
{
    partial class Smetki
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Smetki));
            this.imeVnesi = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.transakcijaPromeni = new System.Windows.Forms.TextBox();
            this.imePromeni = new System.Windows.Forms.TextBox();
            this.brojPrebaraj = new System.Windows.Forms.TextBox();
            this.transakcijaVnesi = new System.Windows.Forms.TextBox();
            this.btnVnesi = new System.Windows.Forms.Button();
            this.btnPromeni = new System.Windows.Forms.Button();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.lvSmetki = new System.Windows.Forms.ListView();
            this.groupPromeni = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.zabeleshkaPromeni = new System.Windows.Forms.RichTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tipPromeni = new System.Windows.Forms.ComboBox();
            this.lvPlateniSmetki = new System.Windows.Forms.ListView();
            this.tipPlati = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPlati = new System.Windows.Forms.Button();
            this.groupPlati = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.zabeleshkaPlati = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.transakcijaPlati = new System.Windows.Forms.TextBox();
            this.sumaPlati = new System.Windows.Forms.TextBox();
            this.imePlati = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.datumOdPrebaraj = new System.Windows.Forms.DateTimePicker();
            this.btnPrebaraj = new System.Windows.Forms.Button();
            this.tipPrebaraj = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tipVnesi = new System.Windows.Forms.ComboBox();
            this.sumaOdPrebaraj = new System.Windows.Forms.TextBox();
            this.sumaDoPrebaraj = new System.Windows.Forms.TextBox();
            this.labelSumaOd = new System.Windows.Forms.Label();
            this.labelSumaDo = new System.Windows.Forms.Label();
            this.zabeleshkaVnesi = new System.Windows.Forms.RichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btIzberiSlika = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tbSlika = new System.Windows.Forms.TextBox();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.labelBroj = new System.Windows.Forms.Label();
            this.datumDoPrebaraj = new System.Windows.Forms.DateTimePicker();
            this.labelDatumOd = new System.Windows.Forms.Label();
            this.labelDatumDo = new System.Windows.Forms.Label();
            this.cbBroj = new System.Windows.Forms.CheckBox();
            this.cbIme = new System.Windows.Forms.CheckBox();
            this.cbTip = new System.Windows.Forms.CheckBox();
            this.cbDatum = new System.Windows.Forms.CheckBox();
            this.cbSuma = new System.Windows.Forms.CheckBox();
            this.imePrebaraj = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbSopstvenik = new System.Windows.Forms.CheckBox();
            this.sopstvenikPrebaraj = new System.Windows.Forms.ComboBox();
            this.btnPrebarajSite = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupPromeni.SuspendLayout();
            this.groupPlati.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // imeVnesi
            // 
            this.imeVnesi.Location = new System.Drawing.Point(38, 500);
            this.imeVnesi.Name = "imeVnesi";
            this.imeVnesi.Size = new System.Drawing.Size(205, 20);
            this.imeVnesi.TabIndex = 0;
            this.imeVnesi.TextChanged += new System.EventHandler(this.imeVnesi_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Внесете сметка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Име на примач на сметката (латиница)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 577);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Трансакциска сметка";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(553, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Листа на сметки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1299, 440);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(257, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Промени постоечка сметка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1409, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(284, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Листа со сите платени сметки";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 529);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Тип на сметка";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(648, 440);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 24);
            this.label12.TabIndex = 23;
            this.label12.Text = "Плати сметка";
            // 
            // transakcijaPromeni
            // 
            this.transakcijaPromeni.Location = new System.Drawing.Point(21, 94);
            this.transakcijaPromeni.Name = "transakcijaPromeni";
            this.transakcijaPromeni.Size = new System.Drawing.Size(219, 20);
            this.transakcijaPromeni.TabIndex = 49;
            this.transakcijaPromeni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.transakcijaPromeni_KeyPress);
            // 
            // imePromeni
            // 
            this.imePromeni.Location = new System.Drawing.Point(21, 40);
            this.imePromeni.Name = "imePromeni";
            this.imePromeni.Size = new System.Drawing.Size(219, 20);
            this.imePromeni.TabIndex = 51;
            this.imePromeni.TextChanged += new System.EventHandler(this.imePromeni_TextChanged);
            // 
            // brojPrebaraj
            // 
            this.brojPrebaraj.Location = new System.Drawing.Point(1609, 500);
            this.brojPrebaraj.Name = "brojPrebaraj";
            this.brojPrebaraj.Size = new System.Drawing.Size(219, 20);
            this.brojPrebaraj.TabIndex = 65;
            this.brojPrebaraj.Visible = false;
            this.brojPrebaraj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.brojPrebaraj_KeyPress);
            // 
            // transakcijaVnesi
            // 
            this.transakcijaVnesi.Location = new System.Drawing.Point(37, 593);
            this.transakcijaVnesi.Name = "transakcijaVnesi";
            this.transakcijaVnesi.Size = new System.Drawing.Size(206, 20);
            this.transakcijaVnesi.TabIndex = 69;
            this.transakcijaVnesi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.transakcijaVnesi_KeyPress);
            // 
            // btnVnesi
            // 
            this.btnVnesi.Location = new System.Drawing.Point(37, 740);
            this.btnVnesi.Name = "btnVnesi";
            this.btnVnesi.Size = new System.Drawing.Size(206, 70);
            this.btnVnesi.TabIndex = 70;
            this.btnVnesi.Text = "Внесете сметка";
            this.btnVnesi.UseVisualStyleBackColor = true;
            this.btnVnesi.Click += new System.EventHandler(this.btnVnesi_Click);
            // 
            // btnPromeni
            // 
            this.btnPromeni.Location = new System.Drawing.Point(63, 198);
            this.btnPromeni.Name = "btnPromeni";
            this.btnPromeni.Size = new System.Drawing.Size(154, 77);
            this.btnPromeni.TabIndex = 71;
            this.btnPromeni.Text = "Променете сметка";
            this.btnPromeni.UseVisualStyleBackColor = true;
            this.btnPromeni.Click += new System.EventHandler(this.btnPromeni_Click);
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.Location = new System.Drawing.Point(21, 256);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(102, 84);
            this.btnIzbrisi.TabIndex = 72;
            this.btnIzbrisi.Text = "Избришете сметка";
            this.btnIzbrisi.UseVisualStyleBackColor = true;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // lvSmetki
            // 
            this.lvSmetki.HideSelection = false;
            this.lvSmetki.Location = new System.Drawing.Point(158, 36);
            this.lvSmetki.MultiSelect = false;
            this.lvSmetki.Name = "lvSmetki";
            this.lvSmetki.Size = new System.Drawing.Size(834, 388);
            this.lvSmetki.TabIndex = 82;
            this.lvSmetki.UseCompatibleStateImageBehavior = false;
            this.lvSmetki.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvSmetki_MouseClick);
            // 
            // groupPromeni
            // 
            this.groupPromeni.Controls.Add(this.label26);
            this.groupPromeni.Controls.Add(this.zabeleshkaPromeni);
            this.groupPromeni.Controls.Add(this.label25);
            this.groupPromeni.Controls.Add(this.label24);
            this.groupPromeni.Controls.Add(this.transakcijaPromeni);
            this.groupPromeni.Controls.Add(this.btnPromeni);
            this.groupPromeni.Controls.Add(this.imePromeni);
            this.groupPromeni.Location = new System.Drawing.Point(1282, 512);
            this.groupPromeni.Name = "groupPromeni";
            this.groupPromeni.Size = new System.Drawing.Size(289, 410);
            this.groupPromeni.TabIndex = 83;
            this.groupPromeni.TabStop = false;
            this.groupPromeni.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(67, 127);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(119, 13);
            this.label26.TabIndex = 111;
            this.label26.Text = "Забелешка за сметка";
            // 
            // zabeleshkaPromeni
            // 
            this.zabeleshkaPromeni.Location = new System.Drawing.Point(21, 148);
            this.zabeleshkaPromeni.Name = "zabeleshkaPromeni";
            this.zabeleshkaPromeni.Size = new System.Drawing.Size(219, 41);
            this.zabeleshkaPromeni.TabIndex = 112;
            this.zabeleshkaPromeni.Text = "";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(67, 74);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(120, 13);
            this.label25.TabIndex = 73;
            this.label25.Text = "Трансакциска сметка";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(89, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(84, 13);
            this.label24.TabIndex = 72;
            this.label24.Text = "Име на сметка";
            // 
            // tipPromeni
            // 
            this.tipPromeni.FormattingEnabled = true;
            this.tipPromeni.Location = new System.Drawing.Point(1302, 485);
            this.tipPromeni.Name = "tipPromeni";
            this.tipPromeni.Size = new System.Drawing.Size(219, 21);
            this.tipPromeni.TabIndex = 84;
            this.tipPromeni.SelectedIndexChanged += new System.EventHandler(this.tipPromeni_SelectedIndexChanged);
            this.tipPromeni.SelectedValueChanged += new System.EventHandler(this.tipPromeni_SelectedValueChanged);
            // 
            // lvPlateniSmetki
            // 
            this.lvPlateniSmetki.HideSelection = false;
            this.lvPlateniSmetki.Location = new System.Drawing.Point(998, 36);
            this.lvPlateniSmetki.Name = "lvPlateniSmetki";
            this.lvPlateniSmetki.Size = new System.Drawing.Size(887, 388);
            this.lvPlateniSmetki.TabIndex = 85;
            this.lvPlateniSmetki.UseCompatibleStateImageBehavior = false;
            this.lvPlateniSmetki.SelectedIndexChanged += new System.EventHandler(this.lvPlateniSmetki_SelectedIndexChanged);
            this.lvPlateniSmetki.DockChanged += new System.EventHandler(this.lvPlateniSmetki_DockChanged);
            this.lvPlateniSmetki.DoubleClick += new System.EventHandler(this.lvPlateniSmetki_DoubleClick);
            // 
            // tipPlati
            // 
            this.tipPlati.FormattingEnabled = true;
            this.tipPlati.Location = new System.Drawing.Point(604, 500);
            this.tipPlati.Name = "tipPlati";
            this.tipPlati.Size = new System.Drawing.Size(219, 21);
            this.tipPlati.TabIndex = 87;
            this.tipPlati.SelectedIndexChanged += new System.EventHandler(this.tipPlati_SelectedIndexChanged);
            this.tipPlati.SelectedValueChanged += new System.EventHandler(this.tipPlati_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(643, 479);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 86;
            this.label7.Text = "Изберете тип на сметка";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1637, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(237, 24);
            this.label9.TabIndex = 90;
            this.label9.Text = "Пребарај платена сметка";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // btnPlati
            // 
            this.btnPlati.Location = new System.Drawing.Point(31, 268);
            this.btnPlati.Name = "btnPlati";
            this.btnPlati.Size = new System.Drawing.Size(219, 78);
            this.btnPlati.TabIndex = 95;
            this.btnPlati.Text = "Плати сметка";
            this.btnPlati.UseVisualStyleBackColor = true;
            this.btnPlati.Click += new System.EventHandler(this.btnPlati_Click);
            // 
            // groupPlati
            // 
            this.groupPlati.Controls.Add(this.label20);
            this.groupPlati.Controls.Add(this.zabeleshkaPlati);
            this.groupPlati.Controls.Add(this.label15);
            this.groupPlati.Controls.Add(this.label16);
            this.groupPlati.Controls.Add(this.label17);
            this.groupPlati.Controls.Add(this.transakcijaPlati);
            this.groupPlati.Controls.Add(this.sumaPlati);
            this.groupPlati.Controls.Add(this.imePlati);
            this.groupPlati.Controls.Add(this.btnPlati);
            this.groupPlati.Location = new System.Drawing.Point(577, 527);
            this.groupPlati.Name = "groupPlati";
            this.groupPlati.Size = new System.Drawing.Size(265, 411);
            this.groupPlati.TabIndex = 96;
            this.groupPlati.TabStop = false;
            this.groupPlati.Enter += new System.EventHandler(this.groupPlati_Enter);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(60, 190);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(163, 13);
            this.label20.TabIndex = 97;
            this.label20.Text = "Забелешка за платена сметка";
            // 
            // zabeleshkaPlati
            // 
            this.zabeleshkaPlati.Location = new System.Drawing.Point(31, 212);
            this.zabeleshkaPlati.Name = "zabeleshkaPlati";
            this.zabeleshkaPlati.Size = new System.Drawing.Size(219, 46);
            this.zabeleshkaPlati.TabIndex = 96;
            this.zabeleshkaPlati.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(183, 13);
            this.label15.TabIndex = 85;
            this.label15.Text = "Сума на сметка со данок(18% ддв)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(81, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 13);
            this.label16.TabIndex = 73;
            this.label16.Text = "Трансакциска сметка";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(95, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 13);
            this.label17.TabIndex = 72;
            this.label17.Text = "Име на сметка";
            // 
            // transakcijaPlati
            // 
            this.transakcijaPlati.Enabled = false;
            this.transakcijaPlati.Location = new System.Drawing.Point(31, 103);
            this.transakcijaPlati.Name = "transakcijaPlati";
            this.transakcijaPlati.Size = new System.Drawing.Size(215, 20);
            this.transakcijaPlati.TabIndex = 49;
            this.transakcijaPlati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.transakcijaPlati_KeyPress);
            // 
            // sumaPlati
            // 
            this.sumaPlati.Location = new System.Drawing.Point(31, 159);
            this.sumaPlati.Name = "sumaPlati";
            this.sumaPlati.Size = new System.Drawing.Size(215, 20);
            this.sumaPlati.TabIndex = 50;
            this.sumaPlati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sumaPlati_KeyPress);
            // 
            // imePlati
            // 
            this.imePlati.Enabled = false;
            this.imePlati.Location = new System.Drawing.Point(31, 45);
            this.imePlati.Name = "imePlati";
            this.imePlati.Size = new System.Drawing.Size(215, 20);
            this.imePlati.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1651, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 97;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1686, 623);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 13);
            this.label18.TabIndex = 99;
            // 
            // datumOdPrebaraj
            // 
            this.datumOdPrebaraj.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumOdPrebaraj.Location = new System.Drawing.Point(1609, 676);
            this.datumOdPrebaraj.Name = "datumOdPrebaraj";
            this.datumOdPrebaraj.Size = new System.Drawing.Size(111, 20);
            this.datumOdPrebaraj.TabIndex = 101;
            this.datumOdPrebaraj.Visible = false;
            // 
            // btnPrebaraj
            // 
            this.btnPrebaraj.Location = new System.Drawing.Point(1610, 831);
            this.btnPrebaraj.Name = "btnPrebaraj";
            this.btnPrebaraj.Size = new System.Drawing.Size(218, 42);
            this.btnPrebaraj.TabIndex = 102;
            this.btnPrebaraj.Text = "Пребарај";
            this.btnPrebaraj.UseVisualStyleBackColor = true;
            this.btnPrebaraj.Click += new System.EventHandler(this.btnPrebaraj_Click);
            // 
            // tipPrebaraj
            // 
            this.tipPrebaraj.FormattingEnabled = true;
            this.tipPrebaraj.Items.AddRange(new object[] {
            "kirija",
            "voda",
            "struja",
            "danok",
            "komunalii",
            "internet",
            "telefon"});
            this.tipPrebaraj.Location = new System.Drawing.Point(1609, 602);
            this.tipPrebaraj.Name = "tipPrebaraj";
            this.tipPrebaraj.Size = new System.Drawing.Size(219, 21);
            this.tipPrebaraj.TabIndex = 103;
            this.tipPrebaraj.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1349, 464);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 13);
            this.label13.TabIndex = 87;
            this.label13.Text = "Изберете тип на сметка";
            // 
            // tipVnesi
            // 
            this.tipVnesi.FormattingEnabled = true;
            this.tipVnesi.Items.AddRange(new object[] {
            "kirija",
            "voda",
            "struja",
            "danok",
            "komunalii",
            "internet",
            "telefon"});
            this.tipVnesi.Location = new System.Drawing.Point(38, 547);
            this.tipVnesi.Name = "tipVnesi";
            this.tipVnesi.Size = new System.Drawing.Size(205, 21);
            this.tipVnesi.TabIndex = 104;
            // 
            // sumaOdPrebaraj
            // 
            this.sumaOdPrebaraj.Location = new System.Drawing.Point(1609, 744);
            this.sumaOdPrebaraj.Name = "sumaOdPrebaraj";
            this.sumaOdPrebaraj.Size = new System.Drawing.Size(111, 20);
            this.sumaOdPrebaraj.TabIndex = 106;
            this.sumaOdPrebaraj.Visible = false;
            this.sumaOdPrebaraj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sumaOdPrebaraj_KeyPress);
            // 
            // sumaDoPrebaraj
            // 
            this.sumaDoPrebaraj.Location = new System.Drawing.Point(1726, 744);
            this.sumaDoPrebaraj.Name = "sumaDoPrebaraj";
            this.sumaDoPrebaraj.Size = new System.Drawing.Size(102, 20);
            this.sumaDoPrebaraj.TabIndex = 107;
            this.sumaDoPrebaraj.Visible = false;
            this.sumaDoPrebaraj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sumaDoPrebaraj_KeyPress);
            // 
            // labelSumaOd
            // 
            this.labelSumaOd.AutoSize = true;
            this.labelSumaOd.Location = new System.Drawing.Point(1644, 728);
            this.labelSumaOd.Name = "labelSumaOd";
            this.labelSumaOd.Size = new System.Drawing.Size(21, 13);
            this.labelSumaOd.TabIndex = 108;
            this.labelSumaOd.Text = "Од";
            this.labelSumaOd.Visible = false;
            // 
            // labelSumaDo
            // 
            this.labelSumaDo.AutoSize = true;
            this.labelSumaDo.Location = new System.Drawing.Point(1767, 728);
            this.labelSumaDo.Name = "labelSumaDo";
            this.labelSumaDo.Size = new System.Drawing.Size(22, 13);
            this.labelSumaDo.TabIndex = 109;
            this.labelSumaDo.Text = "До";
            this.labelSumaDo.Visible = false;
            // 
            // zabeleshkaVnesi
            // 
            this.zabeleshkaVnesi.Location = new System.Drawing.Point(37, 631);
            this.zabeleshkaVnesi.Name = "zabeleshkaVnesi";
            this.zabeleshkaVnesi.Size = new System.Drawing.Size(206, 41);
            this.zabeleshkaVnesi.TabIndex = 110;
            this.zabeleshkaVnesi.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(63, 616);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 13);
            this.label23.TabIndex = 98;
            this.label23.Text = "Забелешка за сметка";
            // 
            // btIzberiSlika
            // 
            this.btIzberiSlika.Location = new System.Drawing.Point(37, 678);
            this.btIzberiSlika.Name = "btIzberiSlika";
            this.btIzberiSlika.Size = new System.Drawing.Size(206, 49);
            this.btIzberiSlika.TabIndex = 111;
            this.btIzberiSlika.Text = "Изберете слика";
            this.btIzberiSlika.UseVisualStyleBackColor = true;
            this.btIzberiSlika.Click += new System.EventHandler(this.btIzberiSlika_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(269, 440);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(291, 498);
            this.pictureBox.TabIndex = 112;
            this.pictureBox.TabStop = false;
            // 
            // tbSlika
            // 
            this.tbSlika.Location = new System.Drawing.Point(56, 918);
            this.tbSlika.Name = "tbSlika";
            this.tbSlika.Size = new System.Drawing.Size(125, 20);
            this.tbSlika.TabIndex = 113;
            this.tbSlika.Visible = false;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(859, 443);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(395, 495);
            this.axAcroPDF1.TabIndex = 114;
            // 
            // labelBroj
            // 
            this.labelBroj.AutoSize = true;
            this.labelBroj.Location = new System.Drawing.Point(1638, 485);
            this.labelBroj.Name = "labelBroj";
            this.labelBroj.Size = new System.Drawing.Size(132, 13);
            this.labelBroj.TabIndex = 115;
            this.labelBroj.Text = "*последниот број после -";
            this.labelBroj.Visible = false;
            // 
            // datumDoPrebaraj
            // 
            this.datumDoPrebaraj.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumDoPrebaraj.Location = new System.Drawing.Point(1726, 675);
            this.datumDoPrebaraj.Name = "datumDoPrebaraj";
            this.datumDoPrebaraj.Size = new System.Drawing.Size(102, 20);
            this.datumDoPrebaraj.TabIndex = 116;
            this.datumDoPrebaraj.Visible = false;
            // 
            // labelDatumOd
            // 
            this.labelDatumOd.AutoSize = true;
            this.labelDatumOd.Location = new System.Drawing.Point(1651, 660);
            this.labelDatumOd.Name = "labelDatumOd";
            this.labelDatumOd.Size = new System.Drawing.Size(21, 13);
            this.labelDatumOd.TabIndex = 117;
            this.labelDatumOd.Text = "Од";
            this.labelDatumOd.Visible = false;
            // 
            // labelDatumDo
            // 
            this.labelDatumDo.AutoSize = true;
            this.labelDatumDo.Location = new System.Drawing.Point(1787, 659);
            this.labelDatumDo.Name = "labelDatumDo";
            this.labelDatumDo.Size = new System.Drawing.Size(22, 13);
            this.labelDatumDo.TabIndex = 118;
            this.labelDatumDo.Text = "До";
            this.labelDatumDo.Visible = false;
            // 
            // cbBroj
            // 
            this.cbBroj.AutoSize = true;
            this.cbBroj.Location = new System.Drawing.Point(1610, 464);
            this.cbBroj.Name = "cbBroj";
            this.cbBroj.Size = new System.Drawing.Size(232, 17);
            this.cbBroj.TabIndex = 119;
            this.cbBroj.Text = "Пребарај по последниот број на фактура";
            this.cbBroj.UseVisualStyleBackColor = true;
            this.cbBroj.CheckedChanged += new System.EventHandler(this.cbBroj_CheckedChanged);
            // 
            // cbIme
            // 
            this.cbIme.AutoSize = true;
            this.cbIme.Location = new System.Drawing.Point(1610, 529);
            this.cbIme.Name = "cbIme";
            this.cbIme.Size = new System.Drawing.Size(165, 17);
            this.cbIme.TabIndex = 120;
            this.cbIme.Text = "Пребарај по име на примач";
            this.cbIme.UseVisualStyleBackColor = true;
            this.cbIme.CheckedChanged += new System.EventHandler(this.cbIme_CheckedChanged);
            // 
            // cbTip
            // 
            this.cbTip.AutoSize = true;
            this.cbTip.Location = new System.Drawing.Point(1609, 579);
            this.cbTip.Name = "cbTip";
            this.cbTip.Size = new System.Drawing.Size(107, 17);
            this.cbTip.TabIndex = 121;
            this.cbTip.Text = "Пребарај по тип";
            this.cbTip.UseVisualStyleBackColor = true;
            this.cbTip.CheckedChanged += new System.EventHandler(this.cbTip_CheckedChanged);
            // 
            // cbDatum
            // 
            this.cbDatum.AutoSize = true;
            this.cbDatum.Location = new System.Drawing.Point(1609, 632);
            this.cbDatum.Name = "cbDatum";
            this.cbDatum.Size = new System.Drawing.Size(184, 17);
            this.cbDatum.TabIndex = 122;
            this.cbDatum.Text = "Пребарај по датум на плаќање";
            this.cbDatum.UseVisualStyleBackColor = true;
            this.cbDatum.CheckedChanged += new System.EventHandler(this.cbDatum_CheckedChanged);
            // 
            // cbSuma
            // 
            this.cbSuma.AutoSize = true;
            this.cbSuma.Location = new System.Drawing.Point(1610, 705);
            this.cbSuma.Name = "cbSuma";
            this.cbSuma.Size = new System.Drawing.Size(179, 17);
            this.cbSuma.TabIndex = 123;
            this.cbSuma.Text = "Пребарај по сума на плаќање";
            this.cbSuma.UseVisualStyleBackColor = true;
            this.cbSuma.CheckedChanged += new System.EventHandler(this.cbSuma_CheckedChanged);
            // 
            // imePrebaraj
            // 
            this.imePrebaraj.FormattingEnabled = true;
            this.imePrebaraj.Location = new System.Drawing.Point(1609, 549);
            this.imePrebaraj.Name = "imePrebaraj";
            this.imePrebaraj.Size = new System.Drawing.Size(219, 21);
            this.imePrebaraj.TabIndex = 124;
            this.imePrebaraj.SelectedValueChanged += new System.EventHandler(this.imePrebaraj_SelectedValueChanged);
            // 
            // cbSopstvenik
            // 
            this.cbSopstvenik.AutoSize = true;
            this.cbSopstvenik.Location = new System.Drawing.Point(1610, 772);
            this.cbSopstvenik.Name = "cbSopstvenik";
            this.cbSopstvenik.Size = new System.Drawing.Size(147, 17);
            this.cbSopstvenik.TabIndex = 126;
            this.cbSopstvenik.Text = "Пребарај по кој уплатил";
            this.cbSopstvenik.UseVisualStyleBackColor = true;
            this.cbSopstvenik.CheckedChanged += new System.EventHandler(this.cbSopstvenik_CheckedChanged);
            // 
            // sopstvenikPrebaraj
            // 
            this.sopstvenikPrebaraj.FormattingEnabled = true;
            this.sopstvenikPrebaraj.Items.AddRange(new object[] {
            "kirija",
            "voda",
            "struja",
            "danok",
            "komunalii",
            "internet",
            "telefon"});
            this.sopstvenikPrebaraj.Location = new System.Drawing.Point(1610, 795);
            this.sopstvenikPrebaraj.Name = "sopstvenikPrebaraj";
            this.sopstvenikPrebaraj.Size = new System.Drawing.Size(219, 21);
            this.sopstvenikPrebaraj.TabIndex = 127;
            this.sopstvenikPrebaraj.Visible = false;
            // 
            // btnPrebarajSite
            // 
            this.btnPrebarajSite.Location = new System.Drawing.Point(1609, 893);
            this.btnPrebarajSite.Name = "btnPrebarajSite";
            this.btnPrebarajSite.Size = new System.Drawing.Size(219, 45);
            this.btnPrebarajSite.TabIndex = 128;
            this.btnPrebarajSite.Text = "Пребарај ги сите";
            this.btnPrebarajSite.UseVisualStyleBackColor = true;
            this.btnPrebarajSite.Click += new System.EventHandler(this.btnPrebarajSite_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 39);
            this.label11.TabIndex = 129;
            this.label11.Text = "Сметки";
            // 
            // Smetki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1896, 950);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnPrebarajSite);
            this.Controls.Add(this.sopstvenikPrebaraj);
            this.Controls.Add(this.cbSopstvenik);
            this.Controls.Add(this.imePrebaraj);
            this.Controls.Add(this.cbSuma);
            this.Controls.Add(this.cbDatum);
            this.Controls.Add(this.cbTip);
            this.Controls.Add(this.cbIme);
            this.Controls.Add(this.cbBroj);
            this.Controls.Add(this.labelDatumDo);
            this.Controls.Add(this.labelDatumOd);
            this.Controls.Add(this.datumDoPrebaraj);
            this.Controls.Add(this.labelBroj);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.tbSlika);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btIzberiSlika);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.zabeleshkaVnesi);
            this.Controls.Add(this.labelSumaDo);
            this.Controls.Add(this.labelSumaOd);
            this.Controls.Add(this.sumaDoPrebaraj);
            this.Controls.Add(this.sumaOdPrebaraj);
            this.Controls.Add(this.tipVnesi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tipPrebaraj);
            this.Controls.Add(this.btnPrebaraj);
            this.Controls.Add(this.datumOdPrebaraj);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupPlati);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tipPlati);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lvPlateniSmetki);
            this.Controls.Add(this.tipPromeni);
            this.Controls.Add(this.groupPromeni);
            this.Controls.Add(this.lvSmetki);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.btnVnesi);
            this.Controls.Add(this.transakcijaVnesi);
            this.Controls.Add(this.brojPrebaraj);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imeVnesi);
            this.Name = "Smetki";
            this.Text = "Smetki";
            this.Load += new System.EventHandler(this.Smetki_Load);
            this.groupPromeni.ResumeLayout(false);
            this.groupPromeni.PerformLayout();
            this.groupPlati.ResumeLayout(false);
            this.groupPlati.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imeVnesi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox transakcijaPromeni;
        private System.Windows.Forms.TextBox imePromeni;
        private System.Windows.Forms.TextBox brojPrebaraj;
        private System.Windows.Forms.TextBox transakcijaVnesi;
        private System.Windows.Forms.Button btnVnesi;
        private System.Windows.Forms.Button btnPromeni;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.ListView lvSmetki;
        private System.Windows.Forms.GroupBox groupPromeni;
        private System.Windows.Forms.ComboBox tipPromeni;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ListView lvPlateniSmetki;
        private System.Windows.Forms.ComboBox tipPlati;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPlati;
        private System.Windows.Forms.GroupBox groupPlati;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox transakcijaPlati;
        private System.Windows.Forms.TextBox sumaPlati;
        private System.Windows.Forms.TextBox imePlati;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker datumOdPrebaraj;
        private System.Windows.Forms.Button btnPrebaraj;
        private System.Windows.Forms.ComboBox tipPrebaraj;
        private System.Windows.Forms.RichTextBox zabeleshkaPlati;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox tipVnesi;
        private System.Windows.Forms.TextBox sumaOdPrebaraj;
        private System.Windows.Forms.TextBox sumaDoPrebaraj;
        private System.Windows.Forms.Label labelSumaOd;
        private System.Windows.Forms.Label labelSumaDo;
        private System.Windows.Forms.RichTextBox zabeleshkaVnesi;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.RichTextBox zabeleshkaPromeni;
        private System.Windows.Forms.Button btIzberiSlika;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox tbSlika;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Label labelBroj;
        private System.Windows.Forms.DateTimePicker datumDoPrebaraj;
        private System.Windows.Forms.Label labelDatumOd;
        private System.Windows.Forms.Label labelDatumDo;
        private System.Windows.Forms.CheckBox cbBroj;
        private System.Windows.Forms.CheckBox cbIme;
        private System.Windows.Forms.CheckBox cbTip;
        private System.Windows.Forms.CheckBox cbDatum;
        private System.Windows.Forms.CheckBox cbSuma;
        private System.Windows.Forms.ComboBox imePrebaraj;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbSopstvenik;
        private System.Windows.Forms.ComboBox sopstvenikPrebaraj;
        private System.Windows.Forms.Button btnPrebarajSite;
        private System.Windows.Forms.Label label11;
    }
}