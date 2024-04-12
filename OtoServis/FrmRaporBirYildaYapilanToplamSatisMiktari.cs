using Microsoft.Reporting.WinForms;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmRaporBirYildaYapilanToplamSatisMiktari : Form
    {
        private readonly ReportViewer reportViewer;
        public FrmRaporBirYildaYapilanToplamSatisMiktari()
        {
            InitializeComponent();

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer);
        }

        void RaporuYukle()
        {
            using OtoServisDataSet dataSet = new OtoServisDataSet();
            using OtoServisDataSetTableAdapters.SpBirYildaYapilanToplamSatisMiktariTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData();

            RaporHelper.Yukle(
                  reportViewer,
                  dataTable,
                  "ReportBirYildaYapilanToplamSatisMiktari",
                  "DataSetReportBirYildaYapilanToplamSatisMiktari",
                  null
                );
        }

        private void FrmRaporBirYildaYapilanToplamSatisMiktari_Load(object sender, EventArgs e)
        {
            RaporuYukle();
        }
    }
}
