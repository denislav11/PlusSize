using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusSize.Models.EntityModels
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Author { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }
        public DateTime DataAdded { get; set; }
        public virtual Product Product { get; set; }
    }
}
