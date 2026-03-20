using ITelectFinal.Services;

namespace ITelectFinal
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService auth = new AuthService();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirmPassword.Text.Trim();

            if (username == "" || password == "" || confirm == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            if (username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters");
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }

            bool created = auth.Register(username, password);

            if (!created)
            {
                MessageBox.Show("Username already exists");
                return;
            }

            MessageBox.Show("Account created! You can now log in.");
            Close();
        }
    }
}

