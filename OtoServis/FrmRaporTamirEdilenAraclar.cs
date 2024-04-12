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

            DataTable dataTable = tableAdapter.GetData(dateTimePicker1.Value);

            var parameters = new[] { new ReportParameter("RParamTamirEdilenAraclar", dateTimePicker1.Value.ToString("yyyy-MM-dd")) };

            using var fs = new FileStream("ReportTamirEdilenAraclar.rdlc", FileMode.Open);
            reportViewer.LocalReport.LoadReportDefinition(fs);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetTamirEdilenAraclar", dataTable));
            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.RefreshReport();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            RaporuYukle();
        }
    }
}
