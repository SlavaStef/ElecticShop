using ElectricShop.Data.Entities;

namespace ElectricShop.Data.Interfaces
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
