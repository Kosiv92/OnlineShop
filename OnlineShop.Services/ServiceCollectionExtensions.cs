using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Services.Interfaces;

namespace OnlineShop.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesCollection(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWorkRepo>();

            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<ICategoryService, CategoryService>();

            return services;
        }
    }
}
