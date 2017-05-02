using System.Collections.Generic;

namespace PlusSize.Models.ViewModels.Category
{
    public class CategoryVm
    {
        public string CategoryTitle { get; set; }
        public IEnumerable<ProductCategoryVm> Products { get; set; }
        public IEnumerable<AllCategoriesVm> AllCategories { get; set; }
    }
}
