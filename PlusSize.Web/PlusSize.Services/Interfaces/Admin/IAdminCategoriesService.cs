using PlusSize.Models.BindingModels.Admin;
using PlusSize.Models.ViewModels.Admin;
using System.Collections.Generic;

namespace PlusSize.Services.Interfaces.Admin
{
    public interface IAdminCategoriesService
    {
        IEnumerable<AdminCategoryVm> GetAllCategoriesForAdmin();
        void AddCategory(AddCategoryBm bm);
        void EditCategory(EditCategoryBm bm, int id);
        DeleteCategoryVm GetDeletedCategoryById(int id);
        EditCategoryVm GetCategoryById(int id);
        void DeleteCategory(int id);
    }
}
