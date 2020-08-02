using ElectricShop.Common.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ElectricShop.Common.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public IEnumerable<CartLine> Lines { get { return lineCollection; } }


        public void AddItem(ProductDTO product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            else
                line.Quantity += quantity;
        }

        public void RemoveLine(ProductDTO product) => lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        
        public decimal ComputeTotalValue() => lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public void Clear() => lineCollection.Clear();
    }

    public class CartLine
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}
