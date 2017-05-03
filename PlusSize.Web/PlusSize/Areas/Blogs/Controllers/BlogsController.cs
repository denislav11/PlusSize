using PlusSize.Models.ViewModels.Blogs;
using PlusSize.Services;
using PlusSize.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Areas.Blogs.Controllers
{
    [RouteArea("blogs")]
    public class BlogsController : Controller
    {
        private IBlogsService service;
        public BlogsController(IBlogsService service)
        {
            this.service = service;
        }

        [Route]
        [Route("all")]
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<AllBlogsVm> blogs = this.service.GetAllBlogs();
            IEnumerable<BlogsCategoriesAdminVm> categories = this.service.GetAllCategories();
            BlogVm vm = new BlogVm
            {
                Blogs = blogs,
                Categories = categories
            };
            return View(vm);
        }
        [HttpGet]
        [Route("details/{id:int}")]
        public ActionResult Details(int id)
        {
            DetailsBlogVm vm = this.service.GetBlogById(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("blogs/{title}")]
        public ActionResult Search(string title)
        {
            IEnumerable<AllBlogsVm> blogs = this.service.GetBlogsByTitle(title);
            IEnumerable<BlogsCategoriesAdminVm> categories = this.service.GetAllCategories();
            BlogVm vm = new BlogVm
            {
                Blogs = blogs,
                Categories = categories
            };
            return View(vm);
        }
    }
}