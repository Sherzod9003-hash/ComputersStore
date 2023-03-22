using Market.DataAccess.Repository;
using Market.Models;
using Market.DataAccess.Repository;
using Market.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketS.UnitTest
{
    [TestClass]
    public class VatCalculatorTests
    {
        private VatCalculator _vatCalculator;

        [TestInitialize]
        public void Setup()
        {
            _vatCalculator = new VatCalculator();
        }

        [TestMethod]
        public void CalculateTotalPriceWithVAT_Returns_ProductViewModel_With_Correct_TotalPriceWithVat()
        {
            // Arrange
            var product = new Product { title = "TestProduct", Quantity = 3, Price = 10 };

            // Act
            var result = _vatCalculator.CalculateTotalPriceWithVAT(product);

            // Assert
            Assert.AreEqual(36, result.TotalPriceWithVat);
        }

        [TestMethod]
        public void CalculateTotalPriceWithVAT_Returns_ProductViewModel_With_Correct_Product_Instance()
        {
            // Arrange
            var product = new Product { title = "TestProduct", Quantity = 3, Price = 10 };

            // Act
            var result = _vatCalculator.CalculateTotalPriceWithVAT(product);

            // Assert
            Assert.AreEqual(product, result.Product);
        }

        [TestMethod]
        public void CalculateTotalPriceWithVAT_Returns_Enumerable_Of_ProductViewModel_With_Correct_TotalPriceWithVat()
        {
            // Arrange
            var products = new List<Product>
        {
            new Product { title = "TestProduct1", Quantity = 1, Price = 10 },
            new Product { title = "TestProduct2", Quantity = 2, Price = 20 },
            new Product { title = "TestProduct3", Quantity = 3, Price = 30 },
        };

            // Act
            var results = _vatCalculator.CalculateTotalPriceWithVAT(products);

            // Assert
            Assert.AreEqual(11, results.ElementAt(0).TotalPriceWithVat);
            Assert.AreEqual(42, results.ElementAt(1).TotalPriceWithVat);
            Assert.AreEqual(99, results.ElementAt(2).TotalPriceWithVat);
        }

        [TestMethod]
        public void CalculateTotalPriceWithVAT_Returns_Enumerable_Of_ProductViewModel_With_Correct_Product_Instances()
        {
            // Arrange
            var products = new List<Product>
        {
            new Product { title = "TestProduct1", Quantity = 1, Price = 10 },
            new Product { title = "TestProduct2", Quantity = 2, Price = 20 },
            new Product { title = "TestProduct3", Quantity = 3, Price = 30 },
        };

            // Act
            var results = _vatCalculator.CalculateTotalPriceWithVAT(products);

            // Assert
            Assert.AreEqual(products.ElementAt(0), results.ElementAt(0).Product);
            Assert.AreEqual(products.ElementAt(1), results.ElementAt(1).Product);
            Assert.AreEqual(products.ElementAt(2), results.ElementAt(2).Product);
        }
    }
}
