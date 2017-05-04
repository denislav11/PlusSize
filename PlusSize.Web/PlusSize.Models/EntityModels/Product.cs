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

        [MinLength(5,ErrorMessage ="Title min lenght is 5")]
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [MinLength(20,ErrorMessage ="Description min lenght is 20")]
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
