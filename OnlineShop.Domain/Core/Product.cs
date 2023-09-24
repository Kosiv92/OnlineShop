namespace OnlineShop.Domain
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; set; }

        public string? Description { get; set; }              

        public decimal Price { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
