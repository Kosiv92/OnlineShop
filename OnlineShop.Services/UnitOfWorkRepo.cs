using OnlineShop.DbContext;
using OnlineShop.Domain;

namespace OnlineShop.Services
{
    public class UnitOfWorkRepo : IUnitOfWork
    {
        private ApplicationDbContext _context;

        private IRepository<Product> _productRepository;

        private IRepository<Category> _categoryRepository;

        public UnitOfWorkRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Product> ProductRepository 
        {
            get 
            {
                if(_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new EfRepository<Category>(_context);
                }
                return _categoryRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
