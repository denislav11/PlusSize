using PlusSize.Models.ViewModels.Category;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<ProductCategoryVm> GetProductsFromCategory(string name);
        IEnumerable<AllCategoriesVm> GetAllCategories();
    }
}
