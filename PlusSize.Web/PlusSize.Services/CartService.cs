using PlusSize.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusSize.Services
{
    public class CartService : Service
    {
        public Cart GetCart(string strCurrentUserId)
        {
            Cart model = this.Context.Carts.FirstOrDefault(c => c.UserId == strCurrentUserId);
            return model;
        }

        public void Remove(Cart currnetCart, int id)
        {
            Product model = this.Context.Products.Find(id);
            currnetCart.Products.Remove(model);
            this.Context.SaveChanges();
        }

        public string GetProductName(int id)
        {
            return this.Context.Products.Find(id).Title;
        }

        public decimal GetProductsSum()
        {
            throw new NotImplementedException();
        }
    }
}
