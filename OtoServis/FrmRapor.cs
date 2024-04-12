namespace OtoServis
{
    public partial class FrmRapor : Form
    {

        public FrmRapor()
        {
            InitializeComponent();
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {

        }

        private void btnTamirEdilenAracRapor_Click(object sender, EventArgs e)
        {
            var form = new FrmRaporTamirEdilenAraclar();
            form.Show();
        }

        private void btnBelirliBirMusterininTumAracBilgileri_Click(object sender, EventArgs e)
        {
            var form = new FrmRaporBelirliBirMusterininTumAracBilgileri();
            form.Show();

        }

        private void btnBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi_Click(object sender, EventArgs e)
        {
            var form = new FrmRaporBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi();
            form.Show();
        }
    }
}
