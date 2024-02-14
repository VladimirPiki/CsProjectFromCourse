namespace CafeManagement
{
    partial class MenadzerKompanii
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnZacuvajNovaKomp = new System.Windows.Forms.Button();
            this.tbImeKompanija = new System.Windows.Forms.TextBox();
            this.tbTransakcija = new System.Windows.Forms.TextBox();
            this.datumSorabotka = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrikazigiSite = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.datumSorabotkaUpdate = new System.Windows.Forms.DateTimePicker();
            this.tbUpdateTransakcija = new System.Windows.Forms.TextBox();
            this.tbUpdateIme = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUpdateStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbUpdateId = new System.Windows.Forms.TextBox();
            this.btnSaveUpdate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(274, 59);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1062, 650);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(604, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Листа со сите компании што имаме соработка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Внеси нова комапнија";
            // 
            // btnZacuvajNovaKomp
            // 
            this.btnZacuvajNovaKomp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZacuvajNovaKomp.Location = new System.Drawing.Point(17, 348);
            this.btnZacuvajNovaKomp.Name = "btnZacuvajNovaKomp";
            this.btnZacuvajNovaKomp.Size = new System.Drawing.Size(230, 68);
            this.btnZacuvajNovaKomp.TabIndex = 3;
            this.btnZacuvajNovaKomp.Text = "Внеси нова компанија";
            this.btnZacuvajNovaKomp.UseVisualStyleBackColor = true;
            this.btnZacuvajNovaKomp.Click += new System.EventHandler(this.btnZacuvajNovaKomp_Click);
            // 
            // tbImeKompanija
            // 
            this.tbImeKompanija.Location = new System.Drawing.Point(17, 193);
            this.tbImeKompanija.Name = "tbImeKompanija";
            this.tbImeKompanija.Size = new System.Drawing.Size(230, 20);
            this.tbImeKompanija.TabIndex = 4;
            // 
            // tbTransakcija
            // 
            this.tbTransakcija.Location = new System.Drawing.Point(17, 253);
            this.tbTransakcija.Name = "tbTransakcija";
            this.tbTransakcija.Size = new System.Drawing.Size(230, 20);
            this.tbTransakcija.TabIndex = 5;
            // 
            // datumSorabotka
            // 
            this.datumSorabotka.CustomFormat = "yyyy-MM-dd";
            this.datumSorabotka.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumSorabotka.Location = new System.Drawing.Point(17, 307);
            this.datumSorabotka.Name = "datumSorabotka";
            this.datumSorabotka.Size = new System.Drawing.Size(230, 20);
            this.datumSorabotka.TabIndex = 6;
            this.datumSorabotka.ValueChanged += new System.EventHandler(this.datumSorabotka_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Име на компанијата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Трансакциска сметка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Датум на склучување на договор";
            // 
            // btnPrikazigiSite
            // 
            this.btnPrikazigiSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrikazigiSite.Location = new System.Drawing.Point(17, 478);
            this.btnPrikazigiSite.Name = "btnPrikazigiSite";
            this.btnPrikazigiSite.Size = new System.Drawing.Size(230, 156);
            this.btnPrikazigiSite.TabIndex = 11;
            this.btnPrikazigiSite.Text = "Вклучете ги повторно податоци";
            this.btnPrikazigiSite.UseVisualStyleBackColor = true;
            this.btnPrikazigiSite.Click += new System.EventHandler(this.btnPrikazigiSite_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1401, 319);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(263, 64);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Прикажи обележена вредност";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1441, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Датум на склучување на договор";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1477, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Трансакциска сметка";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1477, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Име на компанијата";
            // 
            // datumSorabotkaUpdate
            // 
            this.datumSorabotkaUpdate.CustomFormat = "yyyy-MM-dd";
            this.datumSorabotkaUpdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumSorabotkaUpdate.Location = new System.Drawing.Point(1401, 220);
            this.datumSorabotkaUpdate.Name = "datumSorabotkaUpdate";
            this.datumSorabotkaUpdate.Size = new System.Drawing.Size(257, 20);
            this.datumSorabotkaUpdate.TabIndex = 15;
            // 
            // tbUpdateTransakcija
            // 
            this.tbUpdateTransakcija.Location = new System.Drawing.Point(1401, 170);
            this.tbUpdateTransakcija.Name = "tbUpdateTransakcija";
            this.tbUpdateTransakcija.Size = new System.Drawing.Size(257, 20);
            this.tbUpdateTransakcija.TabIndex = 14;
            // 
            // tbUpdateIme
            // 
            this.tbUpdateIme.Location = new System.Drawing.Point(1401, 121);
            this.tbUpdateIme.Name = "tbUpdateIme";
            this.tbUpdateIme.Size = new System.Drawing.Size(251, 20);
            this.tbUpdateIme.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1334, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(373, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "Промени ја обележаната компанија";
            // 
            // tbUpdateStatus
            // 
            this.tbUpdateStatus.FormattingEnabled = true;
            this.tbUpdateStatus.Items.AddRange(new object[] {
            "aktivna",
            "neaktivna"});
            this.tbUpdateStatus.Location = new System.Drawing.Point(1401, 268);
            this.tbUpdateStatus.Name = "tbUpdateStatus";
            this.tbUpdateStatus.Size = new System.Drawing.Size(263, 21);
            this.tbUpdateStatus.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1485, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Статус на соработка";
            // 
            // tbUpdateId
            // 
            this.tbUpdateId.Location = new System.Drawing.Point(1385, 8);
            this.tbUpdateId.Name = "tbUpdateId";
            this.tbUpdateId.Size = new System.Drawing.Size(175, 20);
            this.tbUpdateId.TabIndex = 22;
            this.tbUpdateId.Visible = false;
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUpdate.Location = new System.Drawing.Point(1401, 406);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(257, 64);
            this.btnSaveUpdate.TabIndex = 23;
            this.btnSaveUpdate.Text = "Зачувај променети вредности";
            this.btnSaveUpdate.UseVisualStyleBackColor = true;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(265, 39);
            this.label11.TabIndex = 25;
            this.label11.Text = "Сите компании";
            // 
            // MenadzerKompanii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1707, 746);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSaveUpdate);
            this.Controls.Add(this.tbUpdateId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbUpdateStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.datumSorabotkaUpdate);
            this.Controls.Add(this.tbUpdateTransakcija);
            this.Controls.Add(this.tbUpdateIme);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnPrikazigiSite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datumSorabotka);
            this.Controls.Add(this.tbTransakcija);
            this.Controls.Add(this.tbImeKompanija);
            this.Controls.Add(this.btnZacuvajNovaKomp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "MenadzerKompanii";
            this.Text = "MenadzerKompanii";
            this.Load += new System.EventHandler(this.MenadzerKompanii_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnZacuvajNovaKomp;
        private System.Windows.Forms.TextBox tbImeKompanija;
        private System.Windows.Forms.TextBox tbTransakcija;
        private System.Windows.Forms.DateTimePicker datumSorabotka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrikazigiSite;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datumSorabotkaUpdate;
        private System.Windows.Forms.TextBox tbUpdateTransakcija;
        private System.Windows.Forms.TextBox tbUpdateIme;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox tbUpdateStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbUpdateId;
        private System.Windows.Forms.Button btnSaveUpdate;
        private System.Windows.Forms.Label label11;
    }
}