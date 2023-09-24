namespace OnlineShop.Domain
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<T?> GetById(int? id);

        public IQueryable<T> GetAll();

        public Task<int> CreateAsync(T entity);

        public Task DeleteAsync(int? id);

        public Task SaveChangesAsync();
    }

}
