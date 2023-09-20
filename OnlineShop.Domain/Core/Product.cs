
namespace OnlineShop.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<Category> Categories { get; set; }

        public decimal Price { get; set; }
    }
}
