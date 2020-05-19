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
        public void GetProductsUnitTest()
        {
            ProductService _ProductService = new ProductService();

            IEnumerable<ProductDTO> _Products = _ProductService.GetProducts().Result;

            Assert.AreEqual(_Products.Count(), 0);
        }

        [TestMethod]
        public void GetProductsFromAgeUnitTest()
        {
            ProductService _ProductService = new ProductService();

            IEnumerable<ProductDTO> _Products = _ProductService.GetProductsFromAge(21).Result;

            Assert.AreEqual(_Products.Count(), 0);
        }
    }
}
