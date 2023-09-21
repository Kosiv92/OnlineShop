using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;

namespace OnlineShop.DbContext
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        public ApplicationDbContext _context;
        public DbSet<T> _dbSet;

        public EfRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<int> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int? id)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                throw new NotFoundException(nameof(entity), id);

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<T?> GetByIdAsync(int? id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);


        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();

    }
}
