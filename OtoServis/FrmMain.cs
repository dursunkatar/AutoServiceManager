namespace OtoServis
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
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
    }
}
