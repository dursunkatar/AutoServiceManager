using Microsoft.Reporting.WinForms;
using OtoServis.DataAccess;
using OtoServis.DataAccess.Context;
using OtoServis.Dto;
using OtoServis.Helper;
using System.Data;

namespace OtoServis
{
    public partial class FrmRaporBelirliBirMusterininTumAracBilgileri : Form
    {
        private readonly AppDbContext dbContext;
        private readonly ReportViewer reportViewer;
        public FrmRaporBelirliBirMusterininTumAracBilgileri()
        {
            InitializeComponent();
            dbContext = DbContextBuilder.Build();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            tableLayoutPanel.Controls.Add(reportViewer, 0, 1);
            RaporuYukle();
            MusterileriYukle();
        }

        private void cmbMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextValueDto<int> selectedData = cmbMusteri.SelectedItem as TextValueDto<int>;

            if (selectedData != null)
            {
                RaporuYukle(selectedData.Value);
            }
        }

        void MusterileriYukle()
        {
            var data = dbContext.Musteriler.Where(x => !x.Silindimi).Select(x => new TextValueDto<int>
            {
                Text = $"{x.Ad} {x.Soyad} - ({x.Telefon})",
                Value = x.MusteriID

            }).ToList();

            data.Insert(0, new TextValueDto<int>
            {
                Text = "Seçiniz",
                Value = -1
            });

            ComboBoxHelper.LoadData(cmbMusteri, data, "Text", "Value");
        }

        void RaporuYukle(int? musteriId = null)
        {
            using OtoServisDataSet dataSet = new OtoServisDataSet();
            using OtoServisDataSetTableAdapters.SpBelirliBirMusterininTumAracBilgileriTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData(musteriId);

            ReportParameter[] parameters = new[] { new ReportParameter("RParamMusteri", cmbMusteri.SelectedIndex != 0 ? cmbMusteri.Text : "Tüm Müşteriler") };

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
