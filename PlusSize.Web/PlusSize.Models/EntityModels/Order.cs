using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.EntityModels
{
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        [MinLength(3)]
       // [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [Required]
        public string Adress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal SumTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataAdded { get; set; }

    }
}
