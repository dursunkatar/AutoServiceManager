namespace OtoServis
{
    partial class FrmSatisPaneli
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
            groupBox7 = new GroupBox();
            cmbSatisPersonel = new ComboBox();
            groupBox5 = new GroupBox();
            cmbMusteri = new ComboBox();
            groupBox2 = new GroupBox();
            cmbParca = new ComboBox();
            groupBox3 = new GroupBox();
            dtpSatisTarihi = new DateTimePicker();
            groupBox4 = new GroupBox();
            txtMiktar = new TextBox();
            groupBox6 = new GroupBox();
            txtTutar = new TextBox();
            groupBox8 = new GroupBox();
            dgvSatis = new DataGridView();
            btnKaydet = new Button();
            btnSil = new Button();
            btnTemizle = new Button();
            groupBox7.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSatis).BeginInit();
            SuspendLayout();
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(cmbSatisPersonel);
            groupBox7.Location = new Point(12, 183);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(7, 3, 7, 3);
            groupBox7.Size = new Size(339, 51);
            groupBox7.TabIndex = 22;
            groupBox7.TabStop = false;
            groupBox7.Text = "Satış Personeli";
            // 
            // cmbSatisPersonel
            // 
            cmbSatisPersonel.Dock = DockStyle.Fill;
            cmbSatisPersonel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSatisPersonel.FormattingEnabled = true;
            cmbSatisPersonel.Items.AddRange(new object[] { "Seçiniz" });
            cmbSatisPersonel.Location = new Point(7, 19);
            cmbSatisPersonel.Name = "cmbSatisPersonel";
            cmbSatisPersonel.Size = new Size(325, 23);
            cmbSatisPersonel.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbMusteri);
            groupBox5.Location = new Point(12, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(7, 3, 7, 3);
            groupBox5.Size = new Size(339, 51);
            groupBox5.TabIndex = 20;
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
            groupBox2.Controls.Add(cmbParca);
            groupBox2.Location = new Point(12, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 3, 7, 3);
            groupBox2.Size = new Size(339, 51);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Parça";
            // 
            // cmbParca
            // 
            cmbParca.Dock = DockStyle.Fill;
            cmbParca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParca.FormattingEnabled = true;
            cmbParca.Items.AddRange(new object[] { "Seçiniz" });
            cmbParca.Location = new Point(7, 19);
            cmbParca.Name = "cmbParca";
            cmbParca.Size = new Size(325, 23);
            cmbParca.TabIndex = 0;
            cmbParca.SelectedIndexChanged += cmbParca_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dtpSatisTarihi);
            groupBox3.Location = new Point(12, 240);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(7, 3, 7, 3);
            groupBox3.Size = new Size(339, 51);
            groupBox3.TabIndex = 24;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tamir Tarihi";
            // 
            // dtpSatisTarihi
            // 
            dtpSatisTarihi.Dock = DockStyle.Fill;
            dtpSatisTarihi.Location = new Point(7, 19);
            dtpSatisTarihi.Name = "dtpSatisTarihi";
            dtpSatisTarihi.Size = new Size(325, 23);
            dtpSatisTarihi.TabIndex = 14;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtMiktar);
            groupBox4.Location = new Point(12, 126);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(7, 3, 7, 3);
            groupBox4.Size = new Size(339, 51);
            groupBox4.TabIndex = 25;
            groupBox4.TabStop = false;
            groupBox4.Text = "Miktar";
            // 
            // txtMiktar
            // 
            txtMiktar.Dock = DockStyle.Fill;
            txtMiktar.Location = new Point(7, 19);
            txtMiktar.Name = "txtMiktar";
            txtMiktar.Size = new Size(325, 23);
            txtMiktar.TabIndex = 0;
            txtMiktar.TextChanged += txtMiktar_TextChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(txtTutar);
            groupBox6.Location = new Point(12, 297);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(7, 3, 7, 3);
            groupBox6.Size = new Size(339, 51);
            groupBox6.TabIndex = 26;
            groupBox6.TabStop = false;
            groupBox6.Text = "Toplam Tutar";
            // 
            // txtTutar
            // 
            txtTutar.Dock = DockStyle.Fill;
            txtTutar.Location = new Point(7, 19);
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(325, 23);
            txtTutar.TabIndex = 0;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(dgvSatis);
            groupBox8.Location = new Point(357, 12);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new Padding(7);
            groupBox8.Size = new Size(902, 422);
            groupBox8.TabIndex = 27;
            groupBox8.TabStop = false;
            groupBox8.Text = "Satışlar";
            // 
            // dgvSatis
            // 
            dgvSatis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSatis.Dock = DockStyle.Fill;
            dgvSatis.Location = new Point(7, 23);
            dgvSatis.Name = "dgvSatis";
            dgvSatis.Size = new Size(888, 392);
            dgvSatis.TabIndex = 0;
            dgvSatis.CellClick += dgvSatis_CellClick;
            // 
            // btnKaydet
            // 
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.Location = new Point(12, 354);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(114, 73);
            btnKaydet.TabIndex = 28;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnSil
            // 
            btnSil.Cursor = Cursors.Hand;
            btnSil.Location = new Point(132, 354);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(105, 73);
            btnSil.TabIndex = 30;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.Location = new Point(243, 354);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(108, 73);
            btnTemizle.TabIndex = 29;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // FrmSatisPaneli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 440);
            Controls.Add(btnSil);
            Controls.Add(btnTemizle);
            Controls.Add(btnKaydet);
            Controls.Add(groupBox8);
            Controls.Add(groupBox6);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox7);
            Controls.Add(groupBox5);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmSatisPaneli";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmSatisPaneli";
            Load += FrmSatisPaneli_Load;
            groupBox7.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSatis).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox7;
        private ComboBox cmbSatisPersonel;
        private GroupBox groupBox5;
        private ComboBox cmbMusteri;
        private GroupBox groupBox2;
        private ComboBox cmbParca;
        private GroupBox groupBox3;
        private DateTimePicker dtpSatisTarihi;
        private GroupBox groupBox4;
        private TextBox txtMiktar;
        private GroupBox groupBox6;
        private TextBox txtTutar;
        private GroupBox groupBox8;
        private DataGridView dgvSatis;
        private Button btnKaydet;
        private Button btnSil;
        private Button btnTemizle;
    }
}