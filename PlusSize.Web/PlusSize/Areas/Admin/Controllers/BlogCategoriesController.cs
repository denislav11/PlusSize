using PlusSize.Models.ViewModels.Blogs;
using PlusSize.Services;
using PlusSize.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("blogs/categories")]
    [Authorize(Roles = "Admin")]
    public class BlogCategoriesController : Controller
    {
        private IBlogsService service;
        public BlogCategoriesController(IBlogsService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<BlogsCategoriesAdminVm> vms = this.service.GetAllCategories();
            return View(vms);
        }
        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }
        [HttpPost]
        [Route("add")]
        public ActionResult Add(BlogsCategoriesAdminVm bm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(bm);
            }
            this.service.AddCategory(bm);
            return RedirectToAction("all");
        }
        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            BlogsCategoriesAdminVm vm = this.service.GetCategoryById(id);
            return this.View(vm);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id, BlogsCategoriesAdminVm bm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bm);
            }
            this.service.EditCategory(bm, id);
            return RedirectToAction("all");
        }
        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            BlogsCategoriesAdminVm vm = this.service.GetDeletedCategoryById(id);
            return this.View(vm);
        }
        [HttpPost]
        [Route("delete/{id:int}"), ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteCategory(id);
            return this.RedirectToAction("all");
        }
    }
}