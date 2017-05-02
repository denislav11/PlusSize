using System;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.ViewModels.Admin
{
    public class AdminOrderVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataAdded { get; set; }
        public decimal SumTotal { get; set; }
    }
}
