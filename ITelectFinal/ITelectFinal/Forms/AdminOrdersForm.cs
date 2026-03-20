using ITelectFinal.Repositories;
using System.Linq;

namespace ITelectFinal
{
    public partial class AdminOrdersForm : Form
    {
        private readonly OrderRepository _orderRepository;

        public AdminOrdersForm()
        {
            InitializeComponent();
            _orderRepository = new OrderRepository();
        }

        private void AdminOrdersForm_Load(object sender, EventArgs e)
        {
            var orders = _orderRepository.GetAll();

            var rows = orders.Select(o => new
            {
                o.OrderId,
                o.CustomerId,
                CustomerName = o.Customer != null ? $"{o.Customer.FirstName} {o.Customer.LastName}" : "",
                o.TotalAmount,
                o.OrderStatus,
                o.OrderDate,
                o.CreatedByUserId
            }).ToList();

            dgvOrders.AutoGenerateColumns = true;
            dgvOrders.DataSource = rows;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminOrdersForm_Load(sender, e);
        }
    }
}

