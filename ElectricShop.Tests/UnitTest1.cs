using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ElectricShop.Data.Abstract;
using ElectricShop.Data.Entities;
using ElectricShop.Web.Controllers;
using ElectricShop.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ElectricShop.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository> ();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID = 1 , Name = "P1" },
                new Product { ProductID = 2 , Name = "P2" },
                new Product { ProductID = 3 , Name = "P3" },
                new Product { ProductID = 4 , Name = "P4" },
                new Product { ProductID = 5 , Name = "P5" }
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Send_PAgination_View_Model()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product { ProductID = 1 , Name = "P1" },
                new Product { ProductID = 2 , Name = "P2" },
                new Product { ProductID = 3 , Name = "P3" },
                new Product { ProductID = 4 , Name = "P4" },
                new Product { ProductID = 5 , Name = "P5" }
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
