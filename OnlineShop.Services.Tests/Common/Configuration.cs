using Castle.Core.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Contracts;
using OnlineShop.DbContext;
using OnlineShop.Domain;
using OnlineShop.Web.Common;

namespace OnlineShop.Services.Tests.Common
{
    public static class Configuration
    {
        public static IServiceCollection GetServiceCollection(IConfigurationRoot configuration,
            IServiceCollection serviceCollection = null)
        {
            if (serviceCollection == null)
            {
                serviceCollection = new ServiceCollection();
            }

            serviceCollection
                .AddSingleton(configuration)
                .AddSingleton((IConfigurationRoot)configuration)
                .AddAutoMapper(typeof(ProductProfile).Assembly)
                .ConfigureInMemoryContext<ApplicationDbContext>()
                .AddTransient<IRepository<Product>, ProductRepository>()
                .AddTransient<IRepository<Category>, EfRepository<Category>>()
                .AddTransient<IUnitOfWork, UnitOfWorkRepo>();

            return serviceCollection;
        }

        private static IServiceCollection ConfigureInMemoryContext<T>(this IServiceCollection services)
            where T : IdentityDbContext
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            services.AddDbContext<T>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDb", builder => { });
                options.UseInternalServiceProvider(serviceProvider);
            });
            services.AddTransient<IdentityDbContext, T>();

            return services;
        }


    }
}
