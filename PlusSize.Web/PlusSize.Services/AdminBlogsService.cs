using AutoMapper;
using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Services.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlusSize.Services
{
    public class AdminBlogsService : Service, IAdminBlogsService
    {
        public IEnumerable<AdminAllBlogsVm> GetAllBlogs()
        {
            IEnumerable<Blog> models = this.Context.Blogs;
            IEnumerable<AdminAllBlogsVm> vms = Mapper.Instance.Map
                <IEnumerable<Blog>, IEnumerable<AdminAllBlogsVm>>(models);
            return vms;
        }
        public void DeleteBlog(int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            this.Context.Blogs.Remove(model);
            this.Context.SaveChanges();
        }

        public void EditBlog(EditBlogBm bm, int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            model.Title = bm.Title;
            model.Content = bm.Content;
            this.Context.SaveChanges();
        }
        public EditBlogVm GetBlogById(int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            EditBlogVm vm = Mapper.Instance.Map<Blog, EditBlogVm>(model);
            return vm;
        }
        public void AddBlog(AddBlogBm bm, string strCurrentUserId)
        {
            ApplicationUser user = this.Context.Users.Find(strCurrentUserId);
            BlogCategory category = this.Context.BlogCategories.FirstOrDefault(b => b.Title == bm.Category);
            Blog model = new Blog
            {
                UploadDate = DateTime.Now,
                Content = bm.Content,
                Title = bm.Title,
                Author = user,
                Category = category
            };
            this.Context.Blogs.Add(model);
            this.Context.SaveChanges();
        }
        public DeleteBlogVm GetDeletedBlogById(int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            DeleteBlogVm vm = Mapper.Instance.Map<Blog, DeleteBlogVm>(model);
            return vm;
        }

    }
}
