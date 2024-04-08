namespace OtoServis
{
    partial class FrmAracPaneli
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
            groupBox6 = new GroupBox();
            dgvArac = new DataGridView();
            groupBox5 = new GroupBox();
            cmbMusteri = new ComboBox();
            groupBox1 = new GroupBox();
            cmbMarka = new ComboBox();
            groupBox2 = new GroupBox();
            cmbModel = new ComboBox();
            groupBox3 = new GroupBox();
            txtYil = new TextBox();
            groupBox4 = new GroupBox();
            txtRenk = new TextBox();
            groupBox7 = new GroupBox();
            txtPlaka = new TextBox();
            btnKaydet = new Button();
            btnTemizle = new Button();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvArac).BeginInit();
            groupBox5.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dgvArac);
            groupBox6.Location = new Point(357, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(5);
            groupBox6.Size = new Size(912, 365);
            groupBox6.TabIndex = 8;
            groupBox6.TabStop = false;
            groupBox6.Text = "Araçlar";
            // 
            // dgvArac
            // 
            dgvArac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArac.Dock = DockStyle.Fill;
            dgvArac.Location = new Point(5, 21);
            dgvArac.Name = "dgvArac";
            dgvArac.Size = new Size(902, 339);
            dgvArac.TabIndex = 0;
            dgvArac.CellClick += dgvArac_CellClick;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbMusteri);
            groupBox5.Location = new Point(12, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(7, 3, 7, 3);
            groupBox5.Size = new Size(339, 51);
            groupBox5.TabIndex = 9;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbMarka);
            groupBox1.Location = new Point(12, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7, 3, 7, 3);
            groupBox1.Size = new Size(339, 51);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Marka";
            // 
            // cmbMarka
            // 
            cmbMarka.Dock = DockStyle.Fill;
            cmbMarka.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarka.FormattingEnabled = true;
            cmbMarka.Items.AddRange(new object[] { "Seçiniz" });
            cmbMarka.Location = new Point(7, 19);
            cmbMarka.Name = "cmbMarka";
            cmbMarka.Size = new Size(325, 23);
            cmbMarka.TabIndex = 0;
            cmbMarka.SelectedIndexChanged += cmbMarka_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbModel);
            groupBox2.Location = new Point(12, 126);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 3, 7, 3);
            groupBox2.Size = new Size(339, 51);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Model";
            // 
            // cmbModel
            // 
            cmbModel.Dock = DockStyle.Fill;
            cmbModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModel.FormattingEnabled = true;
            cmbModel.Items.AddRange(new object[] { "Seçiniz" });
            cmbModel.Location = new Point(7, 19);
            cmbModel.Name = "cmbModel";
            cmbModel.Size = new Size(325, 23);
            cmbModel.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtYil);
            groupBox3.Location = new Point(12, 297);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(7, 3, 7, 3);
            groupBox3.Size = new Size(339, 51);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            groupBox3.Text = "Yıl";
            // 
            // txtYil
            // 
            txtYil.Dock = DockStyle.Fill;
            txtYil.Location = new Point(7, 19);
            txtYil.Name = "txtYil";
            txtYil.Size = new Size(325, 23);
            txtYil.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtRenk);
            groupBox4.Location = new Point(12, 240);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(7, 3, 7, 3);
            groupBox4.Size = new Size(339, 51);
            groupBox4.TabIndex = 13;
            groupBox4.TabStop = false;
            groupBox4.Text = "Renk";
            // 
            // txtRenk
            // 
            txtRenk.Dock = DockStyle.Fill;
            txtRenk.Location = new Point(7, 19);
            txtRenk.Name = "txtRenk";
            txtRenk.Size = new Size(325, 23);
            txtRenk.TabIndex = 0;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(txtPlaka);
            groupBox7.Location = new Point(12, 183);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(7, 3, 7, 3);
            groupBox7.Size = new Size(339, 51);
            groupBox7.TabIndex = 12;
            groupBox7.TabStop = false;
            groupBox7.Text = "Plaka";
            // 
            // txtPlaka
            // 
            txtPlaka.Dock = DockStyle.Fill;
            txtPlaka.Location = new Point(7, 19);
            txtPlaka.Name = "txtPlaka";
            txtPlaka.Size = new Size(325, 23);
            txtPlaka.TabIndex = 0;
            // 
            // btnKaydet
            // 
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.Location = new Point(12, 354);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(176, 23);
            btnKaydet.TabIndex = 15;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Cursor = Cursors.Hand;
            btnTemizle.Location = new Point(194, 354);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(157, 23);
            btnTemizle.TabIndex = 16;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // FrmAracYonetimPaneli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 386);
            Controls.Add(btnTemizle);
            Controls.Add(btnKaydet);
            Controls.Add(groupBox3);
            Controls.Add(groupBox4);
            Controls.Add(groupBox7);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmAracYonetimPaneli";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Araç Yönetim Paneli";
            Load += FrmAracYonetimPaneli_Load;
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvArac).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox6;
        private DataGridView dgvArac;
        private GroupBox groupBox5;
        private ComboBox cmbMusteri;
        private GroupBox groupBox1;
        private ComboBox cmbMarka;
        private GroupBox groupBox2;
        private ComboBox cmbModel;
        private GroupBox groupBox3;
        private TextBox txtYil;
        private GroupBox groupBox4;
        private TextBox txtRenk;
        private GroupBox groupBox7;
        private TextBox txtPlaka;
        private Button btnKaydet;
        private Button btnTemizle;
    }
}