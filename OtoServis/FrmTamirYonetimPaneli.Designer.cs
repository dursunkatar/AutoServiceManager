namespace OtoServis
{
    partial class FrmTamirYonetimPaneli
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
            groupBox1 = new GroupBox();
            cmbArac = new ComboBox();
            groupBox5 = new GroupBox();
            cmbMusteri = new ComboBox();
            groupBox2 = new GroupBox();
            dtpTamirTarihi = new DateTimePicker();
            groupBox3 = new GroupBox();
            txtAciklama = new TextBox();
            groupBox4 = new GroupBox();
            cmbDurum = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbArac);
            groupBox1.Location = new Point(12, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7, 3, 7, 3);
            groupBox1.Size = new Size(339, 51);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Araç";
            // 
            // cmbArac
            // 
            cmbArac.Dock = DockStyle.Fill;
            cmbArac.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbArac.FormattingEnabled = true;
            cmbArac.Items.AddRange(new object[] { "Seçiniz" });
            cmbArac.Location = new Point(7, 19);
            cmbArac.Name = "cmbArac";
            cmbArac.Size = new Size(325, 23);
            cmbArac.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbMusteri);
            groupBox5.Location = new Point(12, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(7, 3, 7, 3);
            groupBox5.Size = new Size(339, 51);
            groupBox5.TabIndex = 11;
            groupBox5.TabStop = false;
            groupBox5.Text = "Müşteri";
            // 
            // cmbMusteri
            // 
            cmbMusteri.Dock = DockStyle.Fill;
            cmbMusteri.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMusteri.FormattingEnabled = true;
            cmbMusteri.Items.AddRange(new object[] { "Seçiniz" });
            cmbMusteri.Location = new Point(7, 19);
            cmbMusteri.Name = "cmbMusteri";
            cmbMusteri.Size = new Size(325, 23);
            cmbMusteri.TabIndex = 0;
            cmbMusteri.SelectedIndexChanged += cmbMusteri_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpTamirTarihi);
            groupBox2.Location = new Point(12, 126);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 3, 7, 3);
            groupBox2.Size = new Size(339, 51);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tamir Tarihi";
            // 
            // dtpTamirTarihi
            // 
            dtpTamirTarihi.Dock = DockStyle.Fill;
            dtpTamirTarihi.Location = new Point(7, 19);
            dtpTamirTarihi.Name = "dtpTamirTarihi";
            dtpTamirTarihi.Size = new Size(325, 23);
            dtpTamirTarihi.TabIndex = 14;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtAciklama);
            groupBox3.Location = new Point(12, 183);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(7, 3, 7, 7);
            groupBox3.Size = new Size(339, 148);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            txtAciklama.Dock = DockStyle.Fill;
            txtAciklama.Location = new Point(7, 19);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.ScrollBars = ScrollBars.Vertical;
            txtAciklama.Size = new Size(325, 122);
            txtAciklama.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cmbDurum);
            groupBox4.Location = new Point(12, 337);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(7, 3, 7, 3);
            groupBox4.Size = new Size(339, 51);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Durum";
            // 
            // cmbDurum
            // 
            cmbDurum.Dock = DockStyle.Fill;
            cmbDurum.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDurum.FormattingEnabled = true;
            cmbDurum.Items.AddRange(new object[] { "Seçiniz" });
            cmbDurum.Location = new Point(7, 19);
            cmbDurum.Name = "cmbDurum";
            cmbDurum.Size = new Size(325, 23);
            cmbDurum.TabIndex = 0;
            // 
            // FrmTamirYonetimPaneli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1187, 591);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox5);
            Name = "FrmTamirYonetimPaneli";
            Text = "FrmTamirYonetimPaneli";
            Load += FrmTamirYonetimPaneli_Load;
            groupBox1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private ComboBox cmbArac;
        private GroupBox groupBox5;
        private ComboBox cmbMusteri;
        private GroupBox groupBox2;
        private DateTimePicker dtpTamirTarihi;
        private GroupBox groupBox3;
        private TextBox txtAciklama;
        private GroupBox groupBox4;
        private ComboBox cmbDurum;
    }
}