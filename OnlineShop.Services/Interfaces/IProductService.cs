using OnlineShop.Contracts;

namespace OnlineShop.Services.Interfaces
{
    public interface IProductService
    {
        public IQueryable<ProductListItemDTO> GetAllDTO();

        public Task<ProductInfoDTO> GetProductDTOAsync(int id);

        public Task Delete(int id);

        public Task Create(ProductCreateRequest request);
    }
}
