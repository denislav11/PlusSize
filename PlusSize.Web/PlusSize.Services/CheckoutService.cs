using System;
using System.Linq;
using PlusSize.Models.BindingModels.Checkout;
using PlusSize.Models.EntityModels;

namespace PlusSize.Services
{
    public class CheckoutService : Service
    {
        public Cart GetCart(string strCurrentUserId)
        {
            Cart model = this.Context.Carts.FirstOrDefault(c => c.UserId == strCurrentUserId);
            return model;
        }

        public void AddOrder(CheckoutBm bm)
        {
            Order order = new Order
            {
                DataAdded = DateTime.Now,
                Adress=bm.Adress,
                Email=bm.Email,
                Name=bm.Name,
                PhoneNumber=bm.PhoneNumber,
                SumTotal=bm.SumTotal
            };
            foreach (var productId in bm.ProductId)
            {
                Product prod = this.Context.Products.Find(productId);
                order.Products.Add(prod);
            }
            this.Context.Orders.Add(order);
            this.Context.SaveChanges();
        }

        public void ClearCart(Cart currnetCart)
        {
            foreach (var product in currnetCart.Products)
            {
                product.Carts.Remove(currnetCart);
            }
            this.Context.Carts.Remove(currnetCart);
            this.Context.SaveChanges();
        }
    }
}
