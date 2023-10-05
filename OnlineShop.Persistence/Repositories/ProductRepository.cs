using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;

namespace OnlineShop.DbContext
{
    public sealed class ProductRepository : IRepository<Product>
    {
        public ApplicationDbContext _context;        

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        public async Task<int> CreateAsync(Product entity)
        {   
            await _context.Products
                .AddAsync(entity);

            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int? id)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new NotFoundException(nameof(entity), id);

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll() => _context.Products
            .AsNoTracking()
            .Include(p => p.Categories)
            .AsQueryable();
        
        public Task<Product?> GetById(int? id) 
            => _context.Products
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
