using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Products;
using System.Collections.Generic;
using System.Web;

namespace PlusSize.Services.Interfaces.Admin
{
    public interface IAdminProductsService
    {
        IEnumerable<ProductsAdminVm> GetAllProducts();
        EditProductVm GetProductById(int id);
        void EditProduct(EditProductBm bm, int id);
        DeleteProductVm GetDeletedProductById(int id);
        void DeleteProduct(int id);
        IEnumerable<AllCategoriesVm> GetAllCategoriesTitles();
        void AddProduct(AddProductBm bm);
    }
}
