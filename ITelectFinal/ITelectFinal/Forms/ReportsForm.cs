using ITelectFinal.Services;
using ITelectFinal.Utils;

namespace ITelectFinal
{
    public partial class ReportsForm : Form
    {
        private readonly ReportService _reportService;

        public ReportsForm()
        {
            InitializeComponent();
            _reportService = new ReportService();
        }

        private async void btnLoadReport_Click(object sender, EventArgs e)
        {
            try
            {
                var report = await _reportService.GetSalesReportAsync();
                lblTotalSales.Text = report.TotalSales.ToString("0.00");
                lblOrders.Text = report.TotalOrders.ToString();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                MessageBox.Show("Something went wrong.");
            }
        }
    }
}

