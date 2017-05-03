using System.Web.Mvc;

namespace PlusSize.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult NotFound(string aspxerrorpath)
        {
            ViewData["error_path"] = aspxerrorpath;

            return View();
        }

        public ActionResult BadRequest(string action)
        {
            ViewData["action"] = action;

            return View();
        }
    }
}