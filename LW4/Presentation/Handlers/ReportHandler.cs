using LW4.Application.Services;
using static LW4.Presentation.ConsoleInput;

namespace LW4.Presentation.Handlers
{
    public class ReportHandler
    {
        private readonly ReportService _reportService;
        private readonly SalesService _salesService;

        public ReportHandler(
            ReportService reportService,
            SalesService salesService)
        {
            _reportService = reportService;
            _salesService = salesService;
        }

        public void ShowReport()
        {
            Console.Clear();

            try
            {
                var from = ReadDate("Start date (yyyy-MM-dd): ");
                var to = ReadDate("End date (yyyy-MM-dd): ");

                var revenue = _reportService.GetTotalRevenue(from, to);

                Console.WriteLine($"Total revenue: {revenue} UAH");

                Pause();
            }
            catch (Exception exception)
            {
                ShowMessage($"Error: {exception.Message}");
            }
        }

        public void ShowStatistics()
        {
            Console.Clear();

            var sales = _salesService.GetAllSales().ToList();

            Console.WriteLine($"Total number of sales: {sales.Count}");
            Console.WriteLine($"Total revenue: {sales.Sum(sale => sale.TotalAmount)} UAH");

            Pause();
        }
    }
}