using AutoMapper;
using OnlineShop.Contracts;
using OnlineShop.Domain;

namespace OnlineShop.Web.Common
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //FROM
            CreateMap<Product, ProductListItemDTO>()                
                .ForMember(p => p.Categories, opt =>
                opt.MapFrom(com => com.Categories.Count > 1 
                ? string.Join(", ", com.Categories.Select(c => c.Name)) 
                : com.Categories.Single().Name));

            CreateMap<Product, ProductInfoDTO>();

            CreateMap<Product, ProductEditRequest>()
                .ForMember(p => p.CategoryIds, opt =>
                opt.MapFrom(com => com.Categories.Select(c => c.Id.ToString())));

            //TO

            CreateMap<ProductCreateRequest, Product>();
        }
    }
}
