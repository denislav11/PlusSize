using PlusSize.Models.BindingModels.Products;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Models.ViewModels.Products;
using PlusSize.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    [RoutePrefix("products")]
    [HandleError(ExceptionType = typeof(Exception), View = "Error")]
    public class ProductsController : Controller
    {
        private IProductsService service;
        public ProductsController(IProductsService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductVm vm = this.service.GetProductById(id);
            if (!this.ModelState.IsValid || vm == null)
            {
                throw new HttpException(404, "No such a product");
            }

            return this.View(vm);
        }
        [HttpPost]
        [Route("{title}")]
        public ActionResult Search(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return this.View(new HashSet<ProductCategoryVm>());
            }
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