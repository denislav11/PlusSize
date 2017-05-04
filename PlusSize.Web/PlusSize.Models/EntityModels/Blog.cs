using System;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.EntityModels
{
    public class Blog
    {
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "Title min lenght is 5")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public DateTime UploadDate { get; set; }

        [MinLength(30, ErrorMessage = "Content min lenght is 30")]
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual BlogCategory Category { get; set; }
    }
}
