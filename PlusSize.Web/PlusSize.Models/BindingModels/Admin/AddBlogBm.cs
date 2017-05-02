using System.ComponentModel.DataAnnotations;

namespace PlusSize.Models.BindingModels.Admin
{
    public class AddBlogBm
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string Category { get; set; }
    }
}
