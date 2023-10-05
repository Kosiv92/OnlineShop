using System.ComponentModel;

namespace OnlineShop.Contracts
{
    public record ProductListItemDTO
    {
        public int Id { get; init; }

        [DisplayName("Name")]
        public string Name { get; init; }

        [DisplayName("Cost")]
        public decimal Price { get; init; }

        [DisplayName("Categories")]
        public string Categories { get; init; }
    }
}