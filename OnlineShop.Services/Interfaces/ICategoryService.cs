using OnlineShop.Contracts;
using OnlineShop.Domain;

namespace OnlineShop.Services.Interfaces
{
    public interface ICategoryService
    {
        public IQueryable<CategoryListItemDTO> GetAllDTO();

        public Task<Category> GetById(int id);

        //public Task<ProductInfoDTO> GetProductDTOAsync(int id);

        //public Task Delete(int id);
    }
}
