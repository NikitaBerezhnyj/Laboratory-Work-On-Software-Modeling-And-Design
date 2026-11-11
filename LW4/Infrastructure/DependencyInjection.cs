using LW4.Application.Interfaces;
using LW4.Application.Services;
using LW4.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LW4.Infrastructure
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