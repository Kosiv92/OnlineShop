using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Contracts;
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

        public IQueryable<ProductListItemDTO> GetAllDTO()
        {
            var products = _unitOfWork.ProductRepository
                .GetAll()
                .Include(p => p.Categories);

            var productsDTO = products
                    .ProjectTo<ProductListItemDTO>(_mapper.ConfigurationProvider);

            return productsDTO;
        }
    }
}
