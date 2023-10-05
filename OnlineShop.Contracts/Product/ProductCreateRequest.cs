using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineShop.Contracts
{
    public record ProductCreateRequest
    {
        [Required(ErrorMessage = "Name must be entered")]
        [DisplayName("Name")]
        public string Name { get; init; }

        [DisplayName("Description")]
        public string Description { get; init; }

        [Required(ErrorMessage = "Price must be entered")]
        [Range(0, Int32.MaxValue, ErrorMessage = "A non-negative value must be specified")]
        [DisplayName("Price")]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "Categories must be selected")]
        [DisplayName("Categories")]
        public string[] CategoryIds { get; init; }
    }
}
