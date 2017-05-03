using PlusSize.Models.ViewModels.Blogs;
using PlusSize.Services;
using PlusSize.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Areas.Blogs.Controllers
{
    [RouteArea("blogs")]
    [RoutePrefix("categories")]
    public class CategoriesController : Controller
    {
        private IBlogsService service;
        public CategoriesController(IBlogsService service)
        {
            this.service = service;
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