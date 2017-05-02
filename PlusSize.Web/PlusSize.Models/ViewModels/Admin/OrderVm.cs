using System;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.ViewModels.Admin
{
    public class OrderVm
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Adress { get; set; }
        
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal SumTotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataAdded { get; set; }

    }
}
