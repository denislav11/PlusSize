using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlusSize.Areas.Admin.Controllers;
using PlusSize.Models.ViewModels.Blogs;
using PlusSize.Services.Interfaces;
using PlusSize.Services.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace PlusSize.Tests.Controllers
{
    [TestClass]
    public class AdminBlogsCategoriesControllerTests
    {
        [TestMethod]
        public void DeleteNullParameterBadRequest()
        {
            var mock = new Mock<IBlogsService>();
            var controller = new BlogCategoriesController(mock.Object);
            controller.WithCallTo(c => c.Delete(null))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }
        
        [TestMethod]
        public void DeleteNotFound()
        {
            var mock = new Mock<IBlogsService>();
            var controller = new BlogCategoriesController(mock.Object);
            controller.WithCallTo(c => c.Delete(-1))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void AddGetMethod()
        {
            var mock = new Mock<IBlogsService>();
            var controller = new BlogCategoriesController(mock.Object);
            controller.WithCallTo(c => c.Add())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void AddPostMethod()
        {
            var mock = new Mock<IBlogsService>();
            var controller = new BlogCategoriesController(mock.Object);


            controller.WithCallTo(c => c.Add(new BlogsCategoriesAdminVm
            {
                Title = "Test Category"
            }))
               .ShouldRedirectTo(c => c.All);
        }
    }
}
