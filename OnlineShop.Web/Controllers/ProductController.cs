using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Models.Product;
using OnlineShop.Contracts;
using OnlineShop.Services.Interfaces;

namespace OnlineShop.Web.Controllers
{
    public class ProductController : Controller
    {
        ILogger<ProductController> _logger;
        IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            IQueryable<ProductListItemDTO> productsDTO = null!;

            _logger.LogDebug($"User {HttpContext.User.Identity.Name} try to get Index view");
            try
            {
                productsDTO = _productService.GetAllDTO();                              

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception {ex.Message} throw while {HttpContext.User.Identity.Name} try to get Index view");
            }


            _logger.LogDebug($"User {HttpContext.User.Identity.Name} successfully get Index view");

            return View(productsDTO);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var productCreateVM = new ProductCreateVM();
            
            return View(productCreateVM);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
