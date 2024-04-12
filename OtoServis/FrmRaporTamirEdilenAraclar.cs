using Microsoft.Reporting.WinForms;
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
            using OtoServisDataSet dataSet = new OtoServisDataSet();
            using OtoServisDataSetTableAdapters.SpTamirEdilenAraclarTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData(dateTamirBaslangicTarih.Value);

            var parameters = new[] { new ReportParameter("RParamTamirEdilenAraclar", dateTamirBaslangicTarih.Value.ToString("yyyy-MM-dd")) };

            using var fs = new FileStream("Rapor/ReportTamirEdilenAraclar.rdlc", FileMode.Open);
            reportViewer.LocalReport.LoadReportDefinition(fs);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetTamirEdilenAraclar", dataTable));
            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.RefreshReport();
        }



        private void dateTamirBaslangicTarih_ValueChanged(object sender, EventArgs e)
        {
            RaporuYukle();
        }
    }
}
