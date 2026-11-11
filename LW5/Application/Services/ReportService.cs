using LW5.Application.Interfaces;

namespace LW5.Application.Services
{
    public class ReportService
    {
        private readonly ISaleRepository _saleRepository;

        public ReportService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public decimal GetTotalRevenue(DateTime from, DateTime to)
        {
            if (from > to)
                throw new ArgumentException("Invalid date range.");

            return _saleRepository.GetAll()
                .Where(sale => sale.Date >= from && sale.Date < to.Date.AddDays(1))
                .Sum(sale => sale.TotalAmount);
        }

        public int GetTotalSalesCount(DateTime from, DateTime to)
        {
            if (from > to)
                throw new ArgumentException("Invalid date range.");

            return _saleRepository.GetAll()
                .Count(sale => sale.Date >= from && sale.Date < to.Date.AddDays(1));
        }
    }
}