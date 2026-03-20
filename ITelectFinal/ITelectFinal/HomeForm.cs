using System.Linq;
using System.Threading.Tasks;
using ITelectFinal.Data;
using ITelectFinal.Repositories;
using ITelectFinal.Services;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms.DataVisualization.Charting;

namespace ITelectFinal
{
    public partial class HomeForm : Form
    {
        private readonly System.Windows.Forms.Timer _autoRefreshTimer = new System.Windows.Forms.Timer();
        private bool _refreshing;
        private readonly Chart _salesChart = new Chart();

        public HomeForm()
        {
            InitializeComponent();
            InitializeSalesChart();
            ApplyRoleVisibility();
            SetCurrentUserLabel();
            ResizeButtons();
            Resize += (_, _) => ResizeButtons();

            // Auto refresh bottom-left reports and bottom-right workflow board.
            _autoRefreshTimer.Interval = 3000;
            _autoRefreshTimer.Tick += async (_, _) => await RefreshHomePanelsAsync();
            _autoRefreshTimer.Start();

            // ReportsForm and WorkflowTaskForm are replaced by the live panels.
            btnReports.Visible = false;
            btnWorkflow.Visible = false;

            // First refresh quickly.
            _ = RefreshHomePanelsAsync();
        }

        private void InitializeSalesChart()
        {
            _salesChart.Name = "salesChart";
            _salesChart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _salesChart.Palette = ChartColorPalette.SeaGreen;

            var area = new ChartArea("SalesArea");
            area.AxisX.Title = "Date";
            area.AxisY.Title = "Sales";
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            // Prevent X-axis date labels from overlapping.
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 7F);
            _salesChart.ChartAreas.Clear();
            _salesChart.ChartAreas.Add(area);

            var series = new Series("Daily Sales")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String
            };
            _salesChart.Series.Clear();
            _salesChart.Series.Add(series);

            pnlReports.Controls.Add(_salesChart);

            _salesChart.Visible = true;
            _salesChart.BackColor = System.Drawing.Color.White;

            // Prevent the list view from expanding to the bottom (it can cover the chart).
            lvOrdersSummary.Dock = DockStyle.None;
            lvOrdersSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lvOrdersSummary.SendToBack();

