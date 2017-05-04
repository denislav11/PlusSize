
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Models.BindingModels.Admin;
using System.Data.Entity.Validation;
using PlusSize.Services.Interfaces;
using PlusSize.Services.Interfaces.Admin;
using System.Net;

namespace PlusSize.Areas.Admin.Controllers
{
    [RouteArea("admin")]
    [RoutePrefix("blogs")]
    [Authorize(Roles = "Admin")]
    public class BlogsController : Controller
    {
        private IAdminBlogsService service;
        private IBlogsService blogService;
        private ApplicationUserManager _userManager;

        public BlogsController(IAdminBlogsService service, IBlogsService blogService)
        {
            this.service = service;
            this.blogService = blogService;
        }
        public BlogsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
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
        [Route]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<AdminAllBlogsVm> vms = this.service.GetAllBlogs();
            return View(vms);
        }
        [HttpGet]
        [Route("add")]
        public ActionResult Add()
        {
            AddBlogVm vm = new AddBlogVm
            {
                Categories = this.blogService.GetAllCategories()
            };
            return this.View(vm);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(AddBlogBm bm)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bm);
            }
            try
            {
                var strCurrentUserId = User.Identity.GetUserId();
                this.service.AddBlog(bm, strCurrentUserId);
                return this.RedirectToAction("All");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                AddBlogVm vm = new AddBlogVm
                {
                    Categories = this.blogService.GetAllCategories()
                };
                return this.View(vm);
            }
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            EditBlogVm vm = this.service.GetBlogById(id);
            return this.View(vm);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit(EditBlogBm bm, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(bm);
            }
            try
            {
                this.service.EditBlog(bm, id);
                return RedirectToAction("All");
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                EditBlogVm vm = this.service.GetBlogById(id);
                return this.View(vm);
            }

        }
        [HttpGet]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeleteBlogVm vm = this.service.GetDeletedBlogById(id);

            if (vm==null)
            {
                return HttpNotFound();
            }
            return this.View(vm);
        }
        [HttpPost]
        [Route("delete/{id:int}"), ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteBlog(id);
            return this.RedirectToAction("all");
        }
    }
}