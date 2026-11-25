using LW8.Infrastructure;
using LW8.Presentation;
using LW8.Presentation.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace LW8
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