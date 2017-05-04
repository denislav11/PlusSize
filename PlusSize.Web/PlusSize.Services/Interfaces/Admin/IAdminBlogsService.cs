using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.ViewModels.Admin;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces.Admin
{
    public interface IAdminBlogsService
    {
        void AddBlog(AddBlogBm bm, string strCurrentUserId);
        DeleteBlogVm GetDeletedBlogById(int id);
        EditBlogVm GetBlogById(int id);
        IEnumerable<AdminAllBlogsVm> GetAllBlogs();
        void DeleteBlog(int id);
        void EditBlog(EditBlogBm bm, int id);
    }
}
