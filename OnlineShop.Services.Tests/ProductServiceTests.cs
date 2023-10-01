using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OnlineShop.Contracts;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Tests.Common;
using OnlineShop.Web.Common;

namespace OnlineShop.Services.Tests
{
    public class ProductServiceTests : IClassFixture<TestFixture>
    {
        private Mock<IProductService> _productServiceMock
                            = new Mock<IProductService>(); 
        private IServiceProvider _serviceProvider;

        public ProductServiceTests(TestFixture testFixture) 
        {
            _productServiceMock = new Mock<IProductService>();
            _serviceProvider = testFixture.ServiceProvider;
        }
        
        [Fact]
        public async Task It_Returns_NotNull_For_GetProductInfoDTO()
        {
            //Arrange
            IProductService productService = _productServiceMock.Object;                        
            
            _productServiceMock.Setup(s =>
            s.GetProductInfoDTOAsync(It.IsAny<int>())).ReturnsAsync(new ProductInfoDTO());

            //Act
            ProductInfoDTO receivedDTO = await productService.GetProductInfoDTOAsync(1);

            //Assert
            Assert.NotNull(receivedDTO);
        }

        [Fact]
        public async Task It_Returns_NotNull_GetAllDTO()
        {
            //Assert
            var ass = typeof(ProductProfile).Assembly;

            IProductService productService = new ProductService(_serviceProvider.GetRequiredService<IUnitOfWork>(),
                _serviceProvider.GetRequiredService<IMapper>());

            //Act
            IQueryable<ProductListItemDTO> productListItemDTOs = productService.GetAllDTO();

            //Assert
            Assert.NotNull(productListItemDTOs);

        }


    }
}