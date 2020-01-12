using System;
using System.Linq;
using FluentAssertions;
using Medifii.ProductService.Data.Entities;
using Medifii.ProductService.Data.RepositoryInterfaces;
using Medifii.ProductService.Repositories.ServiceInterfaces;
using Medifii.ProductService.ServiceTests.Factories;
using Moq;
using Xunit;

namespace Medifii.ProductService.ServiceTests
{
    public class ProductServiceTests
    {
        private readonly IProductService sut;
        private readonly Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();

        public ProductServiceTests()
        {
            sut = new Services.Services.ProductService(productRepositoryMock.Object);
            var products = ProductFactory.GetProducts();
            productRepositoryMock.Setup(x => x.GetAll()).Returns(products);
        }

        [Fact]
        public void Given_GetAll_Then_ShouldReturnAllProducts()
        {
            //Arrange
            var expectedResult = ProductFactory.GetProducts();

            //Act
            var result = sut.GetAll();
            
            //Assert
            productRepositoryMock.Verify(x => x.GetAll(), Times.Once);
            result.Should().HaveCount(expectedResult.Count);
        }

        [Fact]
        public void Given_GetById_When_AProductIdIsPassed_Then_ShouldReturnTheProduct()
        {
            //Arrange
            var expected = ProductFactory.GetProduct();
            productRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(expected);

            //Act
            var result = sut.GetById(expected.Id);

            //Assert
            productRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
            result.Value.Should().BeEquivalentTo(expected.ToModel());
        }

        [Fact]
        public void Given_GetProductsByName_Then_ShouldReturnAllProductsWithThatName()
        {
            //Arrange
            var expectedResult = ProductFactory.GetProducts().Select(x => x.ToModel());

            //Act
            var result = sut.GetProductsByName("aspirina");

            //Assert
            result.Should().BeEquivalentTo(expectedResult, x => x.Excluding(field => field.Id));
        }

        [Fact]
        public void Given_Create_When_ModelIsValid_Then_ShouldReturnSuccess()
        {
            //Arrange
            var product = ProductFactory.GetProduct().ToModel();
            productRepositoryMock.Setup(x => x.Create(It.IsAny<Product>()));

            //Act
            var result = sut.Create(product);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Given_Update_When_IdIsValid_Then_ShouldReturnSuccess()
        {
            //Arrange
            var product = ProductFactory.GetUpdatedProduct();
            productRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(ProductFactory.GetProduct());

            //Act
            var result = sut.Update(product.Id, product.ToModel());

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Given_Delete_When_IdIsValid_Then_ShouldReturnSuccess()
        {
            //Arrange
            var product = ProductFactory.GetProduct();
            productRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(product);

            //Act
            var result = sut.Delete(product.Id);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
