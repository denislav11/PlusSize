using Microsoft.AspNet.Identity;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Cart;
using PlusSize.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    [Authorize]
    [RoutePrefix("cart")]
    public class CartController : Controller
    {
        private CartService service;
        public CartController()
        {
            this.service = new CartService();
        }

        [Route]
        [Route("index")]
        public ActionResult Index()
        {
            var strCurrentUserId = User.Identity.GetUserId();
            Cart currnetCart = this.service.GetCart(strCurrentUserId);
            if (currnetCart == null || currnetCart.Products.Count == 0)
            {
                return this.Redirect("/cart/empty");
            }
            return View(currnetCart);
        }

        [HttpGet]
        [Route("empty")]
        public ActionResult Empty()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var strCurrentUserId = User.Identity.GetUserId();
            Cart currnetCart = this.service.GetCart(strCurrentUserId);
            this.service.Remove(currnetCart, id);
            string albumName = this.service.GetProductName(id);

            var results = new CartRemvoeVm
            {
                Message = Server.HtmlEncode(albumName) +
                  " has been removed from your shopping cart.",
                DeleteId = id,
                SumTotal = currnetCart.Products.Sum(p => p.Price)
            };
            return this.Json(results);
        }
    }
}