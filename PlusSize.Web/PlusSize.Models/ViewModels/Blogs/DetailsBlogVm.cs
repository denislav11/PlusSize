using System;

namespace PlusSize.Models.ViewModels.Blogs
{
    public class DetailsBlogVm
    {
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public string Content { get; set; }
        public virtual string AuthorName { get; set; }
    }
}
