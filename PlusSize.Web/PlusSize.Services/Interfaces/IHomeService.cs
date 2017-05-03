using PlusSize.Models.ViewModels.Home;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<ProductInHomeVm> GetTop15Products();
    }
}
