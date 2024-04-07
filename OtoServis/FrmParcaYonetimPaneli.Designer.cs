namespace OtoServis
{
    partial class FrmParcaYonetimPaneli
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
            dgvParca = new DataGridView();
            groupBox3 = new GroupBox();
            txtFiyat = new TextBox();
            groupBox2 = new GroupBox();
            txtStok = new TextBox();
            groupBox1 = new GroupBox();
            txtParcaAdi = new TextBox();
            btnKaydet = new Button();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParca).BeginInit();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dgvParca);
            groupBox6.Location = new Point(266, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(5);
            groupBox6.Size = new Size(537, 236);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Parçalar";
            // 
            // dgvParca
            // 
            dgvParca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParca.Dock = DockStyle.Fill;
            dgvParca.Location = new Point(5, 21);
            dgvParca.Name = "dgvParca";
            dgvParca.Size = new Size(527, 210);
            dgvParca.TabIndex = 0;
            dgvParca.CellClick += dgvParca_CellClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtFiyat);
            groupBox3.Location = new Point(12, 126);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(7, 3, 7, 3);
            groupBox3.Size = new Size(248, 51);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Fiyat";
            // 
            // txtFiyat
            // 
            txtFiyat.Dock = DockStyle.Fill;
            txtFiyat.Location = new Point(7, 19);
            txtFiyat.Name = "txtFiyat";
            txtFiyat.Size = new Size(234, 23);
            txtFiyat.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtStok);
            groupBox2.Location = new Point(12, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 3, 7, 3);
            groupBox2.Size = new Size(248, 51);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Stok";
            // 
            // txtStok
            // 
            txtStok.Dock = DockStyle.Fill;
            txtStok.Location = new Point(7, 19);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(234, 23);
            txtStok.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtParcaAdi);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7, 3, 7, 3);
            groupBox1.Size = new Size(248, 51);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Parça Adı";
            // 
            // txtParcaAdi
            // 
            txtParcaAdi.Dock = DockStyle.Fill;
            txtParcaAdi.Location = new Point(7, 19);
            txtParcaAdi.Name = "txtParcaAdi";
            txtParcaAdi.Size = new Size(234, 23);
            txtParcaAdi.TabIndex = 0;
            // 
            // btnKaydet
            // 
            btnKaydet.Cursor = Cursors.Hand;
            btnKaydet.Location = new Point(12, 183);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(248, 60);
            btnKaydet.TabIndex = 11;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // FrmParcaYonetimPaneli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 703);
            Controls.Add(btnKaydet);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox6);
            Name = "FrmParcaYonetimPaneli";
            Text = "FrmParcaYonetimPaneli";
            Load += FrmParcaYonetimPaneli_Load;
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvParca).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox6;
        private DataGridView dgvParca;
        private GroupBox groupBox3;
        private TextBox txtFiyat;
        private GroupBox groupBox2;
        private TextBox txtStok;
        private GroupBox groupBox1;
        private TextBox txtParcaAdi;
        private Button btnKaydet;
    }
}