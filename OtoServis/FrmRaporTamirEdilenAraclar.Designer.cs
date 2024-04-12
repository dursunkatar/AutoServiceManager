namespace OtoServis
{
    partial class FrmRaporTamirEdilenAraclar
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
            tableLayoutPanel = new TableLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            dateTamirBaslangicTarih = new DateTimePicker();
            tableLayoutPanel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel.Controls.Add(panel1, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 49F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 84.6666641F));
            tableLayoutPanel.Size = new Size(800, 450);
            tableLayoutPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTamirBaslangicTarih);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 43);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 15);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 4;
            label1.Text = "Başlangıç Tamir tarihi :";
            // 
            // dateTamirBaslangicTarih
            // 
            dateTamirBaslangicTarih.Location = new Point(140, 11);
            dateTamirBaslangicTarih.Name = "dateTamirBaslangicTarih";
            dateTamirBaslangicTarih.Size = new Size(197, 23);
            dateTamirBaslangicTarih.TabIndex = 2;
            dateTamirBaslangicTarih.Value = new DateTime(2024, 4, 12, 0, 0, 0, 0);
            dateTamirBaslangicTarih.ValueChanged += dateTamirBaslangicTarih_ValueChanged;
            // 
            // FrmRaporTamirEdilenAraclar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel);
            Name = "FrmRaporTamirEdilenAraclar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tamir Edilen Araçlar Rapor";
            Load += FrmRaporTamirEdilenAraclar_Load;
            tableLayoutPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private Panel panel1;
        private Label label1;
        private DateTimePicker dateTamirBaslangicTarih;
    }
}