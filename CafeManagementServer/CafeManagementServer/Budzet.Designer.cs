namespace CafeManagementServer
{
    partial class Budzet
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
            this.lvBudzet = new System.Windows.Forms.ListView();
            this.lvPriliv = new System.Windows.Forms.ListView();
            this.lvOdliv = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.zabeleshkaBudzetUpd = new System.Windows.Forms.RichTextBox();
            this.btnSaveBudzetUpd = new System.Windows.Forms.Button();
            this.tbBudzetUpd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvBudzet
            // 
            this.lvBudzet.HideSelection = false;
            this.lvBudzet.Location = new System.Drawing.Point(12, 123);
            this.lvBudzet.Name = "lvBudzet";
            this.lvBudzet.Size = new System.Drawing.Size(589, 80);
            this.lvBudzet.TabIndex = 0;
            this.lvBudzet.UseCompatibleStateImageBehavior = false;
            this.lvBudzet.SelectedIndexChanged += new System.EventHandler(this.lvBudzet_SelectedIndexChanged);
            // 
            // lvPriliv
            // 
            this.lvPriliv.HideSelection = false;
            this.lvPriliv.Location = new System.Drawing.Point(624, 39);
            this.lvPriliv.Name = "lvPriliv";
            this.lvPriliv.Size = new System.Drawing.Size(939, 295);
            this.lvPriliv.TabIndex = 1;
            this.lvPriliv.UseCompatibleStateImageBehavior = false;
            // 
            // lvOdliv
            // 
            this.lvOdliv.HideSelection = false;
            this.lvOdliv.Location = new System.Drawing.Point(624, 372);
            this.lvOdliv.Name = "lvOdliv";
            this.lvOdliv.Size = new System.Drawing.Size(939, 358);
            this.lvOdliv.TabIndex = 2;
            this.lvOdliv.UseCompatibleStateImageBehavior = false;
            this.lvOdliv.SelectedIndexChanged += new System.EventHandler(this.lvOdliv_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Моментален вкупен буџет";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(991, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Листа со сите приливи";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(992, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Листа со сите одливи";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(429, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Внесете приход и забелешка доколку ја имате";
            // 
            // zabeleshkaBudzetUpd
            // 
            this.zabeleshkaBudzetUpd.Location = new System.Drawing.Point(206, 319);
            this.zabeleshkaBudzetUpd.Name = "zabeleshkaBudzetUpd";
            this.zabeleshkaBudzetUpd.Size = new System.Drawing.Size(241, 76);
            this.zabeleshkaBudzetUpd.TabIndex = 12;
            this.zabeleshkaBudzetUpd.Text = "";
            // 
            // btnSaveBudzetUpd
            // 
            this.btnSaveBudzetUpd.Location = new System.Drawing.Point(206, 411);
            this.btnSaveBudzetUpd.Name = "btnSaveBudzetUpd";
            this.btnSaveBudzetUpd.Size = new System.Drawing.Size(241, 77);
            this.btnSaveBudzetUpd.TabIndex = 11;
            this.btnSaveBudzetUpd.Text = "Внеси приход";
            this.btnSaveBudzetUpd.UseVisualStyleBackColor = true;
            this.btnSaveBudzetUpd.Click += new System.EventHandler(this.btnSaveBudzetUpd_Click);
            // 
            // tbBudzetUpd
            // 
            this.tbBudzetUpd.Location = new System.Drawing.Point(209, 281);
            this.tbBudzetUpd.Name = "tbBudzetUpd";
            this.tbBudzetUpd.Size = new System.Drawing.Size(241, 20);
            this.tbBudzetUpd.TabIndex = 10;
            this.tbBudzetUpd.TextChanged += new System.EventHandler(this.tbBudzetUpd_TextChanged);
            this.tbBudzetUpd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBudzetUpd_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 39);
            this.label4.TabIndex = 14;
            this.label4.Text = "Буџет";
            // 
            // Budzet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1573, 742);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zabeleshkaBudzetUpd);
            this.Controls.Add(this.btnSaveBudzetUpd);
            this.Controls.Add(this.tbBudzetUpd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvOdliv);
            this.Controls.Add(this.lvPriliv);
            this.Controls.Add(this.lvBudzet);
            this.Name = "Budzet";
            this.Text = "Budzet";
            this.Load += new System.EventHandler(this.Budzet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvBudzet;
        private System.Windows.Forms.ListView lvPriliv;
        private System.Windows.Forms.ListView lvOdliv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox zabeleshkaBudzetUpd;
        private System.Windows.Forms.Button btnSaveBudzetUpd;
        private System.Windows.Forms.TextBox tbBudzetUpd;
        private System.Windows.Forms.Label label4;
    }
}