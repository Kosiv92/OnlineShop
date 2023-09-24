using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Contracts;
using OnlineShop.Domain;
using OnlineShop.Services.Interfaces;

namespace OnlineShop.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region CREATE

        public async Task Create(ProductCreateRequest request)
        {
            var newProduct = _mapper.Map<Product>(request);

            foreach(var categoryId in request.CategoryIds)
            {
                newProduct.Categories.Add(
                    await _unitOfWork.CategoryRepository.GetById(Int32.Parse(categoryId))
                    //new Category { Id = Int32.Parse(categoryId) }                    
                    );
            }

            await _unitOfWork.ProductRepository.CreateAsync(newProduct);
        }

        #endregion

        #region READ

        public IQueryable<ProductListItemDTO> GetAllDTO()
        {
            var products = _unitOfWork.ProductRepository
                .GetAll()
                .Include(p => p.Categories);

            var productsDTO = products
                    .ProjectTo<ProductListItemDTO>(_mapper.ConfigurationProvider);

            return productsDTO;
        }

        public async Task<ProductInfoDTO> GetProductDTOAsync(int id)
            => _mapper.Map<ProductInfoDTO>(await _unitOfWork.ProductRepository.GetById(id));
        

        #endregion

        #region DELETE

        public async Task Delete(int id)
        {
            await _unitOfWork.ProductRepository
                .DeleteAsync(id);                        
        }       

        #endregion

    }
}
