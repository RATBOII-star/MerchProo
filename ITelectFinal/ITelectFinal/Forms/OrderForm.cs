using ITelectFinal.Data;
using ITelectFinal.Models;
using ITelectFinal.Repositories;
using ITelectFinal.Services;
using ITelectFinal.Utils;
using Microsoft.EntityFrameworkCore;

namespace ITelectFinal
{
    public partial class OrderForm : Form
    {
        private readonly OrderService _orderService;

        public OrderForm(OrderService service)
        {
            InitializeComponent();
            _orderService = service;

            LoadProductMenu();

            // Hardening: ensure the menu dropdown is visible even if designers/runtime conflict.
            cboProductMenu.Visible = true;
            lblProductId.Text = "Product Menu";
        }

        public OrderForm()
            : this(new OrderService(new OrderRepository(new AppDbContext()), new CustomerRepository(new AppDbContext())))
        {
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text.Trim(), out var qty))
            {
                MessageBox.Show("Quantity must be a number.");
                return;
            }

            if (!int.TryParse(txtCustomerId.Text.Trim(), out var customerId))
            {
                MessageBox.Show("CustomerId must be a number.");
                return;
            }

            if (!int.TryParse(txtProductId.Text.Trim(), out var productId))
            {
                MessageBox.Show("ProductId must be a number.");
                return;
            }

            decimal? unitPrice = null;
            if (!string.IsNullOrWhiteSpace(txtUnitPrice.Text) &&
                decimal.TryParse(txtUnitPrice.Text.Trim(), out var parsedPrice))
            {
                unitPrice = parsedPrice;
            }

            try
            {
                var userId = Session.CurrentUser?.UserId ?? 0;
                if (userId <= 0)
                    throw new Exception("No user is logged in.");

                var order = _orderService.CreateOrder(
                    customerId,
                    userId,
                    new List<(int productId, int quantity, decimal? unitPrice)>
                    {
                        (productId, qty, unitPrice)
                    });

                var paid = order.OrderStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase);
                MessageBox.Show(
                    $"Order Created! OrderId = {order.OrderId}\n" +
                    $"CustomerId = {customerId}\n" +
                    $"Total = {order.TotalAmount:0.00}\n" +
                    $"Status = {order.OrderStatus} (Paid = {paid})");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            lblCustomerInfo.Text = "";
            lblCustomerPaidInfo.Text = "";

            if (!int.TryParse(txtCustomerId.Text.Trim(), out var customerId))
                return;

            if (customerId <= 0)
                return;

            using var context = new AppDbContext();

            var customer = context.Customers
                .FirstOrDefault(c => c.CustomerId == customerId);

            if (customer == null)
            {
                lblCustomerInfo.Text = "Customer not found.";
                return;
            }

            var orders = context.Orders
                .Where(o => o.CustomerId == customerId);

            var total = orders.Count();
            var paid = orders.Count(o => o.OrderStatus == "Completed");

            lblCustomerInfo.Text = $"Customer: {customer.FirstName} {customer.LastName} (Id: {customer.CustomerId})";
            lblCustomerPaidInfo.Text = $"Paid: {paid} / {total}";
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            // Auto-fill Unit Price when user enters ProductId.
            if (!int.TryParse(txtProductId.Text.Trim(), out var productId))
                return;

            if (productId <= 0)
                return;

            using var context = new AppDbContext();
            var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
                return;

            // Always keep unit price in sync with the selected product price.
            txtUnitPrice.Text = product.BasePrice.ToString("0.00");
        }

        private void OrderForm_LoadProductMenuItems(IEnumerable<Product> products)
        {
            cboProductMenu.Items.Clear();

            // Keep the menu order fixed to match the professor requirement (1 to 5).
            var orderedNames = new[]
            {
                "T-Shirt",
                "Cap",
                "Mug",
                "Tote Bag",
                "Notebook"
            };

            foreach (var name in orderedNames)
            {
                var product = products.FirstOrDefault(p => p.ProductName == name);
                if (product == null)
                    continue;

                var display = $"{product.ProductName} - ₱{product.BasePrice:0.00}";
                cboProductMenu.Items.Add(new ComboBoxItem(display, product.ProductId));
            }

            // Select first item so the dropdown immediately shows "Product 1..5"
            if (cboProductMenu.Items.Count > 0)
            {
                cboProductMenu.SelectedIndex = 0;
            }
        }

        private void LoadProductMenu()
        {
            try
            {
                using var context = new AppDbContext();
                var products = context.Products.ToList();
                OrderForm_LoadProductMenuItems(products);
            }
            catch
            {
                // If products can't be loaded, allow manual entry via hidden ProductId textbox.
            }
        }

        private void cboProductMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductMenu.SelectedItem is not ComboBoxItem item)
                return;

            txtProductId.Text = item.ProductId.ToString();

            // Ensure unit price updates from selected product.
            using var context = new AppDbContext();
            var product = context.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
            if (product != null)
                txtUnitPrice.Text = product.BasePrice.ToString("0.00");
        }

        private sealed class ComboBoxItem
        {
            public string Display { get; }
            public int ProductId { get; }

            public ComboBoxItem(string display, int productId)
            {
                Display = display;
                ProductId = productId;
            }

            public override string ToString() => Display;
        }
    }
}

