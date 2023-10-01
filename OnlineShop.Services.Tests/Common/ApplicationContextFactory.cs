using Microsoft.EntityFrameworkCore;
using OnlineShop.DbContext;

namespace OnlineShop.Services.Tests.Common
{
    public class ApplicationContextFactory
    {
        public static int ProductId = 1;

        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("test_db")
            .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            return context;            
        }

        public static void Destroy(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
