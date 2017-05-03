using PlusSize.Models.ViewModels.Blogs;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces
{
    public interface IBlogsService
    {
        IEnumerable<AllBlogsVm> GetAllBlogs();
        IEnumerable<AllBlogsVm> GetAllBlogsFromCategory(int id);

        DetailsBlogVm GetBlogById(int id);
        IEnumerable<BlogsCategoriesAdminVm> GetAllCategories();

        IEnumerable<AllBlogsVm> GetBlogsByTitle(string title);

        void AddCategory(BlogsCategoriesAdminVm bm);

        BlogsCategoriesAdminVm GetCategoryById(int id);

        void EditCategory(BlogsCategoriesAdminVm bm, int id);

        BlogsCategoriesAdminVm GetDeletedCategoryById(int id);

        void DeleteCategory(int id);
    }
}
