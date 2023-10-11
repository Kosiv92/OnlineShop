using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewRole(string RoleName) 
        {
            return RedirectToAction("Index");
        }
    }
}
