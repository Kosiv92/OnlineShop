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
                    await _unitOfWork.CategoryRepository
                    .GetById(int.Parse(categoryId)));
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

        public async Task<ProductInfoDTO> GetProductInfoDTOAsync(int id)
            => _mapper.Map<ProductInfoDTO>(await _unitOfWork.ProductRepository.GetById(id));

        public async Task<ProductEditRequest?> GetProductEditDTOAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetById(id);
            if (product == null) return null;

            var editDTO = _mapper.Map<ProductEditRequest?>(product);

            return editDTO;
        }

        #endregion

        #region UPDATE

        public async Task Edit(ProductEditRequest request)
        {
            var editProduct = await _unitOfWork.ProductRepository.GetById(request.Id);

            editProduct.Name = request.Name;
            editProduct.Description = request.Description;
            editProduct.Price = request.Price;

            List<Category> categories = new List<Category>();

            foreach (var categoryId in request.CategoryIds)
            {
                categories.Add(
                    await _unitOfWork.CategoryRepository
                    .GetById(int.Parse(categoryId)));
            }

            editProduct.Categories = categories;

            await _unitOfWork.ProductRepository.SaveChangesAsync();
        }

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
