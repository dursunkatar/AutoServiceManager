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
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
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
            // FrmTamirYonetimPaneli
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1187, 591);
            Controls.Add(groupBox1);
            Controls.Add(groupBox5);
            Name = "FrmTamirYonetimPaneli";
            Text = "FrmTamirYonetimPaneli";
            Load += FrmTamirYonetimPaneli_Load;
            groupBox1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private ComboBox cmbArac;
        private GroupBox groupBox5;
        private ComboBox cmbMusteri;
    }
}