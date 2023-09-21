using AutoMapper;
using OnlineShop.Contracts;
using OnlineShop.Domain;

namespace OnlineShop.Web.Common
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListItemDTO>()                
                .ForMember(p => p.Categories, opt =>
                opt.MapFrom(com => com.Categories.Count > 1 
                ? string.Join(", ", com.Categories.Select(c => c.Name)) 
                : com.Categories.Single().Name));
        }
    }
}
