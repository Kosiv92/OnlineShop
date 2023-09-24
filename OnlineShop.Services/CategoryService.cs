using OnlineShop.Services.Interfaces;
using OnlineShop.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using OnlineShop.Domain;

namespace OnlineShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region READ

        public IQueryable<CategoryListItemDTO> GetAllDTO()
        {
            var categories = _unitOfWork.CategoryRepository
                .GetAll()
                .AsNoTracking();

            var categoriesDTO = categories
                .ProjectTo<CategoryListItemDTO>(_mapper.ConfigurationProvider);

            return categoriesDTO;
        }

        public Task<Category?> GetById(int id)
        {
            return _unitOfWork.CategoryRepository
                .GetById(id);
        }

        #endregion
    }
}
