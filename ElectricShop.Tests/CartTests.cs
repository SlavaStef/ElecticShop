using ElectricShop.Common.DTO;
using ElectricShop.Common.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;

namespace ElectricShop.Tests
{
    [TestFixture]
    public class CartTests
    {
        [Test]
        public void Can_Add_New_Lines()
        {
            ProductDTO product1 = new ProductDTO { Id = 1, Name = "Product1", Price = 100 };
            ProductDTO product2 = new ProductDTO { Id = 2, Name = "Product2", Price = 200 };

            Cart target = new Cart();

            target.AddItem(product1, 1);
            target.AddItem(product2, 1);
            CartLine[] results = target.Lines.ToArray();

            Assert.That(results.Length, Is.EqualTo(2));
            Assert.That(results[0].Product, Is.EqualTo(product1));
            Assert.That(results[1].Product, Is.EqualTo(product2));
        }

        [Test]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            ProductDTO product1 = new ProductDTO { Id = 1, Name = "Product1", Price = 100 };
            ProductDTO product2 = new ProductDTO { Id = 2, Name = "Product2", Price = 200 };

            Cart target = new Cart();

            target.AddItem(product1, 1);
            target.AddItem(product2, 1);
            target.AddItem(product1, 10);
            CartLine[] results = target.Lines.OrderBy(c => c.Product.Id).ToArray();

            Assert.That(results.Length, Is.EqualTo(2));
            Assert.That(results[0].Quantity, Is.EqualTo(11));
            Assert.That(results[1].Quantity, Is.EqualTo(1));
        }

        [Test]
        public void Can_Remove_Line()
        {
            ProductDTO product1 = new ProductDTO { Id = 1, Name = "Product1", Price = 100 };
            ProductDTO product2 = new ProductDTO { Id = 2, Name = "Product2", Price = 200 };
            ProductDTO product3 = new ProductDTO { Id = 3, Name = "Product3", Price = 300 };

            Cart target = new Cart();

            target.AddItem(product1, 1);
            target.AddItem(product2, 3);
            target.AddItem(product3, 5);
            target.AddItem(product2, 1);

            target.RemoveLine(product2);

            Assert.That(target.Lines.Where(c => c.Product == product2).Count(), Is.EqualTo(0));
            Assert.That(target.Lines.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Calculate_Cart_Total()
        {
            ProductDTO product1 = new ProductDTO { Id = 1, Name = "Product1", Price = 100 };
            ProductDTO product2 = new ProductDTO { Id = 2, Name = "Product2", Price = 200 };

            Cart target = new Cart();

            target.AddItem(product1, 1);
            target.AddItem(product2, 1);
            target.AddItem(product1, 3);
            decimal result = target.ComputeTotalValue();

            Assert.That(result, Is.EqualTo(600));
        }

        [Test]
        public void Can_Clean_Contents()
        {
            ProductDTO product1 = new ProductDTO { Id = 1, Name = "Product1", Price = 100 };
            ProductDTO product2 = new ProductDTO { Id = 2, Name = "Product2", Price = 200 };

            Cart target = new Cart();

            target.AddItem(product1, 1);
            target.AddItem(product2, 1);
            
            target.Clear();

            Assert.That(target.Lines.Count(), Is.EqualTo(0));
        }
    }
}
