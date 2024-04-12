using Microsoft.Reporting.WinForms;
using System.Data;

namespace OtoServis
{
    public partial class FrmRapor : Form
    {
        private readonly ReportViewer reportViewer;
        public FrmRapor()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            Controls.Add(reportViewer);
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            using OtoServisDataSet dataSet = new OtoServisDataSet();
            OtoServisDataSetTableAdapters.spDeneme2TableAdapter tableAdapter =
                new OtoServisDataSetTableAdapters.spDeneme2TableAdapter();

            DataTable dataTable = tableAdapter.GetData(DateTime.Now);


            using var fs = new FileStream("Report1.rdlc", FileMode.Open);
            reportViewer.LocalReport.LoadReportDefinition(fs);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataTable));

            reportViewer.RefreshReport();

        }
    }
}
