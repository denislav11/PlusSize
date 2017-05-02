using System.Collections.Generic;

namespace PlusSize.Models.EntityModels
{
    public class Cart
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
