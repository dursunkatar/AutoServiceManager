using Microsoft.Reporting.WinForms;
using System.Data;

namespace OtoServis.Helper
{
    public class RaporHelper
    {
        public static void Yukle(ReportViewer reportViewer, DataTable dataTable, string RaporRdlcAdi, string RaporDataSetAdi, ReportParameter[] parameters)
        {
            using var fs = new FileStream($"Rapor/{RaporRdlcAdi}.rdlc", FileMode.Open);
            reportViewer.LocalReport.LoadReportDefinition(fs);
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource(RaporDataSetAdi, dataTable));
            if (parameters != null)
                reportViewer.LocalReport.SetParameters(parameters);

            reportViewer.RefreshReport();
        }
    }
}
