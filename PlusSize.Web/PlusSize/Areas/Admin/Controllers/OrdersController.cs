using PlusSize.Models.ViewModels.Admin;
using PlusSize.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("orders")]
    public class OrdersController : Controller
    {
        private AdminService service;
        public OrdersController()
        {
            this.service = new AdminService();
        }

        [HttpGet]
        [Route("view/{id:int}")]
        public ActionResult View(int id)
        {
            OrderVm vm = this.service.GetOrderById(id);
            return View(vm);
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<AdminOrderVm> orders = this.service.GetAllOrders();
            return this.View(orders);
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            DeleteOrderVm vm = new DeleteOrderVm
            {
                Id = id
            };
            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/{id:int}"),ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return HttpNotFound();
            }
            this.service.DeleteOrder(id);
            return this.RedirectToAction("All");
        }
    }
}