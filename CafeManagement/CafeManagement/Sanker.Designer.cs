namespace CafeManagement
{
    partial class Sanker
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
            this.btnVnesiPoracka = new System.Windows.Forms.Button();
            this.tbVnesiKolicina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVnesiIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
<<<<<<< HEAD
            this.label3 = new System.Windows.Forms.Label();
            this.tbZabeleshka = new System.Windows.Forms.RichTextBox();
            this.btnOsvezi = new System.Windows.Forms.Button();
            this.btnPredajSostojba = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
=======
            this.btnIzbrisiPoracka = new System.Windows.Forms.Button();
            this.btnOdlogirajSe = new System.Windows.Forms.Button();
>>>>>>> e00b2cb2d132d69e62ff770624fe776bda966ff3
            this.SuspendLayout();
            // 
            // btnVnesiPoracka
            // 
            this.btnVnesiPoracka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnVnesiPoracka.ForeColor = System.Drawing.Color.White;
            this.btnVnesiPoracka.Image = global::CafeManagement.Properties.Resources._4419157;
            this.btnVnesiPoracka.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVnesiPoracka.Location = new System.Drawing.Point(29, 169);
            this.btnVnesiPoracka.Name = "btnVnesiPoracka";
            this.btnVnesiPoracka.Size = new System.Drawing.Size(227, 61);
            this.btnVnesiPoracka.TabIndex = 23;
            this.btnVnesiPoracka.Text = "Внеси порачка";
            this.btnVnesiPoracka.UseVisualStyleBackColor = true;
            this.btnVnesiPoracka.Click += new System.EventHandler(this.btnVnesiPoracka_Click);
            // 
            // tbVnesiKolicina
            // 
            this.tbVnesiKolicina.Location = new System.Drawing.Point(29, 128);
            this.tbVnesiKolicina.Name = "tbVnesiKolicina";
            this.tbVnesiKolicina.Size = new System.Drawing.Size(227, 20);
            this.tbVnesiKolicina.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(29, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "Внеси количина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Внеси шифра";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbVnesiIme
            // 
            this.tbVnesiIme.Location = new System.Drawing.Point(29, 73);
            this.tbVnesiIme.Name = "tbVnesiIme";
            this.tbVnesiIme.Size = new System.Drawing.Size(227, 20);
            this.tbVnesiIme.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
<<<<<<< HEAD
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(645, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 25);
=======
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::CafeManagement.Properties.Resources._4419157;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(521, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 22);
>>>>>>> e00b2cb2d132d69e62ff770624fe776bda966ff3
            this.label1.TabIndex = 26;
            this.label1.Text = "Листа со сите порачки за денешен ден";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
<<<<<<< HEAD
            this.listView1.Location = new System.Drawing.Point(12, 66);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1549, 569);
=======
            this.listView1.Location = new System.Drawing.Point(273, 73);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(758, 346);
>>>>>>> e00b2cb2d132d69e62ff770624fe776bda966ff3
            this.listView1.TabIndex = 27;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnIzbrisiPoracka
            // 
<<<<<<< HEAD
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1027, 638);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Доколку имате забелешка внесете ја";
=======
            this.btnIzbrisiPoracka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnIzbrisiPoracka.ForeColor = System.Drawing.Color.White;
            this.btnIzbrisiPoracka.Image = global::CafeManagement.Properties.Resources._4419157;
            this.btnIzbrisiPoracka.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIzbrisiPoracka.Location = new System.Drawing.Point(29, 236);
            this.btnIzbrisiPoracka.Name = "btnIzbrisiPoracka";
            this.btnIzbrisiPoracka.Size = new System.Drawing.Size(227, 61);
            this.btnIzbrisiPoracka.TabIndex = 28;
            this.btnIzbrisiPoracka.Text = "Избриши порачка";
            this.btnIzbrisiPoracka.UseVisualStyleBackColor = true;
>>>>>>> e00b2cb2d132d69e62ff770624fe776bda966ff3
            // 
            // btnOdlogirajSe
            // 
<<<<<<< HEAD
            this.tbZabeleshka.Location = new System.Drawing.Point(942, 665);
            this.tbZabeleshka.Name = "tbZabeleshka";
            this.tbZabeleshka.Size = new System.Drawing.Size(326, 131);
            this.tbZabeleshka.TabIndex = 34;
            this.tbZabeleshka.Text = "";
            // 
            // btnOsvezi
            // 
            this.btnOsvezi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOsvezi.Location = new System.Drawing.Point(600, 665);
            this.btnOsvezi.Name = "btnOsvezi";
            this.btnOsvezi.Size = new System.Drawing.Size(296, 123);
            this.btnOsvezi.TabIndex = 52;
            this.btnOsvezi.Text = "Вклучете ги повторно податоци";
            this.btnOsvezi.UseVisualStyleBackColor = true;
            this.btnOsvezi.Click += new System.EventHandler(this.btnOsvezi_Click);
            // 
            // btnPredajSostojba
            // 
            this.btnPredajSostojba.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPredajSostojba.Location = new System.Drawing.Point(1284, 665);
            this.btnPredajSostojba.Name = "btnPredajSostojba";
            this.btnPredajSostojba.Size = new System.Drawing.Size(277, 131);
            this.btnPredajSostojba.TabIndex = 53;
            this.btnPredajSostojba.Text = "Предај состојба";
            this.btnPredajSostojba.UseVisualStyleBackColor = true;
            this.btnPredajSostojba.Click += new System.EventHandler(this.btnPredajSostojba_Click);
=======
            this.btnOdlogirajSe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnOdlogirajSe.ForeColor = System.Drawing.Color.White;
            this.btnOdlogirajSe.Image = global::CafeManagement.Properties.Resources._4419157;
            this.btnOdlogirajSe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOdlogirajSe.Location = new System.Drawing.Point(29, 303);
            this.btnOdlogirajSe.Name = "btnOdlogirajSe";
            this.btnOdlogirajSe.Size = new System.Drawing.Size(227, 61);
            this.btnOdlogirajSe.TabIndex = 29;
            this.btnOdlogirajSe.Text = "Одлогирај се";
            this.btnOdlogirajSe.UseVisualStyleBackColor = true;
>>>>>>> e00b2cb2d132d69e62ff770624fe776bda966ff3
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 39);
            this.label2.TabIndex = 54;
            this.label2.Text = "Шанкер";
            // 
            // Sanker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1573, 808);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPredajSostojba);
            this.Controls.Add(this.btnOsvezi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbZabeleshka);
=======
            this.BackgroundImage = global::CafeManagement.Properties.Resources._4419157;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1077, 474);
            this.Controls.Add(this.btnOdlogirajSe);
            this.Controls.Add(this.btnIzbrisiPoracka);
>>>>>>> e00b2cb2d132d69e62ff770624fe776bda966ff3
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVnesiPoracka);
            this.Controls.Add(this.tbVnesiKolicina);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbVnesiIme);
            this.Name = "Sanker";
            this.Text = "Sanker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVnesiPoracka;
        private System.Windows.Forms.TextBox tbVnesiKolicina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVnesiIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
<<<<<<< HEAD
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox tbZabeleshka;
        private System.Windows.Forms.Button btnOsvezi;
        private System.Windows.Forms.Button btnPredajSostojba;
        private System.Windows.Forms.Label label2;
=======
        private System.Windows.Forms.Button btnIzbrisiPoracka;
        private System.Windows.Forms.Button btnOdlogirajSe;
>>>>>>> e00b2cb2d132d69e62ff770624fe776bda966ff3
    }
}