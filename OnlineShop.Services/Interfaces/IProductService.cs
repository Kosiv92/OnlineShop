using OnlineShop.Contracts;

namespace OnlineShop.Services.Interfaces
{
    public interface IProductService
    {
        public IQueryable<ProductListItemDTO> GetAllDTO();

        public Task<ProductInfoDTO> GetProductInfoDTOAsync(int id);

        public Task<ProductEditRequest> GetProductEditDTOAsync(int id);

        public Task<int> Delete(int id);

        public Task<object> Create(ProductCreateRequest request);

        public Task<object> Edit(ProductEditRequest request);
    }
}
