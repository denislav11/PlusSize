using Microsoft.AspNet.Identity;
using PlusSize.Models.BindingModels.Checkout;
using PlusSize.Models.EntityModels;
using PlusSize.Services;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    [RoutePrefix("checkout")]
    [Authorize]
    public class CheckoutController : Controller
    {
        private CheckoutService service;
        public CheckoutController()
        {
            this.service = new CheckoutService();
        }
        [HttpGet]
        [Route]
        public ActionResult SimpleCheckout()
        {
            var strCurrentUserId = User.Identity.GetUserId();
            Cart currnetCart = this.service.GetCart(strCurrentUserId);
            if (currnetCart == null || currnetCart.Products.Count == 0)
            {   
                return this.Redirect("/cart/empty");
            }
            return View(currnetCart);
        }
        [HttpPost]
        [Route]
        [Route("simplecheckout")]
        public ActionResult SimpleCheckout(CheckoutBm bm)
        {
            var strCurrentUserId = User.Identity.GetUserId();
            Cart currnetCart = this.service.GetCart(strCurrentUserId);
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.service.AddOrder(bm);
                    this.service.ClearCart(currnetCart);
                    return RedirectToAction("Success");
                }
                catch (DbEntityValidationException ex)
                {
                    var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                    this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return this.View(currnetCart);
        }

        [HttpGet]
        public ActionResult Success()
        {
            return this.View();
        }
    }
}