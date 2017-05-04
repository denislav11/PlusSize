using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Products;
using PlusSize.Services.Interfaces.Admin;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace PlusSize.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("products")]
    [Authorize(Roles="Admin")]
    public class ProductsController : Controller
    {
        private IAdminProductsService service;
        public ProductsController(IAdminProductsService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<ProductsAdminVm> vms = this.service.GetAllProducts();
            return this.View(vms);
        }

        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            IEnumerable<AllCategoriesVm> categories = this.service.GetAllCategoriesTitles();
            AddProcuctVm vm = new AddProcuctVm()
            {
                Categories = categories
            };
            return this.View(vm);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(AddProductBm bm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bm);
            }
            try
            {
                this.service.AddProduct(bm);
                return RedirectToAction("all");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                IEnumerable<AllCategoriesVm> categories = this.service.GetAllCategoriesTitles();
                AddProcuctVm vm = new AddProcuctVm()
                {
                    Categories = categories
                };

                return View(vm);
            }
         
        }
        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            IEnumerable<AllCategoriesVm> categories = this.service.GetAllCategoriesTitles();

            EditProductVm vm = this.service.GetProductById(id);
            vm.Categories = categories;
            return this.View(vm);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit(EditProductBm bm, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bm);
            }
            try
            {
                this.service.EditProduct(bm, id);
                return RedirectToAction("All");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                IEnumerable<AllCategoriesVm> categories = this.service.GetAllCategoriesTitles();

                EditProductVm vm = this.service.GetProductById(id);
                vm.Categories = categories;
                return this.View(vm);
            }
           
        }
        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            DeleteProductVm vm = this.service.GetDeletedProductById(id);
            return this.View(vm);
        }
        [HttpPost]
        [Route("delete/{id:int}"),ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteProduct(id);
            return this.RedirectToAction("all");
        }
    }
}