using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.BindingModels.Admin
{
    public class AddProductBm
    {
        public string Title { get; set; }

        public string Model { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Category { get; set; }
    }
}
