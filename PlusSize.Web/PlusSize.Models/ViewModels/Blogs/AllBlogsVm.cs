using System;

namespace PlusSize.Models.ViewModels.Blogs
{
    public class AllBlogsVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime UploadDate { get; set; }
        public string ShortContent { get; set; }
        public string AuthorName { get; set; }
    }
}
