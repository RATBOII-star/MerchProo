using ITelectFinal.Services;

namespace ITelectFinal
{
    public partial class Form1 : Form
    {
        private readonly AuthService auth = new AuthService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password");
                return;
            }

            if (txtUsername.Text.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters");
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters");
                return;
            }

            bool success = auth.Login(username, password);

            if (success)
            {
                Hide();
                using (var home = new HomeForm())
                {
                    home.ShowDialog(this);
                }
                Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using var register = new RegisterForm();
            register.ShowDialog(this);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
