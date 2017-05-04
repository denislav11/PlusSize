using AutoMapper;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Blogs;
using PlusSize.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PlusSize.Services
{
    public class BlogsService : Service, IBlogsService
    {
        public IEnumerable<AllBlogsVm> GetAllBlogs()
        {
            IEnumerable<Blog> models = this.Context.Blogs;
            IEnumerable<AllBlogsVm> vms =
                Mapper.Instance.Map<IEnumerable<Blog>, IEnumerable<AllBlogsVm>>(models);
            return vms;
        }
        public IEnumerable<AllBlogsVm> GetAllBlogsFromCategory(int id)
        {
            IEnumerable<Blog> models = this.Context.Blogs.Where(b => b.Category.Id == id);
            IEnumerable<AllBlogsVm> vms =
                Mapper.Instance.Map<IEnumerable<Blog>, IEnumerable<AllBlogsVm>>(models);
            return vms;
        }

        public DetailsBlogVm GetBlogById(int id)
        {
            Blog model = this.Context.Blogs.Find(id);
            DetailsBlogVm vm = Mapper.Instance.Map<Blog, DetailsBlogVm>(model);
            return vm;
        }
        public IEnumerable<BlogsCategoriesAdminVm> GetAllCategories()
        {
            IEnumerable<BlogCategory> models = this.Context.BlogCategories;
            IEnumerable<BlogsCategoriesAdminVm> vms = Mapper.Instance.Map
                <IEnumerable<BlogCategory>, IEnumerable<BlogsCategoriesAdminVm>>(models);
            return vms;
        }

        public IEnumerable<AllBlogsVm> GetBlogsByTitle(string title)
        {
            IEnumerable<Blog> models = this.Context.Blogs.Where(b => b.Title.Contains(title));
            IEnumerable<AllBlogsVm> vms = Mapper.Instance.Map
                <IEnumerable<Blog>, IEnumerable<AllBlogsVm>>(models);
            return vms;
        }

        public void AddCategory(BlogsCategoriesAdminVm bm)
        {
            BlogCategory model = new BlogCategory
            {
                Title = bm.Title
            };
            this.Context.BlogCategories.Add(model);
            this.Context.SaveChanges();
        }

        public BlogsCategoriesAdminVm GetCategoryById(int id)
        {
            BlogCategory model = this.Context.BlogCategories.Find(id);
            BlogsCategoriesAdminVm vm = Mapper.Instance.Map<BlogCategory, BlogsCategoriesAdminVm>(model);
            return vm;
        }

        public void EditCategory(BlogsCategoriesAdminVm bm, int id)
        {
            BlogCategory model = this.Context.BlogCategories.Find(id);
            model.Title = bm.Title;
            this.Context.SaveChanges();
        }

        public BlogsCategoriesAdminVm GetDeletedCategoryById(int? id)
        {
            BlogCategory model = this.Context.BlogCategories.Find(id);
            BlogsCategoriesAdminVm vm =
                Mapper.Instance.Map<BlogCategory, BlogsCategoriesAdminVm>(model);
            return vm;
        }

        public void DeleteCategory(int id)
        {
            BlogCategory model = this.Context.BlogCategories.Find(id);
            foreach (var blog in model.Blogs)
            {
                blog.Category = null;
            }
            this.Context.BlogCategories.Remove(model);
            this.Context.SaveChanges();
        }
    }
}
