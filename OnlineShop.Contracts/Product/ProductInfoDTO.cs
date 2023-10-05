using System.ComponentModel;

namespace OnlineShop.Contracts
{
    public record ProductInfoDTO
    {
        public int Id { get; init; }

        [DisplayName("Name")]
        public string Name { get; init; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Cost")]
        public decimal Price { get; init; }

        [DisplayName("Categories")]
        public ICollection<CategoryListItemDTO> Categories { get; set; }
    }
}
