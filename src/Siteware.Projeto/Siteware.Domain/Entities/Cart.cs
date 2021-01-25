using Siteware.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Siteware.Domain.Entities
{
    public class Cart : Entity
    {
        [NotMapped]
        public string NameProduct { get; set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal TotalPrice { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }

        public Cart()
        {

        }

        public Cart(int quantity, decimal price, decimal totalPrice, int productId, string nameProduct)
        {
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
            ProductId = productId;
            NameProduct = nameProduct;

            // Validate(this, new ProductValidations());
            NewCartItem(nameProduct, price, totalPrice, productId, quantity);
        }

        Cart NewCartItem(string product, decimal price, decimal priceTotal, int productId, int quantity)
        {
            return new Cart
            {
                Price = price,
                ProductId = productId,
                Quantity = quantity,
                TotalPrice = priceTotal,
                NameProduct = product

            };
        }
    }
}