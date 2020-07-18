using ElectricShop.Data.Entities;

namespace ElectricShop.Web.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}