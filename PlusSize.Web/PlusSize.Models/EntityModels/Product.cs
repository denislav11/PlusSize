using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.EntityModels
{
    public class Product
    {
        public Product()
        {
            this.Carts = new HashSet<Cart>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Model { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [MinLength(20)]
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
