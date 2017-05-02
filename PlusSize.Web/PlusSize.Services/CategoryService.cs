using AutoMapper;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;

namespace PlusSize.Services
{
    public class CategoryService : Service
    {
        public IEnumerable<ProductCategoryVm> GetProductsFromCategory(string name)
        {
            IEnumerable<Product> models = this.Context.Products.Where(p => p.Category.Title == name);
            IEnumerable<ProductCategoryVm> vms = 
                Mapper.Instance.Map<IEnumerable<Product>, IEnumerable<ProductCategoryVm>>(models);
            return vms;
        }
        public IEnumerable<AllCategoriesVm> GetAllCategories()
        {
            IEnumerable<Category> models = this.Context.Categories;
            IEnumerable<AllCategoriesVm> vms = Mapper.Instance.Map<IEnumerable<Category>, IEnumerable<AllCategoriesVm>>(models);
            return vms;
        }
    }
}