using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain;

namespace OnlineShop.DbContext
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly("OnlineShop.Web")))
                .AddTransient<IRepository<Product>, EfRepository<Product>>()
                .AddTransient<IRepository<Category>, EfRepository<Category>>();

            return services;
        }
    }
}
