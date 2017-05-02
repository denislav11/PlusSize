using PlusSize.Models.ViewModels.Category;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.ViewModels.Admin
{
    public class AddProcuctVm
    {
        public string Title { get; set; }

        public string Model { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        public IEnumerable<AllCategoriesVm> Categories { get; set; }
    }
}
