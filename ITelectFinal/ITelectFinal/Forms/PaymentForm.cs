using ITelectFinal.Services;
using ITelectFinal.Utils;
using ITelectFinal.Data;
using Microsoft.EntityFrameworkCore;

namespace ITelectFinal
{
    public partial class PaymentForm : Form
    {
        private readonly PaymentService _paymentService;

        public PaymentForm()
        {
            InitializeComponent();
            _paymentService = new PaymentService();
        }

        public async void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtOrderId.Text.Trim(), out var orderId))
                {
                    MessageBox.Show("OrderId must be a number.");
                    return;
                }

                if (!decimal.TryParse(txtAmountPaid.Text.Trim(), out var amountPaid))
                {
                    MessageBox.Show("AmountPaid must be a number.");
                    return;
                }

                var method = txtMethod.Text.Trim();
                await _paymentService.ProcessNewPaymentForCurrentUserAsync(orderId, amountPaid, method);

                lblReceipt.Text =
                    $"Payment recorded.{Environment.NewLine}" +
                    $"OrderId: {orderId}{Environment.NewLine}" +
                    $"AmountPaid: {amountPaid:0.00}{Environment.NewLine}" +
                    $"Method: {method}{Environment.NewLine}" +
                    $"Date: {DateTime.Now}";
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                MessageBox.Show("Something went wrong.");
            }
        }

        private void txtOrderId_TextChanged(object sender, EventArgs e)
        {
            lblCustomerInfo.Text = "";
            lblOrderPaidInfo.Text = "";

            if (!int.TryParse(txtOrderId.Text.Trim(), out var orderId))
                return;

            if (orderId <= 0)
                return;

            using var context = new AppDbContext();
            var order = context.Orders
                .Include(o => o.Customer)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                lblCustomerInfo.Text = "Order not found.";
                return;
            }

            var paid = string.Equals(order.OrderStatus, "Completed", StringComparison.OrdinalIgnoreCase);

            if (order.Customer != null)
            {
                lblCustomerInfo.Text =
                    $"Customer: {order.Customer.CustomerId} - {order.Customer.FirstName} {order.Customer.LastName}";
            }
            else
            {
                lblCustomerInfo.Text = $"CustomerId: {order.CustomerId}";
            }

            lblOrderPaidInfo.Text = paid ? "Status: PAID" : $"Status: {order.OrderStatus} (Not paid yet)";
        }
    }
}

