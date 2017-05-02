using System;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.EntityModels
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }

        [MinLength(30)]
        [Required]
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual BlogCategory Category { get; set; }
    }
}
