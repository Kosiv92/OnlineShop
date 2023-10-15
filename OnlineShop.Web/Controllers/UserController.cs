using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DbContext;
using OnlineShop.Web.Models;

namespace OnlineShop.Web.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<ApplicationIdentityUser> _userManager;

        public UserController(ILogger<UserController> logger, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationIdentityUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewRole(RoleModel roleModel) 
        {
            string roleName = roleModel.RoleName.Trim();

            if (!string.IsNullOrEmpty(roleName))
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Name = roleName,
                        NormalizedName = roleName
                    });
                }
            }  
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleModel roleModel)
        {
            string roleName = roleModel.RoleName.Trim();

            if (!string.IsNullOrEmpty(roleName))
            {
                var usr = await _userManager.GetUserAsync(this.User);
                await _userManager.AddToRoleAsync(usr, roleName);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(RoleModel roleModel)
        {
            string roleName = roleModel.RoleName.Trim();

            if (!string.IsNullOrEmpty(roleName))
            {
                var usr = await _userManager.GetUserAsync(this.User);
                await _userManager.RemoveFromRoleAsync(usr, roleName);
            }
            return RedirectToAction("Index");
        }
    }
}
