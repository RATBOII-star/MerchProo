using ITelectFinal.Repositories;
using System.Linq;

namespace ITelectFinal
{
    public partial class AdminPaymentsForm : Form
    {
        private readonly PaymentRepository _repository;

        public AdminPaymentsForm()
        {
            InitializeComponent();
            _repository = new PaymentRepository();
        }

        private async void AdminPaymentsForm_Load(object sender, EventArgs e)
        {
            var payments = await _repository.GetAllAsync();

            var rows = payments.Select(p => new
            {
                p.PaymentId,
                p.OrderId,
                p.AmountPaid,
                p.PaymentMethod,
                p.PaymentDate,
                p.ProcessedByUserId
            }).ToList();

            dgvPayments.AutoGenerateColumns = true;
            dgvPayments.DataSource = rows;
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            var payments = await _repository.GetAllAsync();

            var rows = payments.Select(p => new
            {
                p.PaymentId,
                p.OrderId,
                p.AmountPaid,
                p.PaymentMethod,
                p.PaymentDate,
                p.ProcessedByUserId
            }).ToList();

            dgvPayments.DataSource = rows;
        }
    }
}

