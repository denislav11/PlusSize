using PlusSize.Models.ViewModels.Admin;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces.Admin
{
    public interface IAdminOrdersService
    {
        OrderVm GetOrderById(int id);
        void DeleteOrder(int id);
        IEnumerable<AdminOrderVm> GetAllOrders();
    }
}
