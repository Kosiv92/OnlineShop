using System.ComponentModel;

namespace OnlineShop.Contracts
{
    public record ProductListItemDTO
    {
        [DisplayName("Name")]
        public string Name { get; init; }

        [DisplayName("Cost")]
        public decimal Price { get; init; }

        [DisplayName("Categories")]
        public string Categories { get; init; }
    }
}