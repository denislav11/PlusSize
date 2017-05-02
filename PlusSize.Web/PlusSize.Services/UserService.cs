using PlusSize.Models.EntityModels;
using System.Linq;

namespace PlusSize.Services
{
    public class UserService : Service
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
    }
}
