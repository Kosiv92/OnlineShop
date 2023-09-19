using System.ComponentModel;

namespace OnlineShop.Web
{
    public record ProductListItemDTO
    {
        [DisplayName("Name")]
        public string Name { get; init; }

        [DisplayName("Cost")]
        public decimal Cost { get; init; }

        [DisplayName("Categories")]
        public string Categories { get; init; }
    }
}