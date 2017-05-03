using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusSize.Models.ViewModels.Cart
{
    public class CartRemvoeVm
    {
        public string Message { get; set; }
        public decimal SumTotal { get; set; }
        public int CartCount { get; set; }
        public int DeleteId { get; set; }
        public int ItemCount { get; set; }

    }
}
