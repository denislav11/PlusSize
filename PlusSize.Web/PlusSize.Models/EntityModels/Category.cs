using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.EntityModels
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(5, ErrorMessage = "Title min lenght is 5")]
        public string Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
