namespace CafeManagementServer
{
    partial class Nabavka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Nabavka));
            this.lvFakturi = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvKompanii = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.lvNabavka = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.imeProizvod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.transakciskaSmetka = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cenaProizovod = new System.Windows.Forms.TextBox();
            this.kolicinaProizvod = new System.Windows.Forms.TextBox();
            this.btnSendNabavka = new System.Windows.Forms.Button();
            this.btnSendFaktura = new System.Windows.Forms.Button();
            this.kompanii = new System.Windows.Forms.ComboBox();
            this.kompanijName = new System.Windows.Forms.Label();
            this.kompnijaId = new System.Windows.Forms.Label();
            this.btnNovaKompanija = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.zabeleshkaFakturi = new System.Windows.Forms.RichTextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btIzberiSlika = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbSlika = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvFakturi
            // 
            this.lvFakturi.HideSelection = false;
            this.lvFakturi.Location = new System.Drawing.Point(12, 512);
            this.lvFakturi.MultiSelect = false;
            this.lvFakturi.Name = "lvFakturi";
            this.lvFakturi.Size = new System.Drawing.Size(948, 493);
            this.lvFakturi.TabIndex = 0;
            this.lvFakturi.UseCompatibleStateImageBehavior = false;
            this.lvFakturi.SelectedIndexChanged += new System.EventHandler(this.lvFakturi_SelectedIndexChanged);
            this.lvFakturi.DoubleClick += new System.EventHandler(this.lvFakturi_DoubleClick);
            this.lvFakturi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFakturi_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1043, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Листа со сите прозводи во набавката";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Сите Компании";
            // 
            // lvKompanii
            // 
            this.lvKompanii.HideSelection = false;
            this.lvKompanii.Location = new System.Drawing.Point(12, 100);
            this.lvKompanii.Name = "lvKompanii";
            this.lvKompanii.Size = new System.Drawing.Size(601, 383);
            this.lvKompanii.TabIndex = 3;
            this.lvKompanii.UseCompatibleStateImageBehavior = false;
            this.lvKompanii.SelectedIndexChanged += new System.EventHandler(this.lvKompanii_SelectedIndexChanged);
            this.lvKompanii.DoubleClick += new System.EventHandler(this.lvKompanii_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(332, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Избери компанија или дупли клик на листата со сите комапнии";
            // 
            // lvNabavka
            // 
            this.lvNabavka.HideSelection = false;
            this.lvNabavka.Location = new System.Drawing.Point(827, 105);
            this.lvNabavka.Name = "lvNabavka";
            this.lvNabavka.Size = new System.Drawing.Size(723, 378);
            this.lvNabavka.TabIndex = 6;
            this.lvNabavka.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(301, 486);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Листа со сите фактури";
            // 
            // imeProizvod
            // 
            this.imeProizvod.Location = new System.Drawing.Point(14, 57);
            this.imeProizvod.Name = "imeProizvod";
            this.imeProizvod.Size = new System.Drawing.Size(176, 20);
            this.imeProizvod.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Име на производ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Количина на производи";
            // 
            // transakciskaSmetka
            // 
            this.transakciskaSmetka.AutoSize = true;
            this.transakciskaSmetka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transakciskaSmetka.Location = new System.Drawing.Point(9, 182);
            this.transakciskaSmetka.Name = "transakciskaSmetka";
            this.transakciskaSmetka.Size = new System.Drawing.Size(70, 25);
            this.transakciskaSmetka.TabIndex = 11;
            this.transakciskaSmetka.Text = "label7";
            this.transakciskaSmetka.Click += new System.EventHandler(this.transakciskaSmetka_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Набавна цена на прозивод";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Трансакциска сметка";
            // 
            // cenaProizovod
            // 
            this.cenaProizovod.Location = new System.Drawing.Point(14, 96);
            this.cenaProizovod.Name = "cenaProizovod";
            this.cenaProizovod.Size = new System.Drawing.Size(176, 20);
            this.cenaProizovod.TabIndex = 20;
            this.cenaProizovod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cenaProizovod_KeyPress);
            // 
            // kolicinaProizvod
            // 
            this.kolicinaProizvod.Location = new System.Drawing.Point(14, 135);
            this.kolicinaProizvod.Name = "kolicinaProizvod";
            this.kolicinaProizvod.Size = new System.Drawing.Size(176, 20);
            this.kolicinaProizvod.TabIndex = 21;
            this.kolicinaProizvod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kolicinaProizvod_KeyPress);
            // 
            // btnSendNabavka
            // 
            this.btnSendNabavka.Location = new System.Drawing.Point(623, 371);
            this.btnSendNabavka.Name = "btnSendNabavka";
            this.btnSendNabavka.Size = new System.Drawing.Size(194, 54);
            this.btnSendNabavka.TabIndex = 22;
            this.btnSendNabavka.Text = "Внеси производи";
            this.btnSendNabavka.UseVisualStyleBackColor = true;
            this.btnSendNabavka.Click += new System.EventHandler(this.btnSendNabavka_Click);
            // 
            // btnSendFaktura
            // 
            this.btnSendFaktura.Location = new System.Drawing.Point(1556, 389);
            this.btnSendFaktura.Name = "btnSendFaktura";
            this.btnSendFaktura.Size = new System.Drawing.Size(191, 57);
            this.btnSendFaktura.TabIndex = 30;
            this.btnSendFaktura.Text = "Испрати фактура";
            this.btnSendFaktura.UseVisualStyleBackColor = true;
            this.btnSendFaktura.Click += new System.EventHandler(this.btnSendFaktura_Click);
            // 
            // kompanii
            // 
            this.kompanii.FormattingEnabled = true;
            this.kompanii.Location = new System.Drawing.Point(619, 103);
            this.kompanii.Name = "kompanii";
            this.kompanii.Size = new System.Drawing.Size(198, 21);
            this.kompanii.TabIndex = 31;
            this.kompanii.Text = "Изберете компанија";
            this.kompanii.SelectedIndexChanged += new System.EventHandler(this.kompanii_SelectedIndexChanged);
            this.kompanii.SelectionChangeCommitted += new System.EventHandler(this.kompanii_SelectionChangeCommitted);
            this.kompanii.SelectedValueChanged += new System.EventHandler(this.kompanii_SelectedValueChanged);
            this.kompanii.MouseClick += new System.Windows.Forms.MouseEventHandler(this.kompanii_MouseClick);
            // 
            // kompanijName
            // 
            this.kompanijName.AutoSize = true;
            this.kompanijName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kompanijName.Location = new System.Drawing.Point(6, 0);
            this.kompanijName.Name = "kompanijName";
            this.kompanijName.Size = new System.Drawing.Size(70, 25);
            this.kompanijName.TabIndex = 32;
            this.kompanijName.Text = "label7";
            // 
            // kompnijaId
            // 
            this.kompnijaId.AutoSize = true;
            this.kompnijaId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kompnijaId.Location = new System.Drawing.Point(485, 63);
            this.kompnijaId.Name = "kompnijaId";
            this.kompnijaId.Size = new System.Drawing.Size(70, 25);
            this.kompnijaId.TabIndex = 33;
            this.kompnijaId.Text = "label7";
            this.kompnijaId.Visible = false;
            this.kompnijaId.Click += new System.EventHandler(this.kompnijaId_Click);
            // 
            // btnNovaKompanija
            // 
            this.btnNovaKompanija.Location = new System.Drawing.Point(623, 431);
            this.btnNovaKompanija.Name = "btnNovaKompanija";
            this.btnNovaKompanija.Size = new System.Drawing.Size(190, 52);
            this.btnNovaKompanija.TabIndex = 34;
            this.btnNovaKompanija.Text = "Внеси нова нарачка со нова компанија";
            this.btnNovaKompanija.UseVisualStyleBackColor = true;
            this.btnNovaKompanija.Click += new System.EventHandler(this.btnNovaKompanija_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.imeProizvod);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.transakciskaSmetka);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.kompanijName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cenaProizovod);
            this.groupBox1.Controls.Add(this.kolicinaProizvod);
            this.groupBox1.Location = new System.Drawing.Point(623, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 221);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1451, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(320, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Доколку имате забелешка за фактурата запишете во полето";
            // 
            // zabeleshkaFakturi
            // 
            this.zabeleshkaFakturi.Location = new System.Drawing.Point(1556, 105);
            this.zabeleshkaFakturi.Name = "zabeleshkaFakturi";
            this.zabeleshkaFakturi.Size = new System.Drawing.Size(191, 172);
            this.zabeleshkaFakturi.TabIndex = 37;
            this.zabeleshkaFakturi.Text = "";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(1515, 512);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(247, 538);
            this.pictureBox.TabIndex = 91;
            this.pictureBox.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1601, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 92;
            this.label8.Text = "• Слика од компанија";
            // 
            // btIzberiSlika
            // 
            this.btIzberiSlika.Location = new System.Drawing.Point(1556, 315);
            this.btIzberiSlika.Name = "btIzberiSlika";
            this.btIzberiSlika.Size = new System.Drawing.Size(191, 63);
            this.btIzberiSlika.TabIndex = 93;
            this.btIzberiSlika.Text = "Изберете слика";
            this.btIzberiSlika.UseVisualStyleBackColor = true;
            this.btIzberiSlika.Click += new System.EventHandler(this.btIzberiSlika_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tbSlika
            // 
            this.tbSlika.Location = new System.Drawing.Point(871, 486);
            this.tbSlika.Name = "tbSlika";
            this.tbSlika.Size = new System.Drawing.Size(100, 20);
            this.tbSlika.TabIndex = 94;
            this.tbSlika.Visible = false;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(54, 1011);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(702, 39);
            this.btnPrikazi.TabIndex = 99;
            this.btnPrikazi.Text = "Селектирај од листат со сите фактури и прегледај фактура";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(966, 512);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(543, 538);
            this.axAcroPDF1.TabIndex = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 39);
            this.label9.TabIndex = 101;
            this.label9.Text = "Набавка";
            // 
            // Nabavka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1774, 1062);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.axAcroPDF1);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.tbSlika);
            this.Controls.Add(this.btIzberiSlika);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.zabeleshkaFakturi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNovaKompanija);
            this.Controls.Add(this.kompnijaId);
            this.Controls.Add(this.kompanii);
            this.Controls.Add(this.btnSendFaktura);
            this.Controls.Add(this.btnSendNabavka);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvNabavka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvKompanii);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvFakturi);
            this.Name = "Nabavka";
            this.Text = "Nabavka";
            this.Load += new System.EventHandler(this.Nabavka_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvFakturi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvKompanii;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvNabavka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox imeProizvod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label transakciskaSmetka;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox cenaProizovod;
        private System.Windows.Forms.TextBox kolicinaProizvod;
        private System.Windows.Forms.Button btnSendNabavka;
        private System.Windows.Forms.Button btnSendFaktura;
        private System.Windows.Forms.ComboBox kompanii;
        private System.Windows.Forms.Label kompanijName;
        private System.Windows.Forms.Label kompnijaId;
        private System.Windows.Forms.Button btnNovaKompanija;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox zabeleshkaFakturi;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btIzberiSlika;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbSlika;
        private System.Windows.Forms.Button btnPrikazi;
        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Label label9;
    }
}