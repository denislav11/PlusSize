using System.Collections.Generic;

namespace PlusSize.Models.ViewModels.Blogs
{
    public class BlogVm
    {
        public IEnumerable<AllBlogsVm> Blogs{ get; set; }
        public IEnumerable<BlogsCategoriesAdminVm> Categories { get; set; }
    }
}
