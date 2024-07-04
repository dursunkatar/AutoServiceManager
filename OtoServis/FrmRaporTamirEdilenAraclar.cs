using Microsoft.Reporting.WinForms;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmRaporTamirEdilenAraclar : Form
    {
        private readonly ReportViewer reportViewer;
        public FrmRaporTamirEdilenAraclar()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(reportViewer, 0, 1);
        }

        private void FrmRaporTamirEdilenAraclar_Load(object sender, EventArgs e)
        {
            RaporuYukle();
        }

        void RaporuYukle()
        {
            using OtoServisDataSet1TableAdapters.SpTamirEdilenAraclarTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData(dateTamirBaslangicTarih.Value);

            var parameters = new[] { new ReportParameter("RParamTamirEdilenAraclar", dateTamirBaslangicTarih.Value.ToString("yyyy-MM-dd")) };

            RaporHelper.Yukle(
                  reportViewer,
                  dataTable,
                  "ReportTamirEdilenAraclar",
                  "DataSetTamirEdilenAraclar",
                  parameters
                );
        }


        private void dateTamirBaslangicTarih_ValueChanged(object sender, EventArgs e)
        {
            RaporuYukle();
        }
    }
}
