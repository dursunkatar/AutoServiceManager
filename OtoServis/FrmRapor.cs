using System.Data;

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
            using OtoServisDataSetTableAdapters.SpBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisiTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();
            var form = new FrmRaporView();
            form.Show();
            form.RaporuYukle(dataTable, "ReportBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi", "DataSetReportBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi");
        }

        private void btnBirYildaYapilanToplamSatisMiktari_Click(object sender, EventArgs e)
        {
            using OtoServisDataSetTableAdapters.SpBirYildaYapilanToplamSatisMiktariTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();
            var form = new FrmRaporView();
            form.Show();
            form.RaporuYukle(dataTable, "ReportBirYildaYapilanToplamSatisMiktari", "DataSetReportBirYildaYapilanToplamSatisMiktari");

        }

        private void btnEnCokGelirGetirenIlkBesParca_Click(object sender, EventArgs e)
        {
            using OtoServisDataSetTableAdapters.SpEnCokGelirGetirenIlkBesParcaTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();
            var form = new FrmRaporView();
            form.Show();
            form.RaporuYukle(dataTable, "ReportEnCokGelirGetirenIlkBesParca", "DataSetRaporEnCokGelirGetirenIlkBesParca");
        }

        private void btnEnCokKullanilanParcalarVeAraclardakiKullanimSikligi_Click(object sender, EventArgs e)
        {
            using OtoServisDataSetTableAdapters.SpEnCokKullanilanParcalarVeAraclardakiKullanimSikligiTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();
            var form = new FrmRaporView();
            form.Show();
            form.RaporuYukle(dataTable, "ReportEnCokKullanilanParcalarVeAraclardakiKullanimSikligi", "DataSetRaporEnCokKullanilanParcalarVeAraclardakiKullanimSikligi");
        }

        private void btnHerBirMarkayaAitAracSayisiVeOrtalamaYaslari_Click(object sender, EventArgs e)
        {
            using OtoServisDataSetTableAdapters.SpHerBirMarkayaAitAracSayisiVeOrtalamaYaslariTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();
            var form = new FrmRaporView();
            form.Show();
            form.RaporuYukle(dataTable, "ReportHerBirMarkayaAitAracSayisiVeOrtalamaYaslari", "DataSetRaporHerBirMarkayaAitAracSayisiVeOrtalamaYaslari");
        }

        private void btnHerBirParcaninOrtalamaSatisFiyati_Click(object sender, EventArgs e)
        {
            using OtoServisDataSetTableAdapters.SpHerBirParcaninOrtalamaSatisFiyatiTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();
            var form = new FrmRaporView();
            form.Show();
            form.RaporuYukle(dataTable, "ReportHerBirParcaninOrtalamaSatisFiyati", "DataSetRaporHerBirParcaninOrtalamaSatisFiyati");
        }

        private void btnHerBirPersonelIcinYapilanToplamSatisTutariVeSatisAdedi_Click(object sender, EventArgs e)
        {
            using OtoServisDataSetTableAdapters.SpHerBirPersonelIcinYapilanToplamSatisTutariVeSatisAdediTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();
            var form = new FrmRaporView();
            form.Show();
            form.RaporuYukle(dataTable, "ReportHerBirPersonelIcinYapilanToplamSatisTutariVeSatisAdedi", "DataSetRaporHerBirPersonelIcinYapilanToplamSatisTutariVeSatisAdedi");
        }

        private void btnHerBirRoldekiPersonelSayisi_Click(object sender, EventArgs e)
        {
            using OtoServisDataSetTableAdapters.SpHerBirRoldekiPersonelSayisiTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();
            var form = new FrmRaporView();
            form.Show();
            form.RaporuYukle(dataTable, "ReportHerBirRoldekiPersonelSayisi", "DataSetRaporHerBirRoldekiPersonelSayisi");
        }
    }
}
