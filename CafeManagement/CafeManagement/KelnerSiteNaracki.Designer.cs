namespace CafeManagement
{
    partial class KelnerSiteNaracki
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
            this.lvSite = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOsvezi = new System.Windows.Forms.Button();
            this.rbPromet = new System.Windows.Forms.RichTextBox();
            this.btnPredajPromet = new System.Windows.Forms.Button();
            this.lvPoedinecno = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStornirajSmetka = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvSite
            // 
            this.lvSite.HideSelection = false;
            this.lvSite.Location = new System.Drawing.Point(24, 63);
            this.lvSite.MultiSelect = false;
            this.lvSite.Name = "lvSite";
            this.lvSite.Size = new System.Drawing.Size(1527, 255);
            this.lvSite.TabIndex = 0;
            this.lvSite.UseCompatibleStateImageBehavior = false;
            this.lvSite.SelectedIndexChanged += new System.EventHandler(this.lvSite_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(698, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Листа со сите сметки за денешен ден";
            // 
            // btnOsvezi
            // 
            this.btnOsvezi.Location = new System.Drawing.Point(344, 644);
            this.btnOsvezi.Name = "btnOsvezi";
            this.btnOsvezi.Size = new System.Drawing.Size(265, 70);
            this.btnOsvezi.TabIndex = 2;
            this.btnOsvezi.Text = "Вклучете ги потворно податоците";
            this.btnOsvezi.UseVisualStyleBackColor = true;
            this.btnOsvezi.Click += new System.EventHandler(this.btnOsvezi_Click);
            // 
            // rbPromet
            // 
            this.rbPromet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPromet.Location = new System.Drawing.Point(854, 644);
            this.rbPromet.Name = "rbPromet";
            this.rbPromet.ReadOnly = true;
            this.rbPromet.Size = new System.Drawing.Size(327, 70);
            this.rbPromet.TabIndex = 3;
            this.rbPromet.Text = "";
            this.rbPromet.TextChanged += new System.EventHandler(this.rbPromet_TextChanged);
            // 
            // btnPredajPromet
            // 
            this.btnPredajPromet.Location = new System.Drawing.Point(1205, 644);
            this.btnPredajPromet.Name = "btnPredajPromet";
            this.btnPredajPromet.Size = new System.Drawing.Size(346, 70);
            this.btnPredajPromet.TabIndex = 4;
            this.btnPredajPromet.Text = "Предај промет";
            this.btnPredajPromet.UseVisualStyleBackColor = true;
            this.btnPredajPromet.Click += new System.EventHandler(this.btnPredajPromet_Click);
            // 
            // lvPoedinecno
            // 
            this.lvPoedinecno.HideSelection = false;
            this.lvPoedinecno.Location = new System.Drawing.Point(24, 360);
            this.lvPoedinecno.Name = "lvPoedinecno";
            this.lvPoedinecno.Size = new System.Drawing.Size(1527, 243);
            this.lvPoedinecno.TabIndex = 5;
            this.lvPoedinecno.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(698, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Листа со секоја порачка поеднечно";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(964, 606);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(449, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Целокупен промет од денешниот ден во денари";
            // 
            // btnStornirajSmetka
            // 
            this.btnStornirajSmetka.Location = new System.Drawing.Point(12, 644);
            this.btnStornirajSmetka.Name = "btnStornirajSmetka";
            this.btnStornirajSmetka.Size = new System.Drawing.Size(273, 70);
            this.btnStornirajSmetka.TabIndex = 8;
            this.btnStornirajSmetka.Text = "Сторнирај сметка";
            this.btnStornirajSmetka.UseVisualStyleBackColor = true;
            this.btnStornirajSmetka.Click += new System.EventHandler(this.btnStornirajSmetka_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(709, 39);
            this.label4.TabIndex = 9;
            this.label4.Text = "Сите нарачки на келнерот за денешен ден";
            // 
            // KelnerSiteNaracki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1581, 737);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStornirajSmetka);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvPoedinecno);
            this.Controls.Add(this.btnPredajPromet);
            this.Controls.Add(this.rbPromet);
            this.Controls.Add(this.btnOsvezi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvSite);
            this.Name = "KelnerSiteNaracki";
            this.Text = "KelnerSiteNaracki";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KelnerSiteNaracki_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KelnerSiteNaracki_FormClosed);
            this.Load += new System.EventHandler(this.KelnerSiteNaracki_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOsvezi;
        private System.Windows.Forms.RichTextBox rbPromet;
        private System.Windows.Forms.Button btnPredajPromet;
        private System.Windows.Forms.ListView lvPoedinecno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStornirajSmetka;
        private System.Windows.Forms.Label label4;
    }
}