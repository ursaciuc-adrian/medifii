using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Medifii.ProductService.ArhitecturalTests
{
    public class ArhitecturalTest
    {
        [Fact]
        public void ControllersShouldNotDirectlyReferenceRepositories()
        {
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace("Medifii.ProductService.Controllers")
                .ShouldNot()
                .HaveDependencyOn("Medifii.ProductService.Data")
                .GetResult();
            result.IsSuccessful.Should().BeTrue();
        }
    }
}
