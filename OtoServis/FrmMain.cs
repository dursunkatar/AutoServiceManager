namespace OtoServis
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            var s = new FrmPersonelYonetimPaneli();
            s.Show();
        }
    }
}
