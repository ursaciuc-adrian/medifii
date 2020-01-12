using System;
using System.Linq;
using FluentAssertions;
using Medifii.PharmacyService.Data.Entities;
using Medifii.PharmacyService.Data.RepositoryInterfaces;
using Medifii.PharmacyService.Repositories.ServiceInterfaces;
using Medifii.PharmacyService.UnitTests.Factories;
using Moq;
using Xunit;

namespace Medifii.PharmacyService.UnitTests
{
    public class PharmacyServiceTests
    {
        private readonly IPharmacyService sut;
        private readonly Mock<IPharmacyRepository> pharmacyRepositoryMock = new Mock<IPharmacyRepository>();

        public PharmacyServiceTests()
        {
            sut = new Services.Services.PharmacyService(pharmacyRepositoryMock.Object);
            var pharmacies = PharmacyFactory.GetPharmacies();
            pharmacyRepositoryMock.Setup(x => x.GetAll()).Returns(pharmacies);
        }

        [Fact]
        public void Given_GetAll_Then_ShouldReturnAllPharmacies()
        {
            //Arrange
            var expectedResult = PharmacyFactory.GetPharmacies();

            //Act
            var result = sut.GetAll();

            //Assert
            pharmacyRepositoryMock.Verify(x => x.GetAll(), Times.Once);
            result.Should().HaveCount(expectedResult.Count());
        }

        [Fact]
        public void Given_GetById_When_APharmacyIdIsPassed_Then_ShouldReturnThePharmacy()
        {
            //Arrange
            var expected = PharmacyFactory.GetPharmacy();
            pharmacyRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(expected);

            //Act
            var result = sut.GetById(expected.Id);

            //Assert
            pharmacyRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
            result.Value.Should().BeEquivalentTo(expected.ToModel());
        }

        [Fact]
        public void Given_Create_When_ModelIsValid_Then_ShouldReturnSuccess()
        {
            //Arrange
            var pharmacy = PharmacyFactory.GetPharmacy().ToModel();
            pharmacyRepositoryMock.Setup(x => x.Create(It.IsAny<Pharmacy>()));

            //Act
            var result = sut.Create(pharmacy);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Given_Update_When_IdIsValid_Then_ShouldReturnSuccess()
        {
            //Arrange
            var pharmacy = PharmacyFactory.GetUpdatePharmacy();
            pharmacyRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(PharmacyFactory.GetPharmacy());

            //Act
            var result = sut.Update(pharmacy.Id, pharmacy.ToModel());

            //Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Given_Delete_When_IdIsValid_Then_ShouldReturnSuccess()
        {
            //Arrange
            var pharmacy = PharmacyFactory.GetPharmacy();
            pharmacyRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(pharmacy);

            //Act
            var result = sut.Delete(pharmacy.Id);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }
    }
}
