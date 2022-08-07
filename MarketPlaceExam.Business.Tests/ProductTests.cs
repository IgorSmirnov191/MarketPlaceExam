using AutoMapper;
using MarketPlaceExam.Business.Configuration;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services;
using MarketPlaceExam.Business.Services.Interfaces;
using MarketPlaceExam.Data.Entities;
using MarketPlaceExam.Data.Repos.Interfaces;
using Moq;

namespace MarketPlaceExam.Business.Tests
{
    public class ProductTests
    {
        private Mock<IProductRepo> repoMock;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IProductRepo>();
            var mockEntity = new Product()
            {
                Id = 1,
                Name = "I am a mock product",
                Price = 25,
            };

            repoMock.Setup(x => x.GetProduct(It.IsAny<int>()))
                .ReturnsAsync(mockEntity);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BusinessMapperProfile>();
            });
            mapper = mockMapper.CreateMapper();
        }

        [Test]
        public async Task GetProduct_ShouldRetrieveProductFromDB_AndMapToBusinessModel()
        {
            // ARRANGE
            IProductService _service = new ProductService(repoMock.Object, mapper);
            int id = 1;

            // ACT
            ProductModel result = await _service.GetProduct(id);

            // ASSERT
            Assert.That(result.Id, Is.EqualTo(1));
        }
    }
}