using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.EntityModels
{
    public class BlogCategory
    {
        public BlogCategory()
        {
            this.Blogs = new HashSet<Blog>();
        }
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "Title min lenght is 5")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
