using Microsoft.AspNet.Identity.Owin;
using PlusSize.Models.ViewModels.Account;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PlusSize.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private AdminService service;
        public AdminController()
        {
            this.service = new AdminService();
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("index")]
        public ActionResult Index()
        {
            IEnumerable<AdminOrderVm> orders = this.service.GetAllOrders();
            return this.View(orders);
        }

        [HttpGet]
        [Route]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.IsInRole("Admin"))
            {
                return Redirect("/admin/index");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    if (!User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Login");
                    }
                    return RedirectToAction("Index");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }




        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}