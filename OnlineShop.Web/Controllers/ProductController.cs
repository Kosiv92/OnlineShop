using Microsoft.AspNetCore.Mvc;
using OnlineShop.Web.Models.Product;
using OnlineShop.Contracts;
using OnlineShop.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace OnlineShop.Web.Controllers
{
    public class ProductController : Controller
    {
        ILogger<ProductController> _logger;
        IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(ILogger<ProductController> logger,
            IProductService productService,
            ICategoryService categoryService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var productDTO = await _productService.GetProductDTOAsync(id.Value);

            if (productDTO is null)
            {
                return NotFound();
            }

            return View(productDTO);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var productCreateVM = new ProductCreateVM()
            {
                CategorySelectListItem = _categoryService
                .GetAllDTO()
                .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
            };

            return View(productCreateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(new ProductCreateVM
                {
                    Request = request,
                    CategorySelectListItem = _categoryService
                        .GetAllDTO()
                        .Select(c => new SelectListItem(c.Name, c.Id.ToString()))
                });
            }

            try
            {
                await _productService.Create(request);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), 
                    nameof(HomeController));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) NotFound();

            try
            {
                await _productService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
