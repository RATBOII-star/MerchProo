using ITelectFinal.Data;
using ITelectFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ITelectFinal.Repositories
{
    public class PaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context) => _context = context;

        public PaymentRepository()
            : this(new AppDbContext())
        {
        }

        public async Task CreateAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id) => await _context.Payments.FindAsync(id);

        public async Task<List<Payment>> GetAllAsync() => await _context.Payments.ToListAsync();

        public async Task UpdateAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}

