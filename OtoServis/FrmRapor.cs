﻿using Microsoft.Reporting.WinForms;
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
            using OtoServisDataSetTableAdapters.SpTamirEdilenAraclarTableAdapter tableAdapter = new();

            DataTable dataTable = tableAdapter.GetData(DateTime.Now);

            var parameters = new[] { new ReportParameter("RParamTamirEdilenAraclar", DateTime.Now.ToString("yyyy-MM-dd")) };

            using var fs = new FileStream("ReportTamirEdilenAraclar.rdlc", FileMode.Open);
            reportViewer.LocalReport.LoadReportDefinition(fs);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetTamirEdilenAraclar", dataTable));
            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.RefreshReport();
        }
    }
}
