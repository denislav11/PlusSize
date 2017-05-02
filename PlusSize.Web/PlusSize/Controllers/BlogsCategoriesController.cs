using PlusSize.Models.ViewModels.Blogs;
using PlusSize.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    public class BlogsCategoriesController : Controller
    {
        private BlogsService service;
        public BlogsCategoriesController()
        {
            this.service = new BlogsService();
        }
        // GET: BlogsCategories
        [Route("{id:int}/blogs")]
        [HttpGet]
        public ActionResult AllBlogs(int id)
        {
            IEnumerable<AllBlogsVm> blogs = this.service.GetAllBlogsFromCategory(id);
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