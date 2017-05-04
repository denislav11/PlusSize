using AutoMapper;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Services.Interfaces.Admin;
using System.Collections.Generic;
using System.Linq;

namespace PlusSize.Services
{
    public class AdminOrdersService : Service, IAdminOrdersService
    {
        public OrderVm GetOrderById(int id)
        {
            Order model = this.Context.Orders.Find(id);
            OrderVm vm = Mapper.Instance.Map<Order, OrderVm>(model);
            return vm;
        }
        public void DeleteOrder(int id)
        {
            Order order = this.Context.Orders.Find(id);
            this.Context.Orders.Remove(order);
            this.Context.SaveChanges();
        }
        public IEnumerable<AdminOrderVm> GetAllOrders()
        {
            IEnumerable<Order> models = this.Context.Orders.Take(10);
            IEnumerable<AdminOrderVm> vms = Mapper.Instance.Map
                <IEnumerable<Order>, IEnumerable<AdminOrderVm>>(models);
            return vms;
        }

    }
}
