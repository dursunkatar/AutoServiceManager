namespace OtoServis
{
    partial class FrmPersonelGiris
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
            groupBox4 = new GroupBox();
            txtSifre = new TextBox();
            groupBox1 = new GroupBox();
            txtEmail = new TextBox();
            btnGiris = new Button();
            groupBox4.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtSifre);
            groupBox4.Location = new Point(12, 69);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(7, 3, 7, 3);
            groupBox4.Size = new Size(248, 51);
            groupBox4.TabIndex = 5;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(7, 3, 7, 3);
            groupBox1.Size = new Size(248, 51);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(7, 19);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(234, 23);
            txtEmail.TabIndex = 0;
            // 
            // btnGiris
            // 
            btnGiris.Cursor = Cursors.Hand;
            btnGiris.Location = new Point(12, 126);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(248, 28);
            btnGiris.TabIndex = 6;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // FrmPersonelGiris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(274, 167);
            Controls.Add(btnGiris);
            Controls.Add(groupBox4);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmPersonelGiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personel Giriş";
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox4;
        private TextBox txtSifre;
        private GroupBox groupBox1;
        private TextBox txtEmail;
        private Button btnGiris;
    }
}