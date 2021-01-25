using NSubstitute;
using Siteware.Application;
using Siteware.Application.Contracts;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Repositories;
using Siteware.Domain.Repositories.Transaction;
using Siteware.Domain.Services;
using Siteware.Domain.Services.Contracts;
using Siteware.Infra.Exceptions;
using Siteware.Test.Transaction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Siteware.Test.AppServices
{
    public class CartAppServiceTests
    {
        private IProductRepository mockProductRepository = NSubstitute.Substitute.For<IProductRepository>();
        private IPromotionRepository mockPromotionRepository = NSubstitute.Substitute.For<IPromotionRepository>();


        private ICartRepository mockCartRepository = NSubstitute.Substitute.For<ICartRepository>(); // Create substitute
        private IUnitOfWork unitOfWork = NSubstitute.Substitute.For<IUnitOfWork>(); // Create substitute

        // case use
        private ICartAppService mockAppService = NSubstitute.Substitute.For<ICartAppService>();




        public CartAppServiceTests()
        {
            mockAppService = new CartAppService(mockProductRepository, mockPromotionRepository, mockCartRepository, unitOfWork);

        }



        [Fact]
        public void AddProduct_Valid()
        {

            //Arrange
            ProductCartModel model = new ProductCartModel
            {
                NameProduct = "Mouse",
                PriceProduct = 10.00M,
                Quantity = 2,
                TypePromotion = Domain.Entities.TypePromotion.ThreeForTen,
            };

            //Act promotion
            mockPromotionRepository.Get(Arg.Any<Expression<Func<Promotion, bool>>>()).Returns(new Promotion("Promoção compre 3 produtos por 10 reais", model.TypePromotion, StatusPromotion.Active));


            //Act product
            mockProductRepository.Get(Arg.Any<Expression<Func<Product, bool>>>()).Returns(new Product(model.NameProduct, model.PriceProduct));

            var addProdut = mockAppService.AddProduct(model);


            //Assert
            Assert.NotNull(addProdut);
            mockCartRepository.Received(1).Insert(Arg.Any<Cart>());
            UnitOfWorkValidation.ValidarUnitOfWorkSucesso(unitOfWork);

        }

        [Fact]
        public void AddProduct_Invalid_ProductInvalidPromotion()
        {

            int idPromotionProduct = 23; //Leve 3 por 10

            //Arrange
            ProductCartModel model = new ProductCartModel
            {
                NameProduct = "Mouse",
                PriceProduct = 10.00M,
                Quantity = 2,
                TypePromotion = Domain.Entities.TypePromotion.BuyOneTakeTwo,
            };

            //Act product
            mockProductRepository.Get(Arg.Any<Expression<Func<Product, bool>>>()).Returns(new Product(model.NameProduct, model.PriceProduct));

            //Act promotion
            mockPromotionRepository.Get(Arg.Any<Expression<Func<Promotion, bool>>>()).Returns(new Promotion());

            //Assert
            Assert.ThrowsAsync<ValidationException>(() => mockAppService.AddProduct(model));

        }
    }
}
