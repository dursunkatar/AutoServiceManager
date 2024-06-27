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

            // Ana menü öðesini oluþtur
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Ekranlar");

            // Alt menü öðelerini oluþtur
            ToolStripMenuItem newItem = new ToolStripMenuItem("Yeni", null, NewItem_Click);
            ToolStripMenuItem openItem = new ToolStripMenuItem("Aç", null, OpenItem_Click);
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Kaydet", null, SaveItem_Click);

            // Alt menü öðelerini ana menüye ekle
            fileMenu.DropDownItems.Add(newItem);
            fileMenu.DropDownItems.Add(openItem);
            fileMenu.DropDownItems.Add(saveItem);

            // Ana menüyü MenuStrip'e ekle
            menuStrip.Items.Add(fileMenu);

            // MenuStrip'i forma ekle
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;
        }

        private void NewItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeni öðe oluþturuldu.");
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Öðe açýldý.");
        }

        private void SaveItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Öðe kaydedildi.");
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
