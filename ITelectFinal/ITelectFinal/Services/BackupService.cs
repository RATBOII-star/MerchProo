using System.Text.Json;
using ITelectFinal.Data;
using ITelectFinal.DTOs;
using ITelectFinal.Utils;
using Microsoft.EntityFrameworkCore;

namespace ITelectFinal.Services
{
    public class BackupService
    {
        private readonly AppDbContext _context;
        private readonly string _backupPath;

        public BackupService()
        {
            _context = new AppDbContext();
            _backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backup.json");
        }

        public async Task BackupAsync()
        {
            try
            {
                var data = new BackupDTO
                {
                    Users = await _context.Users.AsNoTracking().ToListAsync(),
                    Customers = await _context.Customers.AsNoTracking().ToListAsync(),
                    Products = await _context.Products.AsNoTracking().ToListAsync(),
                    Orders = await _context.Orders.AsNoTracking().ToListAsync(),
                    OrderItems = await _context.OrderItems.AsNoTracking().ToListAsync(),
                    Payments = await _context.Payments.AsNoTracking().ToListAsync(),
                    WorkflowTasks = await _context.WorkflowTasks.AsNoTracking().ToListAsync()
                };

                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(_backupPath, json);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw;
            }
        }

        public async Task RestoreAsync()
        {
            try
            {
                if (!File.Exists(_backupPath))
                    throw new Exception("backup.json not found.");

                var json = await File.ReadAllTextAsync(_backupPath);
                var data = JsonSerializer.Deserialize<BackupDTO>(json);

                if (data == null)
                    throw new Exception("Invalid backup file.");

                _context.Users.AddRange(data.Users);
                _context.Customers.AddRange(data.Customers);
                _context.Products.AddRange(data.Products);
                _context.Orders.AddRange(data.Orders);
                _context.OrderItems.AddRange(data.OrderItems);
                _context.Payments.AddRange(data.Payments);
                _context.WorkflowTasks.AddRange(data.WorkflowTasks);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw;
            }
        }
    }
}

