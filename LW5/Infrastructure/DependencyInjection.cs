using LW5.Application.Interfaces;
using LW5.Application.Services;
using LW5.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LW5.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ISaleRepository, SaleRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<ISupplierRepository, SupplierRepository>();
            services.AddSingleton<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddSingleton<IReturnRepository, ReturnRepository>();

            services.AddSingleton<ProductService>();
            services.AddSingleton<SalesService>();
            services.AddSingleton<InventoryService>();
            services.AddSingleton<EmployeeService>();
            services.AddSingleton<SupplierService>();
            services.AddSingleton<ReportService>();
            services.AddSingleton<OrderService>();
            services.AddSingleton<ReturnService>();

            return services;
        }
    }
}