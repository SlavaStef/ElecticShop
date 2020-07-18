using ElectricShop.Data.Models;

namespace ElectricShop.Data.Interfaces
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
