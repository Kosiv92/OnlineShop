using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Contracts;

namespace OnlineShop.Web.Models.Product
{
    public class ProductEditVM
    {
        public ProductEditRequest Request { get; set; }

        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}
