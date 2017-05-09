using PlusSize.Models.EntityModels;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using PlusSize.Services.Interfaces;
using PlusSize.Models.BindingModels.Products;
using System;

namespace PlusSize.Services
{
    public class UserService : Service, IUserService
    {
        public void Buy(int id, string strCurrentUserId)
        {
            var product = this.Context.Products.Find(id);
            var cart = this.Context.Carts.FirstOrDefault(c => c.User.Id == strCurrentUserId);
            if (cart == null)
            {
                var user = this.Context.Users.Find(strCurrentUserId);
                cart = new Cart();
                cart.User = user;
                cart.Products.Add(product);
                this.Context.Carts.Add(cart);
                this.Context.SaveChanges();
                return;
            }
            cart.Products.Add(product);
            this.Context.SaveChanges();
        }

        public void FastOrder(FastOrderBm bm, int id)
        {
            Product product = this.Context.Products.Find(id);
            Order order = new Order
            {
                DataAdded = DateTime.Now,
                Adress = bm.Adress,
                Name = bm.Name,
                PhoneNumber = bm.PhoneNumber,
                SumTotal = product.Price
            };
            order.Products.Add(product);
            this.Context.Orders.Add(order);
            this.Context.SaveChanges();
        }

        public bool IsFirstUser(ApplicationUser user)
        {
            if (this.Context.Users.Count() == 1)
            {
                this.Context.Roles.Add(new IdentityRole { Name = "Admin" });
                this.Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
