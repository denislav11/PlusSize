using PlusSize.Models.ViewModels.Blogs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.ViewModels.Admin
{
    public class AddBlogVm
    {
        public string Title { get; set; }


        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public IEnumerable<BlogsCategoriesAdminVm> Categories { get; set; }
    }
}
