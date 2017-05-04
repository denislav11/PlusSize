using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Products;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces
{
    public interface IProductsService
    {
         ProductVm GetProductById(int? id);
         IEnumerable<ProductCategoryVm> GetProductsByTitle(string title);
    }
}
