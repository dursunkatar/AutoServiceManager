using Microsoft.Reporting.WinForms;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmRaporEnCokTamirEdilenAracModelleri : Form
    {
        private readonly ReportViewer reportViewer;
        public FrmRaporEnCokTamirEdilenAracModelleri()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(reportViewer, 0, 1);
        }


        void RaporuYukle()
        {
            using OtoServisDataSet1TableAdapters.SpEnCokTamirEdilenAracModelleriTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData(dateTamirBaslangicTarih.Value);

            var parameters = new[] { new ReportParameter("RParamTarih", dateTamirBaslangicTarih.Value.ToString("yyyy-MM-dd")) };

            RaporHelper.Yukle(
                  reportViewer,
                  dataTable,
                  "ReportEnCokTamirEdilenAracModelleri",
                  "DataSetRaporEnCokTamirEdilenAracModelleri",
                  parameters
                );
        }

        private void FrmRaporEnCokTamirEdilenAracModelleri_Load(object sender, EventArgs e)
        {
            RaporuYukle();
        }

        private void dateTamirBaslangicTarih_ValueChanged(object sender, EventArgs e)
        {
            RaporuYukle();
        }
    }
}
