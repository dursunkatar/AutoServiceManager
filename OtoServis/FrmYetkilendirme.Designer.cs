namespace OtoServis
{
    partial class FrmYetkilendirme
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
            groupBox5 = new GroupBox();
            cmbRol = new ComboBox();
            groupBox1 = new GroupBox();
            checkedListBoxEkranlar = new CheckedListBox();
            groupBox2 = new GroupBox();
            checkedListBoxYetkiler = new CheckedListBox();
            groupBox6 = new GroupBox();
            dgvPersonel = new DataGridView();
            groupBox5.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonel).BeginInit();
            SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbRol);
            groupBox5.Location = new Point(12, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(7, 3, 7, 3);
            groupBox5.Size = new Size(417, 51);
            groupBox5.TabIndex = 5;
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
            cmbRol.Size = new Size(403, 23);
            cmbRol.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkedListBoxEkranlar);
            groupBox1.Location = new Point(9, 69);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5);
            groupBox1.Size = new Size(207, 250);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ekranlar";
            // 
            // checkedListBoxEkranlar
            // 
            checkedListBoxEkranlar.Dock = DockStyle.Fill;
            checkedListBoxEkranlar.FormattingEnabled = true;
            checkedListBoxEkranlar.Location = new Point(5, 21);
            checkedListBoxEkranlar.Name = "checkedListBoxEkranlar";
            checkedListBoxEkranlar.Size = new Size(197, 224);
            checkedListBoxEkranlar.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkedListBoxYetkiler);
            groupBox2.Location = new Point(222, 69);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5);
            groupBox2.Size = new Size(207, 250);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Yetkiler";
            // 
            // checkedListBoxYetkiler
            // 
            checkedListBoxYetkiler.Dock = DockStyle.Fill;
            checkedListBoxYetkiler.FormattingEnabled = true;
            checkedListBoxYetkiler.Location = new Point(5, 21);
            checkedListBoxYetkiler.Name = "checkedListBoxYetkiler";
            checkedListBoxYetkiler.Size = new Size(197, 224);
            checkedListBoxYetkiler.TabIndex = 8;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dgvPersonel);
            groupBox6.Location = new Point(9, 325);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(5);
            groupBox6.Size = new Size(420, 236);
            groupBox6.TabIndex = 8;
            groupBox6.TabStop = false;
            groupBox6.Text = "Personeller";
            // 
            // dgvPersonel
            // 
            dgvPersonel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonel.Dock = DockStyle.Fill;
            dgvPersonel.Location = new Point(5, 21);
            dgvPersonel.Name = "dgvPersonel";
            dgvPersonel.Size = new Size(410, 210);
            dgvPersonel.TabIndex = 0;
            // 
            // FrmYetkilendirme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 567);
            Controls.Add(groupBox6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox5);
            Name = "FrmYetkilendirme";
            Text = "FrmYetkilendirme";
            groupBox5.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPersonel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox5;
        private ComboBox cmbRol;
        private GroupBox groupBox1;
        private CheckedListBox checkedListBoxEkranlar;
        private GroupBox groupBox2;
        private CheckedListBox checkedListBoxYetkiler;
        private GroupBox groupBox6;
        private DataGridView dgvPersonel;
    }
}