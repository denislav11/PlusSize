using PlusSize.Models.ViewModels.Category;
using PlusSize.Services;
using PlusSize.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    [RoutePrefix("categories")]

    public class CategoriesController : Controller
    {
        private ICategoryService service;
        public CategoriesController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route]
        [Route("all")]
        public ActionResult All()
        {
            return View();
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult Details(string name)
        {
            if (!this.ModelState.IsValid)
            {
                return this.HttpNotFound();
            }
            IEnumerable<ProductCategoryVm> products =
                this.service.GetProductsFromCategory(name);
            CategoryVm vm = new CategoryVm();

            IEnumerable<AllCategoriesVm> categories =
                this.service.GetAllCategories();

            vm.CategoryTitle = name;
            vm.Products = products;
            vm.AllCategories = categories;

            return this.View(vm);
        }
    }
}