using ElectricShop.Infrastructure.Models;

namespace ElectricShop.Data.Interfaces
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
