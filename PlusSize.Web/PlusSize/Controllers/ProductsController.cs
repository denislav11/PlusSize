using PlusSize.Models.BindingModels.Products;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Products;
using PlusSize.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : Controller
    {
        private ProductsService service;
        public ProductsController()
        {
            this.service = new ProductsService();
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
            ProductVm vm = this.service.GetProductById(id);
            return this.View(vm);
        }
        [HttpPost]
        [Route("{title}")]
        public ActionResult Search(string title)
        {
            IEnumerable<ProductCategoryVm> vm = this.service.GetProductsByTitle(title);
            return this.View(vm);
        }
        [HttpPost]
        public ActionResult Buy(BuyProductBm bm)
        {
            return this.View();
        }
    }
}