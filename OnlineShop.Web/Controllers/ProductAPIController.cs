using Microsoft.AspNetCore.Mvc;
using OnlineShop.Contracts;
using OnlineShop.Domain;
using OnlineShop.Services.Interfaces;
using System.Security.Policy;

namespace OnlineShop.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductAPIController : ControllerBase
    {
        ILogger<ProductController> _logger;
        IProductService _productService;

        public ProductAPIController(ILogger<ProductController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<ProductListItemDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult Index()
        {
            IQueryable<ProductListItemDTO> productsDTO = null!;

            try
            {
                productsDTO = _productService.GetAllDTO();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception {ex.Message} throw while {HttpContext.User.Identity.Name} try to get Index view");
                return BadRequest(ex.Message);
            }

            return Ok(productsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IQueryable<ProductListItemDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            ProductInfoDTO productDTO = await _productService.GetProductInfoDTOAsync(id);

            if (productDTO is null)
            {
                return NotFound();
            }

            return Ok(productDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Int32))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            Product product = (Product)await _productService.Create(request);

            return CreatedAtAction(nameof(Create), new { id = product.Id });
        }

        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Int32))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditRequest request)
        {
           if(request.Id <= 0)
                return NotFound();
            
            Product product = (Product)await _productService.Edit(request);

            return AcceptedAtAction(nameof(Edit), new { id = product.Id });
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Int32))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return NotFound();

            id = (int)await _productService.Delete(id);

            return Ok(id);
        }



        }
}
