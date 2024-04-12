using Microsoft.Reporting.WinForms;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmRaporBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi : Form
    {
        private readonly ReportViewer reportViewer;
        public FrmRaporBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi()
        {
            InitializeComponent();

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer);
        }

        void RaporuYukle()
        {
            using OtoServisDataSet dataSet = new OtoServisDataSet();
            using OtoServisDataSetTableAdapters.SpBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisiTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();

            RaporHelper.Yukle(
                  reportViewer,
                  dataTable,
                  "ReportBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi",
                  "DataSetReportBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi",
                  null
                );
        }

        private void FrmRaporBirYildaTamirEdilenHerBirAracinBilgieriVeTamirSayisi_Load(object sender, EventArgs e)
        {
            RaporuYukle();
        }
    }
}
