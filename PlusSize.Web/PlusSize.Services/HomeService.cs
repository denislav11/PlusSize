using AutoMapper;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Home;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PlusSize.Services
{
    public class HomeService:Service
    {
        public IEnumerable<ProductInHomeVm> GetTop15Products()
        {
            IEnumerable<Product> topProducts = this.Context.Products.Take(15);
            IEnumerable<ProductInHomeVm> vms = Mapper.Instance
                .Map<IEnumerable<Product>
                ,IEnumerable<ProductInHomeVm>>(topProducts);
            return vms;
        }
    }
}
