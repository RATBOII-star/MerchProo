using ITelectFinal.Data;
using ITelectFinal.Models;
using ITelectFinal.Repositories;

namespace ITelectFinal
{
    public partial class CustomerForm : Form
    {
        private readonly CustomerRepository _repository;

        public CustomerForm(CustomerRepository repository)
        {
            InitializeComponent();
            _repository = repository;
        }

        public CustomerForm()
            : this(new CustomerRepository(new AppDbContext()))
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            _repository.Add(customer);

            lblCustomerIdResult.Text = $"CustomerId: {customer.CustomerId}";
            MessageBox.Show($"Customer Added! CustomerId = {customer.CustomerId}");
        }
    }
}

