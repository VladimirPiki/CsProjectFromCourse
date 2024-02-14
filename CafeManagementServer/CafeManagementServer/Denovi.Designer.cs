namespace CafeManagementServer
{
    partial class Denovi
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
            this.lvMomentalnaSostojba = new System.Windows.Forms.ListView();
            this.lvDodeleniDenovi = new System.Windows.Forms.ListView();
            this.lvIskoristeniDenovi = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prebarajVraboteni = new System.Windows.Forms.ComboBox();
            this.rbDodeliSd = new System.Windows.Forms.RadioButton();
            this.rbIskoristiSd = new System.Windows.Forms.RadioButton();
            this.rbPrebarajSd = new System.Windows.Forms.RadioButton();
            this.btnPrebaraj = new System.Windows.Forms.Button();
            this.groupPrebaraj = new System.Windows.Forms.GroupBox();
            this.groupDodeli = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dodeliPricina = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDodeli = new System.Windows.Forms.Button();
            this.dodeliZabeleshka = new System.Windows.Forms.RichTextBox();
            this.dodeliSd = new System.Windows.Forms.TextBox();
            this.dodeliVraboteni = new System.Windows.Forms.ComboBox();
            this.groupIskoristeniDena = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.iskoristiSdBrojNamena = new System.Windows.Forms.ComboBox();
            this.datumVrakjanje = new System.Windows.Forms.DateTimePicker();
            this.datumDo = new System.Windows.Forms.DateTimePicker();
            this.datumOd = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnIskoristiSd = new System.Windows.Forms.Button();
            this.iskoristiSdZabeleshka = new System.Windows.Forms.RichTextBox();
            this.iskoristiSdBroj = new System.Windows.Forms.TextBox();
            this.iskoristiSdVraboteni = new System.Windows.Forms.ComboBox();
            this.btnOsvezi = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.groupPrebaraj.SuspendLayout();
            this.groupDodeli.SuspendLayout();
            this.groupIskoristeniDena.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMomentalnaSostojba
            // 
            this.lvMomentalnaSostojba.HideSelection = false;
            this.lvMomentalnaSostojba.Location = new System.Drawing.Point(329, 38);
            this.lvMomentalnaSostojba.Name = "lvMomentalnaSostojba";
            this.lvMomentalnaSostojba.Size = new System.Drawing.Size(1057, 240);
            this.lvMomentalnaSostojba.TabIndex = 0;
            this.lvMomentalnaSostojba.UseCompatibleStateImageBehavior = false;
            this.lvMomentalnaSostojba.SelectedIndexChanged += new System.EventHandler(this.lvMomentalnaSostojba_SelectedIndexChanged);
            // 
            // lvDodeleniDenovi
            // 
            this.lvDodeleniDenovi.HideSelection = false;
            this.lvDodeleniDenovi.Location = new System.Drawing.Point(329, 310);
            this.lvDodeleniDenovi.Name = "lvDodeleniDenovi";
            this.lvDodeleniDenovi.Size = new System.Drawing.Size(1057, 228);
            this.lvDodeleniDenovi.TabIndex = 1;
            this.lvDodeleniDenovi.UseCompatibleStateImageBehavior = false;
            this.lvDodeleniDenovi.SelectedIndexChanged += new System.EventHandler(this.lvDodeleniDenovi_SelectedIndexChanged);
            // 
            // lvIskoristeniDenovi
            // 
            this.lvIskoristeniDenovi.HideSelection = false;
            this.lvIskoristeniDenovi.Location = new System.Drawing.Point(329, 568);
            this.lvIskoristeniDenovi.Name = "lvIskoristeniDenovi";
            this.lvIskoristeniDenovi.Size = new System.Drawing.Size(1321, 264);
            this.lvIskoristeniDenovi.TabIndex = 2;
            this.lvIskoristeniDenovi.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(587, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(558, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Листа со вкупниот број на слободни денови на вработените";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(691, 544);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Листа со искористени денови";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(691, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Листа со доделени слободни денови";
            // 
            // prebarajVraboteni
            // 
            this.prebarajVraboteni.FormattingEnabled = true;
            this.prebarajVraboteni.Location = new System.Drawing.Point(14, 31);
            this.prebarajVraboteni.Name = "prebarajVraboteni";
            this.prebarajVraboteni.Size = new System.Drawing.Size(243, 21);
            this.prebarajVraboteni.TabIndex = 6;
            // 
            // rbDodeliSd
            // 
            this.rbDodeliSd.AutoSize = true;
            this.rbDodeliSd.Location = new System.Drawing.Point(17, 80);
            this.rbDodeliSd.Name = "rbDodeliSd";
            this.rbDodeliSd.Size = new System.Drawing.Size(128, 17);
            this.rbDodeliSd.TabIndex = 7;
            this.rbDodeliSd.TabStop = true;
            this.rbDodeliSd.Text = "Внеси слободен ден";
            this.rbDodeliSd.UseVisualStyleBackColor = true;
            this.rbDodeliSd.CheckedChanged += new System.EventHandler(this.rbDodeliSd_CheckedChanged);
            // 
            // rbIskoristiSd
            // 
            this.rbIskoristiSd.AutoSize = true;
            this.rbIskoristiSd.Location = new System.Drawing.Point(17, 112);
            this.rbIskoristiSd.Name = "rbIskoristiSd";
            this.rbIskoristiSd.Size = new System.Drawing.Size(139, 17);
            this.rbIskoristiSd.TabIndex = 8;
            this.rbIskoristiSd.TabStop = true;
            this.rbIskoristiSd.Text = "Внеси искористен ден";
            this.rbIskoristiSd.UseVisualStyleBackColor = true;
            this.rbIskoristiSd.CheckedChanged += new System.EventHandler(this.rbIskoristiSd_CheckedChanged);
            // 
            // rbPrebarajSd
            // 
            this.rbPrebarajSd.AutoSize = true;
            this.rbPrebarajSd.Location = new System.Drawing.Point(17, 146);
            this.rbPrebarajSd.Name = "rbPrebarajSd";
            this.rbPrebarajSd.Size = new System.Drawing.Size(143, 17);
            this.rbPrebarajSd.TabIndex = 9;
            this.rbPrebarajSd.TabStop = true;
            this.rbPrebarajSd.Text = "Пребарај слободен ден";
            this.rbPrebarajSd.UseVisualStyleBackColor = true;
            this.rbPrebarajSd.CheckedChanged += new System.EventHandler(this.rbPrebarajSd_CheckedChanged);
            // 
            // btnPrebaraj
            // 
            this.btnPrebaraj.Location = new System.Drawing.Point(78, 68);
            this.btnPrebaraj.Name = "btnPrebaraj";
            this.btnPrebaraj.Size = new System.Drawing.Size(75, 31);
            this.btnPrebaraj.TabIndex = 10;
            this.btnPrebaraj.Text = "Пребарај";
            this.btnPrebaraj.UseVisualStyleBackColor = true;
            this.btnPrebaraj.Click += new System.EventHandler(this.btnPrebaraj_Click);
            // 
            // groupPrebaraj
            // 
            this.groupPrebaraj.Controls.Add(this.prebarajVraboteni);
            this.groupPrebaraj.Controls.Add(this.btnPrebaraj);
            this.groupPrebaraj.Location = new System.Drawing.Point(12, 183);
            this.groupPrebaraj.Name = "groupPrebaraj";
            this.groupPrebaraj.Size = new System.Drawing.Size(268, 121);
            this.groupPrebaraj.TabIndex = 11;
            this.groupPrebaraj.TabStop = false;
            this.groupPrebaraj.Text = "Пребарај";
            this.groupPrebaraj.Visible = false;
            // 
            // groupDodeli
            // 
            this.groupDodeli.Controls.Add(this.label10);
            this.groupDodeli.Controls.Add(this.dodeliPricina);
            this.groupDodeli.Controls.Add(this.label6);
            this.groupDodeli.Controls.Add(this.label5);
            this.groupDodeli.Controls.Add(this.label4);
            this.groupDodeli.Controls.Add(this.btnDodeli);
            this.groupDodeli.Controls.Add(this.dodeliZabeleshka);
            this.groupDodeli.Controls.Add(this.dodeliSd);
            this.groupDodeli.Controls.Add(this.dodeliVraboteni);
            this.groupDodeli.Location = new System.Drawing.Point(1392, 38);
            this.groupDodeli.Name = "groupDodeli";
            this.groupDodeli.Size = new System.Drawing.Size(258, 500);
            this.groupDodeli.TabIndex = 12;
            this.groupDodeli.TabStop = false;
            this.groupDodeli.Text = "Внеси слободен ден";
            this.groupDodeli.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(56, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Намена на слободни денови";
            // 
            // dodeliPricina
            // 
            this.dodeliPricina.FormattingEnabled = true;
            this.dodeliPricina.Items.AddRange(new object[] {
            "Годишен одмор",
            "Ден во неделата што следува",
            "Награда",
            "Дарување крв",
            "Весели случаеви",
            "Несреќни случаеви"});
            this.dodeliPricina.Location = new System.Drawing.Point(30, 187);
            this.dodeliPricina.Name = "dodeliPricina";
            this.dodeliPricina.Size = new System.Drawing.Size(198, 21);
            this.dodeliPricina.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Внесете забелешка за слободни дена";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Внесете број на  слободни дена";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Изберете корисничко име";
            // 
            // btnDodeli
            // 
            this.btnDodeli.Location = new System.Drawing.Point(46, 371);
            this.btnDodeli.Name = "btnDodeli";
            this.btnDodeli.Size = new System.Drawing.Size(186, 55);
            this.btnDodeli.TabIndex = 3;
            this.btnDodeli.Text = "Внеси слободен ден";
            this.btnDodeli.UseVisualStyleBackColor = true;
            this.btnDodeli.Click += new System.EventHandler(this.btnDodeli_Click);
            // 
            // dodeliZabeleshka
            // 
            this.dodeliZabeleshka.Location = new System.Drawing.Point(42, 255);
            this.dodeliZabeleshka.Name = "dodeliZabeleshka";
            this.dodeliZabeleshka.Size = new System.Drawing.Size(194, 70);
            this.dodeliZabeleshka.TabIndex = 2;
            this.dodeliZabeleshka.Text = "";
            // 
            // dodeliSd
            // 
            this.dodeliSd.Location = new System.Drawing.Point(34, 121);
            this.dodeliSd.Name = "dodeliSd";
            this.dodeliSd.Size = new System.Drawing.Size(198, 20);
            this.dodeliSd.TabIndex = 1;
            this.dodeliSd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dodeliSd_KeyPress);
            // 
            // dodeliVraboteni
            // 
            this.dodeliVraboteni.FormattingEnabled = true;
            this.dodeliVraboteni.Location = new System.Drawing.Point(30, 56);
            this.dodeliVraboteni.Name = "dodeliVraboteni";
            this.dodeliVraboteni.Size = new System.Drawing.Size(198, 21);
            this.dodeliVraboteni.TabIndex = 0;
            // 
            // groupIskoristeniDena
            // 
            this.groupIskoristeniDena.Controls.Add(this.label14);
            this.groupIskoristeniDena.Controls.Add(this.label13);
            this.groupIskoristeniDena.Controls.Add(this.label12);
            this.groupIskoristeniDena.Controls.Add(this.label11);
            this.groupIskoristeniDena.Controls.Add(this.iskoristiSdBrojNamena);
            this.groupIskoristeniDena.Controls.Add(this.datumVrakjanje);
            this.groupIskoristeniDena.Controls.Add(this.datumDo);
            this.groupIskoristeniDena.Controls.Add(this.datumOd);
            this.groupIskoristeniDena.Controls.Add(this.label7);
            this.groupIskoristeniDena.Controls.Add(this.label8);
            this.groupIskoristeniDena.Controls.Add(this.label9);
            this.groupIskoristeniDena.Controls.Add(this.btnIskoristiSd);
            this.groupIskoristeniDena.Controls.Add(this.iskoristiSdZabeleshka);
            this.groupIskoristeniDena.Controls.Add(this.iskoristiSdBroj);
            this.groupIskoristeniDena.Controls.Add(this.iskoristiSdVraboteni);
            this.groupIskoristeniDena.Location = new System.Drawing.Point(12, 310);
            this.groupIskoristeniDena.Name = "groupIskoristeniDena";
            this.groupIskoristeniDena.Size = new System.Drawing.Size(270, 505);
            this.groupIskoristeniDena.TabIndex = 12;
            this.groupIskoristeniDena.TabStop = false;
            this.groupIskoristeniDena.Text = "Внеси искористен ден";
            this.groupIskoristeniDena.Visible = false;
            this.groupIskoristeniDena.Enter += new System.EventHandler(this.groupIskoristeniDena_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(93, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Датум до";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(60, 291);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(184, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Намена на искористени на денови";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(105, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Датум од";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Датум враќање на работа";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // iskoristiSdBrojNamena
            // 
            this.iskoristiSdBrojNamena.FormattingEnabled = true;
            this.iskoristiSdBrojNamena.Items.AddRange(new object[] {
            "Приватни намени",
            "Боловање",
            "Дарување крв"});
            this.iskoristiSdBrojNamena.Location = new System.Drawing.Point(48, 307);
            this.iskoristiSdBrojNamena.Name = "iskoristiSdBrojNamena";
            this.iskoristiSdBrojNamena.Size = new System.Drawing.Size(198, 21);
            this.iskoristiSdBrojNamena.TabIndex = 17;
            this.iskoristiSdBrojNamena.SelectedIndexChanged += new System.EventHandler(this.iskoristiSdBrojNamena_SelectedIndexChanged);
            // 
            // datumVrakjanje
            // 
            this.datumVrakjanje.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumVrakjanje.Location = new System.Drawing.Point(48, 208);
            this.datumVrakjanje.Name = "datumVrakjanje";
            this.datumVrakjanje.Size = new System.Drawing.Size(194, 20);
            this.datumVrakjanje.TabIndex = 16;
            // 
            // datumDo
            // 
            this.datumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumDo.Location = new System.Drawing.Point(48, 153);
            this.datumDo.Name = "datumDo";
            this.datumDo.Size = new System.Drawing.Size(194, 20);
            this.datumDo.TabIndex = 15;
            // 
            // datumOd
            // 
            this.datumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datumOd.Location = new System.Drawing.Point(48, 114);
            this.datumOd.Name = "datumOd";
            this.datumOd.Size = new System.Drawing.Size(196, 20);
            this.datumOd.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Внесете забелешка за слободни дена";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Внесете број на искористени дена";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Изберете корисничко име";
            // 
            // btnIskoristiSd
            // 
            this.btnIskoristiSd.Location = new System.Drawing.Point(50, 432);
            this.btnIskoristiSd.Name = "btnIskoristiSd";
            this.btnIskoristiSd.Size = new System.Drawing.Size(183, 50);
            this.btnIskoristiSd.TabIndex = 10;
            this.btnIskoristiSd.Text = "Внеси искористен ден";
            this.btnIskoristiSd.UseVisualStyleBackColor = true;
            this.btnIskoristiSd.Click += new System.EventHandler(this.btnIskoristiSd_Click);
            // 
            // iskoristiSdZabeleshka
            // 
            this.iskoristiSdZabeleshka.Location = new System.Drawing.Point(50, 363);
            this.iskoristiSdZabeleshka.Name = "iskoristiSdZabeleshka";
            this.iskoristiSdZabeleshka.Size = new System.Drawing.Size(194, 49);
            this.iskoristiSdZabeleshka.TabIndex = 9;
            this.iskoristiSdZabeleshka.Text = "";
            // 
            // iskoristiSdBroj
            // 
            this.iskoristiSdBroj.Location = new System.Drawing.Point(48, 258);
            this.iskoristiSdBroj.Name = "iskoristiSdBroj";
            this.iskoristiSdBroj.Size = new System.Drawing.Size(194, 20);
            this.iskoristiSdBroj.TabIndex = 8;
            this.iskoristiSdBroj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.iskoristiSdBroj_KeyPress);
            // 
            // iskoristiSdVraboteni
            // 
            this.iskoristiSdVraboteni.FormattingEnabled = true;
            this.iskoristiSdVraboteni.Location = new System.Drawing.Point(48, 65);
            this.iskoristiSdVraboteni.Name = "iskoristiSdVraboteni";
            this.iskoristiSdVraboteni.Size = new System.Drawing.Size(192, 21);
            this.iskoristiSdVraboteni.TabIndex = 7;
            // 
            // btnOsvezi
            // 
            this.btnOsvezi.Location = new System.Drawing.Point(188, 89);
            this.btnOsvezi.Name = "btnOsvezi";
            this.btnOsvezi.Size = new System.Drawing.Size(120, 67);
            this.btnOsvezi.TabIndex = 13;
            this.btnOsvezi.Text = "Вклучете ги повторно податоците";
            this.btnOsvezi.UseVisualStyleBackColor = true;
            this.btnOsvezi.Click += new System.EventHandler(this.btnOsvezi_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(5, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 39);
            this.label15.TabIndex = 14;
            this.label15.Text = "Денови";
            // 
            // Denovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1662, 844);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnOsvezi);
            this.Controls.Add(this.groupIskoristeniDena);
            this.Controls.Add(this.groupDodeli);
            this.Controls.Add(this.groupPrebaraj);
            this.Controls.Add(this.rbPrebarajSd);
            this.Controls.Add(this.rbIskoristiSd);
            this.Controls.Add(this.rbDodeliSd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvIskoristeniDenovi);
            this.Controls.Add(this.lvDodeleniDenovi);
            this.Controls.Add(this.lvMomentalnaSostojba);
            this.Name = "Denovi";
            this.Text = "Denovi";
            this.Load += new System.EventHandler(this.Denovi_Load);
            this.groupPrebaraj.ResumeLayout(false);
            this.groupDodeli.ResumeLayout(false);
            this.groupDodeli.PerformLayout();
            this.groupIskoristeniDena.ResumeLayout(false);
            this.groupIskoristeniDena.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMomentalnaSostojba;
        private System.Windows.Forms.ListView lvDodeleniDenovi;
        private System.Windows.Forms.ListView lvIskoristeniDenovi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox prebarajVraboteni;
        private System.Windows.Forms.RadioButton rbDodeliSd;
        private System.Windows.Forms.RadioButton rbIskoristiSd;
        private System.Windows.Forms.RadioButton rbPrebarajSd;
        private System.Windows.Forms.Button btnPrebaraj;
        private System.Windows.Forms.GroupBox groupPrebaraj;
        private System.Windows.Forms.GroupBox groupDodeli;
        private System.Windows.Forms.GroupBox groupIskoristeniDena;
        private System.Windows.Forms.ComboBox dodeliVraboteni;
        private System.Windows.Forms.Button btnDodeli;
        private System.Windows.Forms.RichTextBox dodeliZabeleshka;
        private System.Windows.Forms.TextBox dodeliSd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnIskoristiSd;
        private System.Windows.Forms.RichTextBox iskoristiSdZabeleshka;
        private System.Windows.Forms.TextBox iskoristiSdBroj;
        private System.Windows.Forms.ComboBox iskoristiSdVraboteni;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox iskoristiSdBrojNamena;
        private System.Windows.Forms.DateTimePicker datumVrakjanje;
        private System.Windows.Forms.DateTimePicker datumDo;
        private System.Windows.Forms.DateTimePicker datumOd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox dodeliPricina;
        private System.Windows.Forms.Button btnOsvezi;
        private System.Windows.Forms.Label label15;
    }
}