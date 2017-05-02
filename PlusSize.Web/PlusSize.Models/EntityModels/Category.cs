using System.Collections.Generic;

namespace PlusSize.Models.EntityModels
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
