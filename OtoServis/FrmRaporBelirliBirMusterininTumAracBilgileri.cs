using Microsoft.Reporting.WinForms;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmRaporBelirliBirMusterininTumAracBilgileri : Form
    {
        private readonly ReportViewer reportViewer;
        public FrmRaporBelirliBirMusterininTumAracBilgileri()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(reportViewer, 0, 1);
            RaporuYukle();
        }

        void RaporuYukle()
        {
            using OtoServisDataSet dataSet = new OtoServisDataSet();
            using OtoServisDataSetTableAdapters.SpBelirliBirMusterininTumAracBilgileriTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData(1);

            var parameters = new[] { new ReportParameter("RParamMusteri", "fALAN fİLAN") };

            RaporHelper.Yukle(
                  reportViewer,
                  dataTable,
                  "ReportBelirliBirMusterininTumAracBilgileri",
                  "DataSetBelirliBirMusterininTumAracBilgileri",
                  parameters
                );
        }
    }
}
