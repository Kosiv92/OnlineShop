
using OnlineShop.Contracts;

namespace OnlineShop.Services.Interfaces
{
    public interface IProductService
    {
        public IQueryable<ProductListItemDTO> GetAllDTO();
    }
}
