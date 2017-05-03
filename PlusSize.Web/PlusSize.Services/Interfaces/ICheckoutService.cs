using PlusSize.Models.BindingModels.Checkout;
using PlusSize.Models.EntityModels;

namespace PlusSize.Services.Interfaces
{
    public interface ICheckoutService
    {
        Cart GetCart(string strCurrentUserId);

        void AddOrder(CheckoutBm bm);

        void ClearCart(Cart currnetCart);
    }
}
