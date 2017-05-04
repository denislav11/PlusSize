using PlusSize.Models.ViewModels.Admin;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces.Admin
{
    public interface IAdminService
    {
        IEnumerable<AdminOrderVm> GetAllOrders();        
    }
}
