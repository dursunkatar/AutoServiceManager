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
            groupBox6 = new GroupBox();
            dgvTamir = new DataGridView();
            btnKaydet = new Button();
            groupBox7 = new GroupBox();
            cmbUsta = new ComboBox();
            btnTemizle = new Button();
            btnSil = new Button();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTamir).BeginInit();
            groupBox7.SuspendLayout();
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
            groupBox2.Location = new Point(10, 183);
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
            groupBox3.Location = new Point(10, 240);
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
            groupBox4.Location = new Point(10, 394);
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
            // groupBox6
            // 
            groupBox6.Controls.Add(dgvTamir);
            groupBox6.Location = new Point(357, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(5);
            groupBox6.Size = new Size(1101, 462);
            groupBox6.TabIndex = 17;
            groupBox6.TabStop = false;
            groupBox6.Text = "Tamir Kayıtları";
            // 
            // dgvTamir
            // 
            dgvTamir.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTamir.Dock = DockStyle.Fill;
            dgvTamir.Location = new Point(5, 21);
            dgvTamir.Name = "dgvTamir";
            dgvTamir.Size = new Size(1091, 436);
            dgvTamir.TabIndex = 0;
            dgvTamir.CellClick += dgvTamir_CellClick;
            // 
            // btnKaydet
            // 
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.Location = new Point(10, 451);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(114, 23);
            btnKaydet.TabIndex = 18;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(cmbUsta);
            groupBox7.Location = new Point(10, 126);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(7, 3, 7, 3);
            groupBox7.Size = new Size(339, 51);
            groupBox7.TabIndex = 19;
            groupBox7.TabStop = false;
            groupBox7.Text = "Usta";
            // 
            // cmbUsta
            // 
            cmbUsta.Dock = DockStyle.Fill;
            cmbUsta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsta.FormattingEnabled = true;
            cmbUsta.Items.AddRange(new object[] { "Seçiniz" });
            cmbUsta.Location = new Point(7, 19);
            cmbUsta.Name = "cmbUsta";
            cmbUsta.Size = new Size(325, 23);
            cmbUsta.TabIndex = 0;
            // 
            // btnTemizle
            // 
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.Location = new Point(241, 451);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(108, 23);
            btnTemizle.TabIndex = 20;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.Cursor = Cursors.Hand;
            btnSil.Location = new Point(130, 451);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(105, 23);
            btnSil.TabIndex = 21;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // FrmTamirYonetimPaneli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1464, 479);
            Controls.Add(btnSil);
            Controls.Add(btnTemizle);
            Controls.Add(groupBox7);
            Controls.Add(btnKaydet);
            Controls.Add(groupBox6);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox5);
            Name = "FrmTamirYonetimPaneli";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTamirYonetimPaneli";
            Load += FrmTamirYonetimPaneli_Load;
            groupBox1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTamir).EndInit();
            groupBox7.ResumeLayout(false);
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
        private GroupBox groupBox6;
        private DataGridView dgvTamir;
        private Button btnKaydet;
        private GroupBox groupBox7;
        private ComboBox cmbUsta;
        private Button btnTemizle;
        private Button btnSil;
    }
}