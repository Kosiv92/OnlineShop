using Moq;
using OnlineShop.Contracts;
using OnlineShop.Services.Interfaces;

namespace OnlineShop.Services.Tests
{
    public class ProductServiceTests
    {
        private Mock<IProductService> _productServiceMock
                            = new Mock<IProductService>();        

        public ProductServiceTests() 
        {
            _productServiceMock = new Mock<IProductService>();             
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


    }
}