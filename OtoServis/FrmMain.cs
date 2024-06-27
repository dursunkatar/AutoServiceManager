namespace OtoServis
{
    public partial class FrmMain : Form
    {
        private readonly MenuStrip menuStrip;
        public FrmMain()
        {
            InitializeComponent();
            menuStrip = new MenuStrip();
            CreateDynamicMenu();
        }

        private void CreateDynamicMenu()
        {

            // Ana men� ��esini olu�tur
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Ekranlar");

            // Alt men� ��elerini olu�tur
            ToolStripMenuItem newItem = new ToolStripMenuItem("Yeni", null, NewItem_Click);
            ToolStripMenuItem openItem = new ToolStripMenuItem("A�", null, OpenItem_Click);
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Kaydet", null, SaveItem_Click);

            // Alt men� ��elerini ana men�ye ekle
            fileMenu.DropDownItems.Add(newItem);
            fileMenu.DropDownItems.Add(openItem);
            fileMenu.DropDownItems.Add(saveItem);

            // Ana men�y� MenuStrip'e ekle
            menuStrip.Items.Add(fileMenu);

            // MenuStrip'i forma ekle
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void NewItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni ��e olu�turuldu.");
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("��e a��ld�.");
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("��e kaydedildi.");
        }

        private void pictureBoxMusteriPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmMusteriPaneli();
            form.Show();
        }

        private void pictureBoxTamirPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmTamirPaneli();
            form.Show();
        }

        private void pictureBoxParcaPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmParcaPaneli();
            form.Show();
        }

        private void pictureBoxSatisPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmSatisPaneli();
            form.Show();
        }

        private void pictureBoxPersonelPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmPersonelPaneli();
            form.Show();
        }

        private void pictureBoxAracPaneli_Click(object sender, EventArgs e)
        {
            var form = new FrmAracPaneli();
            form.Show();
        }

        private void pictureBoxRapor_Click(object sender, EventArgs e)
        {
            var form = new FrmRapor();
            form.Show();
        }
    }
}
