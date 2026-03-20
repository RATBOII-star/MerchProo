using System.Security.Cryptography;
using System.Text;
using ITelectFinal.Models;
using ITelectFinal.Repositories;
using ITelectFinal.Utils;

namespace ITelectFinal.Services
{
    public class AuthService
    {
        private readonly UserRepository repo = new UserRepository();

        public string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public bool Login(string username, string password)
        {
            var user = repo.GetUserByUsername(username);

            if (user == null)
                return false;

            string hashed = HashPassword(password);

            bool ok = user.PasswordHash == hashed;
            if (ok)
            {
                Session.CurrentUser = user;
            }
            return ok;
        }

        public bool Register(string username, string password, string role = "User")
        {
            var existing = repo.GetUserByUsername(username);
            if (existing != null)
                return false;

            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Role = role
            };

            repo.AddUser(user);
            return true;
        }
    }
}

