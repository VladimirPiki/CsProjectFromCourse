namespace CafeManagement
{
    partial class MenadzerNapraviNabavka
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbVnesiIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbVnesiTip = new System.Windows.Forms.ComboBox();
            this.tbVnesiKolicina = new System.Windows.Forms.TextBox();
            this.btnVnesiNabavka = new System.Windows.Forms.Button();
            this.btnIspratiNabavka = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbVnesiKompanija = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIzbrisiNabavka = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(256, 78);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(716, 329);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::CafeManagement.Properties.Resources._4419157;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(468, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Направи набавка на производи\r\n";
            // 
            // tbVnesiIme
            // 
            this.tbVnesiIme.Location = new System.Drawing.Point(12, 78);
            this.tbVnesiIme.Name = "tbVnesiIme";
            this.tbVnesiIme.Size = new System.Drawing.Size(227, 20);
            this.tbVnesiIme.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Внеси име";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Внеси тип";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Внеси количина";
            // 
            // cbVnesiTip
            // 
            this.cbVnesiTip.FormattingEnabled = true;
            this.cbVnesiTip.Items.AddRange(new object[] {
            "Алкохолни пијалоци",
            "Безлкохолни пијалоци",
            "Кафе ",
            "Mлеко",
            "Шеќер",
            "Хиегиена"});
            this.cbVnesiTip.Location = new System.Drawing.Point(12, 143);
            this.cbVnesiTip.Name = "cbVnesiTip";
            this.cbVnesiTip.Size = new System.Drawing.Size(227, 21);
            this.cbVnesiTip.TabIndex = 10;
            this.cbVnesiTip.Text = "Внеси тип на производи";
            this.cbVnesiTip.SelectedIndexChanged += new System.EventHandler(this.cbVnesiTip_SelectedIndexChanged);
            // 
            // tbVnesiKolicina
            // 
            this.tbVnesiKolicina.Location = new System.Drawing.Point(12, 214);
            this.tbVnesiKolicina.Name = "tbVnesiKolicina";
            this.tbVnesiKolicina.Size = new System.Drawing.Size(227, 20);
            this.tbVnesiKolicina.TabIndex = 11;
            // 
            // btnVnesiNabavka
            // 
            this.btnVnesiNabavka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVnesiNabavka.ForeColor = System.Drawing.Color.White;
            this.btnVnesiNabavka.Image = global::CafeManagement.Properties.Resources._4419157;
            this.btnVnesiNabavka.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVnesiNabavka.Location = new System.Drawing.Point(12, 329);
            this.btnVnesiNabavka.Name = "btnVnesiNabavka";
            this.btnVnesiNabavka.Size = new System.Drawing.Size(200, 53);
            this.btnVnesiNabavka.TabIndex = 12;
            this.btnVnesiNabavka.Text = "Внеси набавка";
            this.btnVnesiNabavka.UseVisualStyleBackColor = true;
            this.btnVnesiNabavka.Click += new System.EventHandler(this.btnVnesiNabavka_Click);
            // 
            // btnIspratiNabavka
            // 
            this.btnIspratiNabavka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnIspratiNabavka.ForeColor = System.Drawing.Color.White;
            this.btnIspratiNabavka.Image = global::CafeManagement.Properties.Resources._4419157;
            this.btnIspratiNabavka.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIspratiNabavka.Location = new System.Drawing.Point(256, 426);
            this.btnIspratiNabavka.Name = "btnIspratiNabavka";
            this.btnIspratiNabavka.Size = new System.Drawing.Size(227, 72);
            this.btnIspratiNabavka.TabIndex = 13;
            this.btnIspratiNabavka.Text = "Испрати набавка";
            this.btnIspratiNabavka.UseVisualStyleBackColor = true;
            this.btnIspratiNabavka.Click += new System.EventHandler(this.btnIspratiNabavka_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::CafeManagement.Properties.Resources._4419157;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(745, 426);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(227, 72);
            this.button2.TabIndex = 14;
            this.button2.Text = "Испрати фактура";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbVnesiKompanija
            // 
            this.cbVnesiKompanija.FormattingEnabled = true;
            this.cbVnesiKompanija.Items.AddRange(new object[] {
            "Битолска",
            "Прилепска",
            "Скопска",
            "Изворска",
            "Бразилско Кафе",
            "Македонско Кафе",
            "Макотехна",
            "Моја хигиена"});
            this.cbVnesiKompanija.Location = new System.Drawing.Point(12, 285);
            this.cbVnesiKompanija.Name = "cbVnesiKompanija";
            this.cbVnesiKompanija.Size = new System.Drawing.Size(227, 21);
            this.cbVnesiKompanija.TabIndex = 16;
            this.cbVnesiKompanija.Text = "Внеси компанија";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Внеси компанија";
            // 
            // btnIzbrisiNabavka
            // 
            this.btnIzbrisiNabavka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnIzbrisiNabavka.ForeColor = System.Drawing.Color.White;
            this.btnIzbrisiNabavka.Image = global::CafeManagement.Properties.Resources._4419157;
            this.btnIzbrisiNabavka.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIzbrisiNabavka.Location = new System.Drawing.Point(1023, 101);
            this.btnIzbrisiNabavka.Name = "btnIzbrisiNabavka";
            this.btnIzbrisiNabavka.Size = new System.Drawing.Size(202, 66);
            this.btnIzbrisiNabavka.TabIndex = 17;
            this.btnIzbrisiNabavka.Text = "Избриши производ";
            this.btnIzbrisiNabavka.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(978, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Со селектирање во табелата производи\r\n";
            // 
            // MenadzerNapraviNabavka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CafeManagement.Properties.Resources._4419157;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1265, 544);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnIzbrisiNabavka);
            this.Controls.Add(this.cbVnesiKompanija);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnIspratiNabavka);
            this.Controls.Add(this.btnVnesiNabavka);
            this.Controls.Add(this.tbVnesiKolicina);
            this.Controls.Add(this.cbVnesiTip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbVnesiIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "MenadzerNapraviNabavka";
            this.Text = "MenadzerNapraviNabavka";
            this.Load += new System.EventHandler(this.MenadzerNapraviNabavka_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVnesiIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbVnesiTip;
        private System.Windows.Forms.TextBox tbVnesiKolicina;
        private System.Windows.Forms.Button btnVnesiNabavka;
        private System.Windows.Forms.Button btnIspratiNabavka;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbVnesiKompanija;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnIzbrisiNabavka;
        private System.Windows.Forms.Label label6;
    }
}