namespace CafeManagement
{
    partial class Kelner
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbZabeleshka = new System.Windows.Forms.RichTextBox();
            this.lvProizvodi = new System.Windows.Forms.ListView();
            this.lvPoracki = new System.Windows.Forms.ListView();
            this.tbVnesiPoracka = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.tbIzbrisiPoracka = new System.Windows.Forms.Button();
            this.tbIspratiPoracka = new System.Windows.Forms.Button();
            this.btnPecatiFiskalna = new System.Windows.Forms.Button();
            this.btnSiteNaracki = new System.Windows.Forms.Button();
            this.btnOsvezi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Доколку имате забелешка внесете ја";
            // 
            // tbZabeleshka
            // 
            this.tbZabeleshka.Location = new System.Drawing.Point(12, 677);
            this.tbZabeleshka.Name = "tbZabeleshka";
            this.tbZabeleshka.Size = new System.Drawing.Size(220, 125);
            this.tbZabeleshka.TabIndex = 32;
            this.tbZabeleshka.Text = "";
            // 
            // lvProizvodi
            // 
            this.lvProizvodi.HideSelection = false;
            this.lvProizvodi.Location = new System.Drawing.Point(248, 476);
            this.lvProizvodi.MultiSelect = false;
            this.lvProizvodi.Name = "lvProizvodi";
            this.lvProizvodi.Size = new System.Drawing.Size(1560, 387);
            this.lvProizvodi.TabIndex = 34;
            this.lvProizvodi.UseCompatibleStateImageBehavior = false;
            this.lvProizvodi.SelectedIndexChanged += new System.EventHandler(this.lvProizvodi_SelectedIndexChanged);
            this.lvProizvodi.DoubleClick += new System.EventHandler(this.lvProizvodi_DoubleClick);
            // 
            // lvPoracki
            // 
            this.lvPoracki.HideSelection = false;
            this.lvPoracki.Location = new System.Drawing.Point(248, 92);
            this.lvPoracki.MultiSelect = false;
            this.lvPoracki.Name = "lvPoracki";
            this.lvPoracki.Size = new System.Drawing.Size(1560, 341);
            this.lvPoracki.TabIndex = 35;
            this.lvPoracki.UseCompatibleStateImageBehavior = false;
            this.lvPoracki.SelectedIndexChanged += new System.EventHandler(this.lvPoracki_SelectedIndexChanged);
            this.lvPoracki.DoubleClick += new System.EventHandler(this.lvPoracki_DoubleClick);
            // 
            // tbVnesiPoracka
            // 
            this.tbVnesiPoracka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVnesiPoracka.Location = new System.Drawing.Point(12, 246);
            this.tbVnesiPoracka.Name = "tbVnesiPoracka";
            this.tbVnesiPoracka.Size = new System.Drawing.Size(220, 49);
            this.tbVnesiPoracka.TabIndex = 45;
            this.tbVnesiPoracka.Text = "Внеси порачка";
            this.tbVnesiPoracka.UseVisualStyleBackColor = true;
            this.tbVnesiPoracka.Click += new System.EventHandler(this.tbVnesiPoracka_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Внеси количина";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Внеси шифра";
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(12, 203);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(220, 20);
            this.tbKolicina.TabIndex = 42;
            this.tbKolicina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbKolicina_KeyPress);
            // 
            // tbSifra
            // 
            this.tbSifra.Location = new System.Drawing.Point(12, 151);
            this.tbSifra.Name = "tbSifra";
            this.tbSifra.Size = new System.Drawing.Size(220, 20);
            this.tbSifra.TabIndex = 41;
            this.tbSifra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSifra_KeyPress);
            // 
            // tbIzbrisiPoracka
            // 
            this.tbIzbrisiPoracka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIzbrisiPoracka.Location = new System.Drawing.Point(12, 319);
            this.tbIzbrisiPoracka.Name = "tbIzbrisiPoracka";
            this.tbIzbrisiPoracka.Size = new System.Drawing.Size(220, 50);
            this.tbIzbrisiPoracka.TabIndex = 46;
            this.tbIzbrisiPoracka.Text = "Избриши порачка";
            this.tbIzbrisiPoracka.UseVisualStyleBackColor = true;
            this.tbIzbrisiPoracka.Click += new System.EventHandler(this.tbIzbrisiPoracka_Click);
            // 
            // tbIspratiPoracka
            // 
            this.tbIspratiPoracka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIspratiPoracka.Location = new System.Drawing.Point(12, 506);
            this.tbIspratiPoracka.Name = "tbIspratiPoracka";
            this.tbIspratiPoracka.Size = new System.Drawing.Size(220, 54);
            this.tbIspratiPoracka.TabIndex = 47;
            this.tbIspratiPoracka.Text = "Испрати порачка до шанкот";
            this.tbIspratiPoracka.UseVisualStyleBackColor = true;
            this.tbIspratiPoracka.Click += new System.EventHandler(this.tbIspratiPoracka_Click);
            // 
            // btnPecatiFiskalna
            // 
            this.btnPecatiFiskalna.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPecatiFiskalna.Location = new System.Drawing.Point(12, 403);
            this.btnPecatiFiskalna.Name = "btnPecatiFiskalna";
            this.btnPecatiFiskalna.Size = new System.Drawing.Size(220, 59);
            this.btnPecatiFiskalna.TabIndex = 48;
            this.btnPecatiFiskalna.Text = "Печати фискална";
            this.btnPecatiFiskalna.UseVisualStyleBackColor = true;
            this.btnPecatiFiskalna.Click += new System.EventHandler(this.btnPecatiFiskalna_Click);
            // 
            // btnSiteNaracki
            // 
            this.btnSiteNaracki.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiteNaracki.Location = new System.Drawing.Point(1295, 12);
            this.btnSiteNaracki.Name = "btnSiteNaracki";
            this.btnSiteNaracki.Size = new System.Drawing.Size(264, 74);
            this.btnSiteNaracki.TabIndex = 49;
            this.btnSiteNaracki.Text = "Види ги сите нарачки од денешен ден";
            this.btnSiteNaracki.UseVisualStyleBackColor = true;
            this.btnSiteNaracki.Click += new System.EventHandler(this.btnSiteNaracki_Click);
            // 
            // btnOsvezi
            // 
            this.btnOsvezi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOsvezi.Location = new System.Drawing.Point(248, 12);
            this.btnOsvezi.Name = "btnOsvezi";
            this.btnOsvezi.Size = new System.Drawing.Size(275, 74);
            this.btnOsvezi.TabIndex = 51;
            this.btnOsvezi.Text = "Вклучете ги повторно податоци";
            this.btnOsvezi.UseVisualStyleBackColor = true;
            this.btnOsvezi.Click += new System.EventHandler(this.btnOsvezi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(744, 449);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(433, 24);
            this.label4.TabIndex = 52;
            this.label4.Text = "Листа на сите производи достапни за порачка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(766, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(364, 24);
            this.label5.TabIndex = 53;
            this.label5.Text = "Листа со сите производи во порачката";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 24);
            this.label6.TabIndex = 54;
            this.label6.Text = "Направи порачка";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 39);
            this.label7.TabIndex = 55;
            this.label7.Text = "Келнер";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 639);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Доколку имате забелешка внесете ја полето";
            // 
            // Kelner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1832, 865);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOsvezi);
            this.Controls.Add(this.btnSiteNaracki);
            this.Controls.Add(this.btnPecatiFiskalna);
            this.Controls.Add(this.tbIspratiPoracka);
            this.Controls.Add(this.tbIzbrisiPoracka);
            this.Controls.Add(this.tbVnesiPoracka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbKolicina);
            this.Controls.Add(this.tbSifra);
            this.Controls.Add(this.lvPoracki);
            this.Controls.Add(this.lvProizvodi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbZabeleshka);
            this.Name = "Kelner";
            this.Text = "Kelner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kelner_FormClosing);
            this.Load += new System.EventHandler(this.Kelner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tbZabeleshka;
        private System.Windows.Forms.ListView lvProizvodi;
        private System.Windows.Forms.ListView lvPoracki;
        private System.Windows.Forms.Button tbVnesiPoracka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.TextBox tbSifra;
        private System.Windows.Forms.Button tbIzbrisiPoracka;
        private System.Windows.Forms.Button tbIspratiPoracka;
        private System.Windows.Forms.Button btnPecatiFiskalna;
        private System.Windows.Forms.Button btnSiteNaracki;
        private System.Windows.Forms.Button btnOsvezi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}