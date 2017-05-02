using PlusSize.Models.ViewModels.Home;
using PlusSize.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    public class HomeController : Controller
    {
        private HomeService homeService;
        public HomeController()
        {
            this.homeService = new HomeService();

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