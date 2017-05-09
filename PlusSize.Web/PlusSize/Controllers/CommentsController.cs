using PlusSize.Models.BindingModels.Comments;
using PlusSize.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlusSize.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentsService service;
        public CommentsController(ICommentsService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("add/{id:int}")]
        public ActionResult Add(AddCommentBm bm, int id)
        {
            try
            {
                this.service.Add(id, bm);              
            }
            catch (DbEntityValidationException ex)
            {
                var error = ex.EntityValidationErrors.First().ValidationErrors.First();
                this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);             
            }
            return this.Redirect("/products/" + id);
        }
    }
}