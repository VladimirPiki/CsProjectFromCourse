namespace CafeManagement
{
    partial class MenadzerMomentalnaSostojba
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
            this.tbPrebarajIme = new System.Windows.Forms.TextBox();
            this.tbPrebarajKolicina = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPrebarajPrezime = new System.Windows.Forms.ComboBox();
            this.btnPrebaraj = new System.Windows.Forms.Button();
            this.cbPrebarajPoKompanija = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(238, 59);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(854, 361);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::CafeManagement.Properties.Resources._4419157;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(492, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Моментална состојба на сите производи";
            // 
            // tbPrebarajIme
            // 
            this.tbPrebarajIme.Location = new System.Drawing.Point(22, 104);
            this.tbPrebarajIme.Name = "tbPrebarajIme";
            this.tbPrebarajIme.Size = new System.Drawing.Size(200, 20);
            this.tbPrebarajIme.TabIndex = 2;
            // 
            // tbPrebarajKolicina
            // 
            this.tbPrebarajKolicina.Location = new System.Drawing.Point(22, 235);
            this.tbPrebarajKolicina.Name = "tbPrebarajKolicina";
            this.tbPrebarajKolicina.Size = new System.Drawing.Size(200, 20);
            this.tbPrebarajKolicina.TabIndex = 4;
            this.tbPrebarajKolicina.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пребарај по име";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пребарај по тип";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(22, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пребарај по количина";
            // 
            // cbPrebarajPrezime
            // 
            this.cbPrebarajPrezime.FormattingEnabled = true;
            this.cbPrebarajPrezime.Items.AddRange(new object[] {
            "Алкохолни пијалоци",
            "Безлкохолни пијалоци",
            "Кафе ",
            "Mлеко",
            "Шеќер",
            "Хиегиена"});
            this.cbPrebarajPrezime.Location = new System.Drawing.Point(22, 164);
            this.cbPrebarajPrezime.Name = "cbPrebarajPrezime";
            this.cbPrebarajPrezime.Size = new System.Drawing.Size(200, 21);
            this.cbPrebarajPrezime.TabIndex = 9;
            this.cbPrebarajPrezime.Text = "Изберете тип за пребарување";
            // 
            // btnPrebaraj
            // 
            this.btnPrebaraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPrebaraj.ForeColor = System.Drawing.Color.White;
            this.btnPrebaraj.Image = global::CafeManagement.Properties.Resources._4419157;
            this.btnPrebaraj.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrebaraj.Location = new System.Drawing.Point(12, 360);
            this.btnPrebaraj.Name = "btnPrebaraj";
            this.btnPrebaraj.Size = new System.Drawing.Size(210, 60);
            this.btnPrebaraj.TabIndex = 10;
            this.btnPrebaraj.Text = "Пребарај";
            this.btnPrebaraj.UseVisualStyleBackColor = true;
            this.btnPrebaraj.Click += new System.EventHandler(this.btnPrebaraj_Click);
            // 
            // cbPrebarajPoKompanija
            // 
            this.cbPrebarajPoKompanija.FormattingEnabled = true;
            this.cbPrebarajPoKompanija.Items.AddRange(new object[] {
            "Битолска",
            "Прилепска",
            "Скопска",
            "Изворска",
            "Бразилско Кафе",
            "Македонско Кафе",
            "Макотехна",
            "Моја хигиена"});
            this.cbPrebarajPoKompanija.Location = new System.Drawing.Point(22, 291);
            this.cbPrebarajPoKompanija.Name = "cbPrebarajPoKompanija";
            this.cbPrebarajPoKompanija.Size = new System.Drawing.Size(200, 21);
            this.cbPrebarajPoKompanija.TabIndex = 18;
            this.cbPrebarajPoKompanija.Text = "Пребарај по компанија";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(22, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "Пребарај по компанија";
            // 
            // MenadzerMomentalnaSostojba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CafeManagement.Properties.Resources._4419157;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1118, 480);
            this.Controls.Add(this.cbPrebarajPoKompanija);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPrebaraj);
            this.Controls.Add(this.cbPrebarajPrezime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPrebarajKolicina);
            this.Controls.Add(this.tbPrebarajIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "MenadzerMomentalnaSostojba";
            this.Text = "MenadzerMomentalnaSostojba";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPrebarajIme;
        private System.Windows.Forms.TextBox tbPrebarajKolicina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPrebarajPrezime;
        private System.Windows.Forms.Button btnPrebaraj;
        private System.Windows.Forms.ComboBox cbPrebarajPoKompanija;
        private System.Windows.Forms.Label label5;
    }
}