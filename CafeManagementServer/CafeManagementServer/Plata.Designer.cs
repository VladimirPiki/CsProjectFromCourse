namespace CafeManagementServer
{
    partial class Plata
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
            this.label1 = new System.Windows.Forms.Label();
            this.lvVraboteni = new System.Windows.Forms.ListView();
            this.lvPlata = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.vraboten = new System.Windows.Forms.ComboBox();
            this.bonusPlata = new System.Windows.Forms.TextBox();
            this.redovnostPlata = new System.Windows.Forms.TextBox();
            this.bolovanje = new System.Windows.Forms.TextBox();
            this.zadrshki = new System.Windows.Forms.TextBox();
            this.zabeleshka = new System.Windows.Forms.RichTextBox();
            this.btnPlata = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.prikaziPlata = new System.Windows.Forms.Label();
            this.transakciskaSmetka = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.vremePlata = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Плата";
            // 
            // lvVraboteni
            // 
            this.lvVraboteni.HideSelection = false;
            this.lvVraboteni.Location = new System.Drawing.Point(376, 49);
            this.lvVraboteni.MultiSelect = false;
            this.lvVraboteni.Name = "lvVraboteni";
            this.lvVraboteni.Size = new System.Drawing.Size(1112, 231);
            this.lvVraboteni.TabIndex = 1;
            this.lvVraboteni.UseCompatibleStateImageBehavior = false;
            this.lvVraboteni.SelectedIndexChanged += new System.EventHandler(this.lvVraboteni_SelectedIndexChanged);
            this.lvVraboteni.DoubleClick += new System.EventHandler(this.lvVraboteni_DoubleClick);
            // 
            // lvPlata
            // 
            this.lvPlata.HideSelection = false;
            this.lvPlata.Location = new System.Drawing.Point(376, 319);
            this.lvPlata.Name = "lvPlata";
            this.lvPlata.Size = new System.Drawing.Size(1112, 390);
            this.lvPlata.TabIndex = 2;
            this.lvPlata.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Избери вработен";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Основна плата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Бонус на плата";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Редовност на плата";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Боледување";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Останати задршки на плата";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(85, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Забелешка за внесување на плаа";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(111, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 25);
            this.label9.TabIndex = 10;
            this.label9.Text = "Внеси плата";
            // 
            // vraboten
            // 
            this.vraboten.FormattingEnabled = true;
            this.vraboten.Location = new System.Drawing.Point(217, 179);
            this.vraboten.Name = "vraboten";
            this.vraboten.Size = new System.Drawing.Size(121, 21);
            this.vraboten.TabIndex = 11;
            this.vraboten.Text = "Изберете вработен";
            this.vraboten.SelectedIndexChanged += new System.EventHandler(this.vraboten_SelectedIndexChanged);
            this.vraboten.ValueMemberChanged += new System.EventHandler(this.vraboten_ValueMemberChanged);
            this.vraboten.SelectedValueChanged += new System.EventHandler(this.vraboten_SelectedValueChanged);
            // 
            // bonusPlata
            // 
            this.bonusPlata.Location = new System.Drawing.Point(217, 314);
            this.bonusPlata.Name = "bonusPlata";
            this.bonusPlata.Size = new System.Drawing.Size(121, 20);
            this.bonusPlata.TabIndex = 13;
            this.bonusPlata.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bonusPlata_KeyPress);
            // 
            // redovnostPlata
            // 
            this.redovnostPlata.Location = new System.Drawing.Point(11, 311);
            this.redovnostPlata.Name = "redovnostPlata";
            this.redovnostPlata.Size = new System.Drawing.Size(124, 20);
            this.redovnostPlata.TabIndex = 14;
            this.redovnostPlata.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.redovnostPlata_KeyPress);
            // 
            // bolovanje
            // 
            this.bolovanje.Location = new System.Drawing.Point(11, 393);
            this.bolovanje.Name = "bolovanje";
            this.bolovanje.Size = new System.Drawing.Size(121, 20);
            this.bolovanje.TabIndex = 15;
            this.bolovanje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bolovanje_KeyPress);
            // 
            // zadrshki
            // 
            this.zadrshki.Location = new System.Drawing.Point(217, 395);
            this.zadrshki.Name = "zadrshki";
            this.zadrshki.Size = new System.Drawing.Size(121, 20);
            this.zadrshki.TabIndex = 16;
            this.zadrshki.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zadrshki_KeyPress);
            // 
            // zabeleshka
            // 
            this.zabeleshka.Location = new System.Drawing.Point(11, 465);
            this.zabeleshka.Name = "zabeleshka";
            this.zabeleshka.Size = new System.Drawing.Size(327, 96);
            this.zabeleshka.TabIndex = 17;
            this.zabeleshka.Text = "";
            // 
            // btnPlata
            // 
            this.btnPlata.Location = new System.Drawing.Point(116, 592);
            this.btnPlata.Name = "btnPlata";
            this.btnPlata.Size = new System.Drawing.Size(121, 62);
            this.btnPlata.TabIndex = 18;
            this.btnPlata.Text = "Внеси плата";
            this.btnPlata.UseVisualStyleBackColor = true;
            this.btnPlata.Click += new System.EventHandler(this.btnPlata_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(765, 715);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(290, 56);
            this.btnSelect.TabIndex = 19;
            this.btnSelect.Text = "Прикажи ги сите исплатени плати";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // prikaziPlata
            // 
            this.prikaziPlata.AutoSize = true;
            this.prikaziPlata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prikaziPlata.Location = new System.Drawing.Point(26, 245);
            this.prikaziPlata.Name = "prikaziPlata";
            this.prikaziPlata.Size = new System.Drawing.Size(60, 20);
            this.prikaziPlata.TabIndex = 20;
            this.prikaziPlata.Text = "label10";
            // 
            // transakciskaSmetka
            // 
            this.transakciskaSmetka.AutoSize = true;
            this.transakciskaSmetka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transakciskaSmetka.Location = new System.Drawing.Point(217, 245);
            this.transakciskaSmetka.Name = "transakciskaSmetka";
            this.transakciskaSmetka.Size = new System.Drawing.Size(60, 20);
            this.transakciskaSmetka.TabIndex = 21;
            this.transakciskaSmetka.Text = "label10";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Трансакциска сметка";
            // 
            // vremePlata
            // 
            this.vremePlata.CustomFormat = "dd-mm-yyyy";
            this.vremePlata.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.vremePlata.Location = new System.Drawing.Point(11, 180);
            this.vremePlata.Name = "vremePlata";
            this.vremePlata.Size = new System.Drawing.Size(124, 20);
            this.vremePlata.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Изберете ден";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(708, 292);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(397, 24);
            this.label11.TabIndex = 25;
            this.label11.Text = "Листа со сите досегашни исплатени плати";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(703, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(402, 24);
            this.label13.TabIndex = 26;
            this.label13.Text = "Листа на сите вработени со нивните плати";
            // 
            // Plata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1535, 783);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.vremePlata);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.transakciskaSmetka);
            this.Controls.Add(this.prikaziPlata);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnPlata);
            this.Controls.Add(this.zabeleshka);
            this.Controls.Add(this.zadrshki);
            this.Controls.Add(this.bolovanje);
            this.Controls.Add(this.redovnostPlata);
            this.Controls.Add(this.bonusPlata);
            this.Controls.Add(this.vraboten);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvPlata);
            this.Controls.Add(this.lvVraboteni);
            this.Controls.Add(this.label1);
            this.Name = "Plata";
            this.Text = "Plata";
            this.Load += new System.EventHandler(this.Plata_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvVraboteni;
        private System.Windows.Forms.ListView lvPlata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox vraboten;
        private System.Windows.Forms.TextBox bonusPlata;
        private System.Windows.Forms.TextBox redovnostPlata;
        private System.Windows.Forms.TextBox bolovanje;
        private System.Windows.Forms.TextBox zadrshki;
        private System.Windows.Forms.RichTextBox zabeleshka;
        private System.Windows.Forms.Button btnPlata;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label prikaziPlata;
        private System.Windows.Forms.Label transakciskaSmetka;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker vremePlata;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
    }
}