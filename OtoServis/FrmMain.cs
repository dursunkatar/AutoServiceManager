namespace OtoServis
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            var s = new FrmMusteriYonetimPaneli();
            s.Show();
        }
    }
}
