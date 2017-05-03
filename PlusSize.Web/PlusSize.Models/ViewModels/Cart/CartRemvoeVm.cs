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
