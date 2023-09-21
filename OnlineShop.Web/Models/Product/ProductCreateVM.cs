using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop.Web.Models.Product
{
    public class ProductCreateVM
    {
        public ProductCreateRequest Request { get; set; }

        public IEnumerable<MultiSelectList> CategorySelectListItem { get; set; }
    }
}
