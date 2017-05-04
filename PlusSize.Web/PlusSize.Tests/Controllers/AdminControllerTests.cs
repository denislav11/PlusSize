using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlusSize.Areas.Admin.Controllers;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Services;
using PlusSize.Services.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace PlusSize.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void ShouldReturnDefaultView()
        {
            var mock = new Mock<IAdminService>();
            var controller = new AdminController(mock.Object);
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView().WithModel<IEnumerable<AdminOrderVm>>();
        }

    }
}
