using ECommerce.Application.Common.Repositories;
using ECommerce.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitTests.Setup.Mocks
{
    public static class MockVariantRepository
    {
        public static Mock<IVariantRepository> GetMockVariantRepository()
        {
            List<Variant> variants = new List<Variant>()
            {
                     new Variant
                {
                    Id = 1,
                    Name  = "Renk Mavi",
                    CreatedDate= DateTime.Now,
                    Code = "1000000851096",
                    ProductId = 1,
                },
                new Variant
                {
                    Id = 2,
                    Name  = "Renk Kirmizi",
                    CreatedDate= DateTime.Now,
                    Code = "1000000851097",
                    ProductId = 1,

                }
            };

            var mockVariantRepository = new Mock<IVariantRepository>();

            mockVariantRepository.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Variant, bool>>>()))
                                     .Returns((Expression<Func<Variant, bool>> predicate) => Task.FromResult(variants.AsQueryable().FirstOrDefault(predicate)));

            return mockVariantRepository;
        }
    }
}
