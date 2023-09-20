using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineShop.Web.Models.Product
{
    public class ProductCreateVM
    {

        public IEnumerable<MultiSelectList> CategorySelectListItem { get; set; }
    }
}
