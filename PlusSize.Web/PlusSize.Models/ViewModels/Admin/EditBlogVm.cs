using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.ViewModels.Admin
{
    public class EditBlogVm
    {
        public string Title { get; set; }
        [MinLength(30)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
