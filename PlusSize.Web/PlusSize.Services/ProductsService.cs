using AutoMapper;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Products;
using System.Collections.Generic;
using System.Linq;
using PlusSize.Models.ViewModels.Category;
using PlusSize.Services.Interfaces;

namespace PlusSize.Services
{
    public class ProductsService : Service,IProductsService
    {
        public ProductVm GetProductById(int id)
        {
            Product model = this.Context.Products.Find(id);
            ProductVm vm = Mapper.Instance.Map<Product, ProductVm>(model);
            return vm;
        }

        public IEnumerable<ProductCategoryVm> GetProductsByTitle(string title)
        {
            IEnumerable<Product> models = this.Context.Products.Where(p => p.Title.Contains(title));
            IEnumerable<ProductCategoryVm> vms = Mapper.Instance.Map
                <IEnumerable<Product>, IEnumerable<ProductCategoryVm>>(models);
            return vms;
        }
    }
}
