namespace OtoServis
{
    partial class FrmPersonelPaneli
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
            txtAd = new TextBox();
            groupBox2 = new GroupBox();
            txtSoyad = new TextBox();
            groupBox3 = new GroupBox();
            txtEmail = new TextBox();
            groupBox4 = new GroupBox();
            txtSifre = new TextBox();
            groupBox5 = new GroupBox();
            cmbRol = new ComboBox();
            btnKaydet = new Button();
            groupBox6 = new GroupBox();
            dgvPersonel = new DataGridView();
            groupBox7 = new GroupBox();
            cmbPersonelAktifPasif = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonel).BeginInit();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtAd);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7, 3, 7, 3);
            groupBox1.Size = new Size(248, 51);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ad";
            // 
            // txtAd
            // 
            txtAd.Dock = DockStyle.Fill;
            txtAd.Location = new Point(7, 19);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(234, 23);
            txtAd.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSoyad);
            groupBox2.Location = new Point(12, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 3, 7, 3);
            groupBox2.Size = new Size(248, 51);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Soyad";
            // 
            // txtSoyad
            // 
            txtSoyad.Dock = DockStyle.Fill;
            txtSoyad.Location = new Point(7, 19);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(234, 23);
            txtSoyad.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtEmail);
            groupBox3.Location = new Point(12, 126);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(7, 3, 7, 3);
            groupBox3.Size = new Size(248, 51);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(7, 19);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(234, 23);
            txtEmail.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtSifre);
            groupBox4.Location = new Point(12, 183);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(7, 3, 7, 3);
            groupBox4.Size = new Size(248, 51);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Şifre";
            // 
            // txtSifre
            // 
            txtSifre.Dock = DockStyle.Fill;
            txtSifre.Location = new Point(7, 19);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(234, 23);
            txtSifre.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbRol);
            groupBox5.Location = new Point(12, 240);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(7, 3, 7, 3);
            groupBox5.Size = new Size(248, 51);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Rol";
            // 
            // cmbRol
            // 
            cmbRol.Dock = DockStyle.Fill;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Seçiniz" });
            cmbRol.Location = new Point(7, 19);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(234, 23);
            cmbRol.TabIndex = 0;
            // 
            // btnKaydet
            // 
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.Location = new Point(12, 349);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(248, 23);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dgvPersonel);
            groupBox6.Location = new Point(266, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(674, 360);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            groupBox6.Text = "Personeller";
            // 
            // dgvPersonel
            // 
            dgvPersonel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonel.Location = new Point(6, 22);
            dgvPersonel.Name = "dgvPersonel";
            dgvPersonel.Size = new Size(662, 332);
            dgvPersonel.TabIndex = 0;
            dgvPersonel.CellClick += dgvPersonel_CellClick;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(cmbPersonelAktifPasif);
            groupBox7.Location = new Point(12, 297);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(7, 3, 7, 3);
            groupBox7.Size = new Size(248, 51);
            groupBox7.TabIndex = 7;
            groupBox7.TabStop = false;
            groupBox7.Text = "Personel Durum Aktif/Pasif";
            // 
            // cmbPersonelAktifPasif
            // 
            cmbPersonelAktifPasif.Dock = DockStyle.Fill;
            cmbPersonelAktifPasif.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPersonelAktifPasif.FormattingEnabled = true;
            cmbPersonelAktifPasif.Location = new Point(7, 19);
            cmbPersonelAktifPasif.Name = "cmbPersonelAktifPasif";
            cmbPersonelAktifPasif.Size = new Size(234, 23);
            cmbPersonelAktifPasif.TabIndex = 0;
            // 
            // FrmPersonelPaneli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 380);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(btnKaydet);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPersonelPaneli";
            Text = "Personel Yönetim Paneli";
            FormClosing += FrmPersonelYonetim_FormClosing;
            Load += FrmPersonelYonetim_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPersonel).EndInit();
            groupBox7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtAd;
        private GroupBox groupBox2;
        private TextBox txtSoyad;
        private GroupBox groupBox3;
        private TextBox txtEmail;
        private GroupBox groupBox4;
        private TextBox txtSifre;
        private GroupBox groupBox5;
        private ComboBox cmbRol;
        private Button btnKaydet;
        private GroupBox groupBox6;
        private DataGridView dgvPersonel;
        private GroupBox groupBox7;
        private ComboBox cmbPersonelAktifPasif;
    }
}