using AutoMapper;
using OnlineShop.Contracts;
using OnlineShop.Domain;

namespace OnlineShop.Web.Common
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            //FROM
            CreateMap<Category, CategoryListItemDTO>();

            //TO
            CreateMap<CategoryListItemDTO, Category>();
        }
    }
}
