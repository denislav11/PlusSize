using AutoMapper;
using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.EntityModels;
using PlusSize.Models.ViewModels.Admin;
using PlusSize.Services.Interfaces.Admin;
using System.Collections.Generic;
using System.Linq;

namespace PlusSize.Services
{
    public class AdminCategoriesService : Service, IAdminCategoriesService
    {
        public IEnumerable<AdminCategoryVm> GetAllCategoriesForAdmin()
        {
            IEnumerable<Category> models = this.Context.Categories;
            IEnumerable<AdminCategoryVm> vms = Mapper.Instance.Map
                <IEnumerable<Category>, IEnumerable<AdminCategoryVm>>(models);
            return vms;
        }
        public void AddCategory(AddCategoryBm bm)
        {
            Category category = new Category
            {
                Title = bm.Title
            };
            this.Context.Categories.Add(category);
            this.Context.SaveChanges();
        }

        public void EditCategory(EditCategoryBm bm, int id)
        {
            Category model = this.Context.Categories.Find(id);
            model.Title = bm.Title;
            this.Context.SaveChanges();
        }

        public DeleteCategoryVm GetDeletedCategoryById(int id)
        {
            Category model = this.Context.Categories.Find(id);
            DeleteCategoryVm vm = Mapper.Instance.Map<Category, DeleteCategoryVm>(model);
            return vm;
        }


        public void DeleteCategory(int id)
        {
            Category model = this.Context.Categories.Find(id);
            foreach (var product in model.Products.ToList())
            {
                product.Category = null;
            }
            this.Context.Categories.Remove(model);
            this.Context.SaveChanges();
        }
        public EditCategoryVm GetCategoryById(int id)
        {
            Category model = this.Context.Categories.Find(id);
            EditCategoryVm vm = Mapper.Instance.Map<Category, EditCategoryVm>(model);
            return vm;
        }

    }
}
