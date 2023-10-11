using Microsoft.AspNetCore.Identity;

namespace OnlineShop.DbContext
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public string Country { get; set; }
    }
}
