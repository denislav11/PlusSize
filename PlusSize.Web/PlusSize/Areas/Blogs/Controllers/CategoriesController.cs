using PlusSize.Models.ViewModels.Blogs;
using PlusSize.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Areas.Blogs.Controllers
{
    [RouteArea("blogs")]
    [RoutePrefix("categories")]
    public class CategoriesController : Controller
    {
        private BlogsService service;
        public CategoriesController()
        {
            this.service = new BlogsService();
        }

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