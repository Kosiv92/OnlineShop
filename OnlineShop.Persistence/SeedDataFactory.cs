using OnlineShop.Domain;

namespace OnlineShop.Persistence
{
    public static class SeedDataFactory
    {
        public static Category[] Categories => new Category[]
                    {
                new Category { Id = 1, Name = "Clothes" },
                new Category { Id = 2, Name = "Male"},
                new Category { Id = 3, Name = "Female"}
                    };

        public static Product[] Products => new Product[]
        {
                new Product { Id = 1, Name="Nike Air Jordan", Cost=250, Description="Two greats. One shoe. The AJ6 x PSG delivers American boldness and Parisian flair, repping legends on both the court and the pitch."
                /*,Categories = new Category[]{ categories[0], categories[1] }*/ },
                new Product { Id = 2, Name="PUMA LEMLEM Shorts", Cost=70, Description="PUMA and lemlem come together in a first-of-its-kind collaboration. These biker shorts feature one of lemlem’s signature patterns with asymmetrical pops of color."
                /*,Categories = new Category[]{ categories[0], categories[2] }*/ },
                new Product { Id = 3, Name="Adidas Prime Backpack", Cost=35, Description="This product is excluded from all promotional discounts and offers."
                /*,Categories = new Category[]{ categories[0], categories[1], categories[2] }*/ },
        };
    }
}
