using LW3.Infrastructure;
using LW3.Presentation;
using LW3.Presentation.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace LW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddInfrastructure();

            services.AddSingleton<ProductHandler>();
            services.AddSingleton<SalesHandler>();
            services.AddSingleton<EmployeeHandler>();
            services.AddSingleton<SupplierHandler>();
            services.AddSingleton<OrderHandler>();
            services.AddSingleton<ReportHandler>();
            services.AddSingleton<ConsoleMenu>();

            var serviceProvider = services.BuildServiceProvider();

            var menu = serviceProvider.GetRequiredService<ConsoleMenu>();

            menu.Run();
        }
    }
}