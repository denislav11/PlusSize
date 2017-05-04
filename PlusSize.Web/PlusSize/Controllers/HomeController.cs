using PlusSize.Models.ViewModels.Home;
using PlusSize.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;

        }
        public ActionResult Index()
        {
            IEnumerable<ProductInHomeVm> vms = this.homeService.GetTop15Products();

            return View(vms);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}