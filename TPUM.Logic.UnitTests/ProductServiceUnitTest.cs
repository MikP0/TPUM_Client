using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TPUM.Logic.DTOs;
using TPUM.Logic.Services;

namespace TPUM.Logic.UnitTests
{
    [TestClass]
    public class ProductServiceUnitTest
    {
        [TestMethod]
        public void GetProductUnitTest()
        {
            ProductService _ProductService = new ProductService();
            Assert.AreEqual(_ProductService.GetProduct(1).Price, 31.50f);
        }

        [TestMethod]
        public void GetProductsUnitTest()
        {
            ProductService _ProductService = new ProductService();

            IEnumerable<ProductDTO> _Products = _ProductService.GetProducts();

            Assert.AreEqual(_Products.Count(), 3);
        }

        [TestMethod]
        public void GetProductsFromAgeUnitTest()
        {
            ProductService _ProductService = new ProductService();

            IEnumerable<ProductDTO> _Products = _ProductService.GetProductsFromAge(21);

            Assert.AreEqual(_Products.Count(), 3);
        }
    }
}
