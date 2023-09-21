using OnlineShop.Domain;

namespace OnlineShop.Services
{
    public interface IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }

        public IRepository<Product> CategoryRepository { get; }

        public Task SaveAsync();
    }
}
