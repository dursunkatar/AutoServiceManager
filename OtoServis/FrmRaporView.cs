using Microsoft.Reporting.WinForms;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmRaporView : Form
    {
        private readonly ReportViewer reportViewer;
        public FrmRaporView()
        {
            InitializeComponent();

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer);
        }

        public void RaporuYukle(DataTable dataTable, string RaporRdlcAdi, string RaporDataSetAdi)
        {

            RaporHelper.Yukle(
                  reportViewer,
                  dataTable,
                  RaporRdlcAdi,
                  RaporDataSetAdi,
                  null
                );
        }
    }
}
