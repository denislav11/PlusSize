using PlusSize.Models.BindingModels.Products;
using PlusSize.Models.EntityModels;

namespace PlusSize.Services.Interfaces
{
    public interface IUserService
    {
        void Buy(int id, string strCurrentUserId);

        bool IsFirstUser(ApplicationUser user);
        void FastOrder(FastOrderBm bm, int id);
    }
}
