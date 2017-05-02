using System.Collections.Generic;
using System.Web.Mvc;
using PlusSize.Services;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Models.BindingModels.Admin;

namespace PlusSize.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("categories")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private AdminService service;

        public CategoriesController()
        {
            this.service = new AdminService();
        }

        // GET: AdminCategories
        [Route]
        [Route("all")]
        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<AdminCategoryVm> vms = this.service.GetAllCategoriesForAdmin();
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
        public ActionResult Add(AddCategoryBm bm)
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
            EditCategoryVm vm = this.service.GetCategoryById(id);
            return this.View(vm);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id, EditCategoryBm bm)
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
            DeleteCategoryVm vm = this.service.GetDeletedCategoryById(id);
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
