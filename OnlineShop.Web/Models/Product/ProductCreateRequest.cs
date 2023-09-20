using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineShop.Web.Models.Product
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Name must be entered")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price must be entered")]
        [Range(0, Int32.MaxValue, ErrorMessage = "A non-negative value must be specified")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Categories must be selected")]
        [DisplayName("Price")]
        public List<int> CategoriesID { get; set; }
    }
}
