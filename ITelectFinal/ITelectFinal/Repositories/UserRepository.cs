using ITelectFinal.Data;
using ITelectFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ITelectFinal.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext context = new AppDbContext();

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User? GetUserByUsername(string username)
        {
            return context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = context.Users.Find(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public User? GetById(int userId)
        {
            return context.Users.FirstOrDefault(u => u.UserId == userId);
        }
    }
}

