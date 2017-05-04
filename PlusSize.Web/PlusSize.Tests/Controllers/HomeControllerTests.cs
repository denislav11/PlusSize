using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlusSize.Controllers;
using PlusSize.Models.ViewModels.Home;
using PlusSize.Services;
using PlusSize.Services.Interfaces;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace PlusSize.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void AboutShouldReturnDefaultView()
        {
            var mock = new Mock<IHomeService>();
            var controller = new HomeController(mock.Object);
            controller.WithCallTo(c => c.About())          .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void IndexShouldReturnDefaultViewWithModel()
        {
            var mock = new Mock<IHomeService>();
            var controller = new HomeController(mock.Object);
            controller.WithCallTo(c => c.Index())          .ShouldRenderDefaultView().WithModel<IEnumerable<ProductInHomeVm>>()
          .AndNoModelErrors();
        }
    }
}
