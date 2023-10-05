using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.Services.Tests.Common
{
    public class TestFixture : IDisposable
    {
        public IServiceProvider ServiceProvider { get; set; }

        public TestFixture() 
        {
            var builder = new ConfigurationBuilder();
            var configuration = builder.Build();
            var serviceCollection = Configuration.GetServiceCollection(configuration);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            ServiceProvider = serviceProvider;
        }

        public void Dispose()
        { }
    }
}
