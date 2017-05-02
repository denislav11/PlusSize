using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.BindingModels.Checkout
{
    public class CheckoutBm
    {
        [Required]
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int[] ProductId { get; set; }
        public decimal SumTotal { get; set; }
    }
}
