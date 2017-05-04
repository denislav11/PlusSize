using System.Collections.Generic;
using System.Web.Mvc;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Models.BindingModels.Admin;
using PlusSize.Services.Interfaces.Admin;
using System.Data.Entity.Validation;
using System.Linq;

namespace PlusSize.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("categories")]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private IAdminCategoriesService service;

        public CategoriesController(IAdminCategoriesService service)
        {
            this.service = service;
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
            try
            {
                this.service.AddCategory(bm);
                return RedirectToAction("all");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return this.View();
            }
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
            try
            {
                this.service.EditCategory(bm, id);
                return RedirectToAction("all");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                return this.View();
            }
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
