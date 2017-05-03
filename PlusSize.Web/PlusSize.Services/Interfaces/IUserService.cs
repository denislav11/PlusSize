using PlusSize.Models.EntityModels;

namespace PlusSize.Services.Interfaces
{
    public interface IUserService
    {
        void Buy(int id, string strCurrentUserId);

        bool IsFirstUser(ApplicationUser user);
    }
}