            pnlReports.Resize += (_, _) => LayoutReportsArea();
            LayoutReportsArea();
        }

        private void LayoutReportsArea()
        {
            // Bounds layout: keep summary labels, then chart below them, then list below chart.
            int pnlH = pnlReports.ClientSize.Height;
            if (pnlH <= 0)
                return;

            const int leftPadding = 8;
            const int rightPadding = 8;
            const int gap = 6;
            const int bottomPadding = 6;

            int pnlW = Math.Max(220, pnlReports.ClientSize.Width - leftPadding - rightPadding);

            int chartTop = lblUnpaidOrders.Bottom + gap;
            if (chartTop < 50) chartTop = 50; // safety if layout timing returns 0

            // Give chart enough height for readable bars and x labels.
            int chartHeight = Math.Max(130, Math.Min(240, pnlH - chartTop - 70));
            if (chartHeight < 80) chartHeight = 80;

            _salesChart.SetBounds(leftPadding, chartTop, pnlW, chartHeight);
            _salesChart.BringToFront();

            int listTop = chartTop + chartHeight + gap;
            int listHeight = Math.Max(30, pnlH - listTop - bottomPadding);
            lvOrdersSummary.SetBounds(leftPadding, listTop, pnlW, listHeight);
            lvOrdersSummary.SendToBack();
        }

        private void SetCurrentUserLabel()
        {
            var user = Utils.Session.CurrentUser;
            if (user == null)
            {
                lblCurrentUser.Text = "";
                return;
            }

            lblCurrentUser.Text = $"Logged in: {user.Username} ({user.Role})";
        }

        private void ApplyRoleVisibility()
        {
            var role = Utils.Session.CurrentUser?.Role ?? "Admin";

            // Simple role-based visibility
            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                // admin sees everything
                btnReports.Visible = false;
                btnWorkflow.Visible = false;
                return;
            }

            if (role.Equals("Cashier", StringComparison.OrdinalIgnoreCase))
            {
                btnCustomers.Visible = false;
                btnWorkflow.Visible = false;
                btnReports.Visible = false;
            }

            if (role.Equals("Prod. Staff", StringComparison.OrdinalIgnoreCase) ||
                role.Equals("Prod Staff", StringComparison.OrdinalIgnoreCase))
            {
                btnCustomers.Visible = false;
                btnOrders.Visible = false;
                btnPayments.Visible = false;
                btnReports.Visible = false;
                btnWorkflow.Visible = false;
            }
        }

        private void ResizeButtons()
        {
            int margin = 30;
            int width = ClientSize.Width - margin * 2;
            if (width < 220) width = 220;

            btnCustomers.Width = width;
            btnOrders.Width = width;
            btnPayments.Width = width;
            btnReports.Width = width;
            btnWorkflow.Width = width;
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            using var f = new CustomerForm();
            f.ShowDialog(this);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            var role = Utils.Session.CurrentUser?.Role ?? "Admin";
            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                using var f = new AdminOrdersForm();
                f.ShowDialog(this);
            }
            else
            {
                using var f = new OrderForm();
                f.ShowDialog(this);
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            var role = Utils.Session.CurrentUser?.Role ?? "Admin";
            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                using var f = new AdminPaymentsForm();
                f.ShowDialog(this);
            }
            else
            {
                using var f = new PaymentForm();
                f.ShowDialog(this);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            using var f = new ReportsForm();
            f.ShowDialog(this);
        }

        private void btnWorkflow_Click(object sender, EventArgs e)
        {
            using var f = new WorkflowTaskForm();
            f.ShowDialog(this);
        }

        private async Task RefreshHomePanelsAsync()
        {
            if (_refreshing)
                return;

            _refreshing = true;
            try
            {
                // 1) Reports (bottom-left)
                var reportService = new ReportService();
                var report = await reportService.GetSalesReportAsync();

                lblTotalSales.Text = $"TotalSales: {report.TotalSales:0.00}";
                lblTotalOrders.Text = $"TotalOrders: {report.TotalOrders}";

                using var context = new AppDbContext();
                var orders = await context.Orders
                    .Include(o => o.Customer)
                    .OrderByDescending(o => o.OrderDate)
                    .ToListAsync();

                var orderToCustomer = orders.ToDictionary(
                    o => o.OrderId,
                    o => o.Customer != null
                        ? $"{o.Customer.CustomerId}: {o.Customer.FirstName} {o.Customer.LastName}"
                        : $"CustomerId {o.CustomerId}");

                int paidCount = orders.Count(o => string.Equals(o.OrderStatus, "Completed", StringComparison.OrdinalIgnoreCase));
                int unpaidCount = orders.Count - paidCount;

                lblPaidOrders.Text = $"Paid: {paidCount}";
                lblUnpaidOrders.Text = $"Not paid: {unpaidCount}";

                lvOrdersSummary.BeginUpdate();
                lvOrdersSummary.Items.Clear();
                foreach (var o in orders.Take(8))
                {
                    var item = new ListViewItem(o.OrderId.ToString());
                    var customerText = o.Customer != null
                        ? $"{o.Customer.CustomerId}: {o.Customer.FirstName} {o.Customer.LastName}"
                        : o.CustomerId.ToString();
                    item.SubItems.Add(customerText);
                    item.SubItems.Add(o.TotalAmount.ToString("0.00"));
                    item.SubItems.Add(o.OrderStatus);
                    lvOrdersSummary.Items.Add(item);
                }
                lvOrdersSummary.EndUpdate();

                // 1b) Sales trend chart (last 7 days, from Payments)
                var fromDate = DateTime.Today.AddDays(-6);
                var salesByDate = await context.Payments
                    .Where(p => p.PaymentDate.Date >= fromDate)
                    .GroupBy(p => p.PaymentDate.Date)
                    .Select(g => new
                    {
                        Date = g.Key,
                        Total = g.Sum(x => x.AmountPaid)
                    })
                    .ToListAsync();

                var byDate = salesByDate.ToDictionary(x => x.Date, x => x.Total);
                var chartSeries = _salesChart.Series["Daily Sales"];
                chartSeries.Points.Clear();
                for (int i = 0; i < 7; i++)
                {
                    var day = fromDate.AddDays(i);
                    byDate.TryGetValue(day, out var totalForDay);
                    chartSeries.Points.AddXY(day.ToString("MM-dd"), totalForDay);
                }

                _salesChart.Invalidate();
                _salesChart.Update();

                // 2) Workflow board (bottom-right)
                // Progress workflow tasks only when the related order is paid.
                var workflowService = new WorkflowService();
                await workflowService.UpdateWorkflowStatusAsync();

                var workflowRepo = new WorkflowTaskRepository();
                var tasks = await workflowRepo.GetAllAsync();

                lstPendingTasks.Items.Clear();
                lstInProgressTasks.Items.Clear();
                lstCompletedTasks.Items.Clear();

                foreach (var t in tasks)
                {
                    orderToCustomer.TryGetValue(t.OrderId, out var customerInfo);
                    var text = $"Order {t.OrderId} | {customerInfo ?? $"CustomerId ?"} | {t.TaskName}";
                    if (!string.IsNullOrWhiteSpace(t.TaskDescription))
                        text += $" ({t.TaskDescription})";

                    if (string.Equals(t.Status, "Pending", StringComparison.OrdinalIgnoreCase))
                        lstPendingTasks.Items.Add(text);
                    else if (string.Equals(t.Status, "InProgress", StringComparison.OrdinalIgnoreCase))
                        lstInProgressTasks.Items.Add(text);
                    else if (string.Equals(t.Status, "Completed", StringComparison.OrdinalIgnoreCase))
                        lstCompletedTasks.Items.Add(text);
                }
            }
            catch (Exception ex)
            {
                Utils.Logger.Log(ex.ToString());
            }
            finally
            {
                _refreshing = false;
            }
        }
    }
}

