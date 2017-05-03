using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Products;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<ProductsAdminVm> GetAllProducts();
        OrderVm GetOrderById(int id);
        IEnumerable<AdminCategoryVm> GetAllCategoriesForAdmin();
        IEnumerable<AllCategoriesVm> GetAllCategoriesTitles();
        void DeleteOrder(int id);
        void AddBlog(AddBlogBm bm, string strCurrentUserId);
        IEnumerable<AdminOrderVm> GetAllOrders();
        void AddCategory(AddCategoryBm bm);
        void EditCategory(EditCategoryBm bm, int id);
        DeleteCategoryVm GetDeletedCategoryById(int id);
        EditBlogVm GetBlogById(int id);
        void DeleteCategory(int id);
        DeleteBlogVm GetDeletedBlogById(int id);
        void DeleteBlog(int id);
        void EditBlog(EditBlogBm bm, int id);
        void AddProduct(AddProductBm bm);
        EditProductVm GetProductById(int id);
        EditCategoryVm GetCategoryById(int id);
        void EditProduct(EditProductBm bm, int id);
        DeleteProductVm GetDeletedProductById(int id);
        void DeleteProduct(int id);
        IEnumerable<AdminAllBlogsVm> GetAllBlogs();
    }
}
