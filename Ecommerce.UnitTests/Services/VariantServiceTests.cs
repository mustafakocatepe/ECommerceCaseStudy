using Ecommerce.UnitTests.Setup.Mocks;
using ECommerce.Application.Common.Repositories;
using ECommerce.Application.Services;
using ECommerce.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ecommerce.UnitTests.Services
{
    public class VariantServiceTests
    {
        private readonly IVariantRepository _variantRepository;
        public VariantServiceTests()
        {
            _variantRepository = MockVariantRepository.GetMockVariantRepository().Object;
        }

        [Theory]
        [InlineData("1000000851096")]
        public void DetailAsync_Return_Variant(string variantCode)
        {
            // Arrange           
            var variantService = new VariantService(_variantRepository);

            // Act
            var result = variantService.Detail(variantCode).Result;

            // Assert
            result.Should().BeOfType<Variant>()
                           .And.NotBeNull();
            result.Code.Should().Be(variantCode);
        }
    }
}
