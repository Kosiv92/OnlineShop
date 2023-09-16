
namespace OnlineShop.Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        ICollection<Category> Categories { get; set; }

        public decimal Cost { get; set; }
    }
}
