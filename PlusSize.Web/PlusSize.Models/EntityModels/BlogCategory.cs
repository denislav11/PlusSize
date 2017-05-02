using System.Collections.Generic;

namespace PlusSize.Models.EntityModels
{
    public class BlogCategory
    {
        public BlogCategory()
        {
            this.Blogs = new HashSet<Blog>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
