using ITelectFinal.Data;
using ITelectFinal.DTOs;
using ITelectFinal.Utils;
using Microsoft.EntityFrameworkCore;

namespace ITelectFinal.Services
{
    public class ReportService
    {
        private readonly AppDbContext _context;

        public ReportService()
        {
            _context = new AppDbContext();
        }

        public async Task<SalesReportDTO> GetSalesReportAsync()
        {
            try
            {
                var totalSales = await _context.Payments.SumAsync(p => (decimal?)p.AmountPaid) ?? 0m;
                var totalOrders = await _context.Orders.CountAsync();

                return new SalesReportDTO
                {
                    TotalSales = totalSales,
                    TotalOrders = totalOrders
                };
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                throw;
            }
        }
    }
}

