using Siteware.Application;
using Siteware.Application.TotalPriceCart;
using Siteware.Application.TotalPriceCart.Concrete;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace Siteware.Test.AppServices
{
    public class CalculateProductPromotions
    {

        private static decimal CalculateProductsWithPromotions(ProductCartModel productCart)
        {
            decimal totalPrice = 0;
            switch (productCart.TypePromotion)
            {
                case TypePromotion.Undefined:
                    throw new ValidationException("Promotion undefined.");
                case TypePromotion.ThreeForTen:
                    
                    break;
                case TypePromotion.BuyOneTakeTwo:
                    totalPrice = new CalculateOneTakeTwo().CalculatePriceTotal(productCart);
                    break;
                case TypePromotion.DiscountPercent:
                    totalPrice = new CalculateFivePercent().CalculatePriceTotal(productCart);
                    break;
                default:
                    totalPrice = new CalculatePriceTotalBase().CalculatePriceTotal(productCart);
                    break;

            }

            return totalPrice;
        }

        [Fact]

        public void Type1()
        {
            //Arrange 
            decimal resultadoEsperado = 10.00m;
            ProductCartModel productCart = new ProductCartModel
            {
                NameProduct = "Mouse",
                PriceProduct = 10.00M,
                Quantity = 3,
                TypePromotion = TypePromotion.ThreeForTen
            };

            //Act
            decimal priceTotal = new CalculateThereForTen().CalculatePriceTotal(productCart);


            //Assert
            Assert.Equal(resultadoEsperado, priceTotal);

        }
    }
}
