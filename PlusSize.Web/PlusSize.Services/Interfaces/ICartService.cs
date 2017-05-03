using PlusSize.Models.EntityModels;

namespace PlusSize.Services.Interfaces
{
    public interface ICartService
    {
         Cart GetCart(string strCurrentUserId);

         void Remove(Cart currnetCart, int id);

         string GetProductName(int id);

         decimal GetProductsSum();
    }
}
