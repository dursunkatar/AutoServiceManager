namespace OtoServis
{
    partial class MusteriYonetimPaneli
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
            groupBox3 = new GroupBox();
            txtEmail = new TextBox();
            groupBox2 = new GroupBox();
            txtSoyad = new TextBox();
            groupBox1 = new GroupBox();
            txtAd = new TextBox();
            groupBox4 = new GroupBox();
            txtTelefon = new TextBox();
            groupBox6 = new GroupBox();
            dgvMusteri = new DataGridView();
            btnKaydet = new Button();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteri).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtEmail);
            groupBox3.Location = new Point(12, 126);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(7, 3, 7, 3);
            groupBox3.Size = new Size(228, 51);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(7, 19);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(214, 23);
            txtEmail.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSoyad);
            groupBox2.Location = new Point(12, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 3, 7, 3);
            groupBox2.Size = new Size(228, 51);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Soyad";
            // 
            // txtSoyad
            // 
            txtSoyad.Dock = DockStyle.Fill;
            txtSoyad.Location = new Point(7, 19);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(214, 23);
            txtSoyad.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtAd);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7, 3, 7, 3);
            groupBox1.Size = new Size(228, 51);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ad";
            // 
            // txtAd
            // 
            txtAd.Dock = DockStyle.Fill;
            txtAd.Location = new Point(7, 19);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(214, 23);
            txtAd.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtTelefon);
            groupBox4.Location = new Point(12, 183);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(7, 3, 7, 3);
            groupBox4.Size = new Size(228, 51);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Telefon";
            // 
            // txtTelefon
            // 
            txtTelefon.Dock = DockStyle.Fill;
            txtTelefon.Location = new Point(7, 19);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(214, 23);
            txtTelefon.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dgvMusteri);
            groupBox6.Location = new Point(246, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(5);
            groupBox6.Size = new Size(925, 455);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Müşteriler";
            // 
            // dgvMusteri
            // 
            dgvMusteri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMusteri.Dock = DockStyle.Fill;
            dgvMusteri.Location = new Point(5, 21);
            dgvMusteri.Name = "dgvMusteri";
            dgvMusteri.Size = new Size(915, 429);
            dgvMusteri.TabIndex = 0;
            dgvMusteri.CellClick += dgvMusteri_CellClick;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(12, 240);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(228, 227);
            btnKaydet.TabIndex = 8;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // MusteriYonetimPaneli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 477);
            Controls.Add(btnKaydet);
            Controls.Add(groupBox6);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MusteriYonetimPaneli";
            Text = "MusteriYonetimPaneli";
            FormClosing += MusteriYonetimPaneli_FormClosing;
            Load += MusteriYonetimPaneli_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMusteri).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private TextBox txtEmail;
        private GroupBox groupBox2;
        private TextBox txtSoyad;
        private GroupBox groupBox1;
        private TextBox txtAd;
        private GroupBox groupBox4;
        private TextBox txtTelefon;
        private GroupBox groupBox6;
        private DataGridView dgvMusteri;
        private Button btnKaydet;
    }
}