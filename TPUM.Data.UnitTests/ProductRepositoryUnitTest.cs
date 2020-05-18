using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPUM.Data.Model;
using TPUM.Data.Repositiories;

namespace TPUM.Data.UnitTests
{
    [TestClass]
    public class ProductRepositoryUnitTest
    {
        [TestMethod]
        public void CreateTest()
        {
            DataContext dataContext = new DataContext { Products = new List<Product>() };
            ProductRepository productRepository = new ProductRepository(dataContext);
            Assert.IsNotNull(productRepository);
        }
        [TestMethod]
        public void GetTest()
        {
            DataContext dataContext = new DataContext { Products = new List<Product>() };
            ProductRepository productRepository = new ProductRepository(dataContext);
            IEnumerable<Product> products = productRepository.Get();
            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void AddTest()
        {
            DataContext dataContext = new DataContext { Products = new List<Product>() };
            ProductRepository productRepository = new ProductRepository(dataContext);
            productRepository.Add(new Product
            {
                Id = 1,
                AllowedFromDate = new DateTime(2000, 1, 1),
                Author = "21Studios",
                IsLocked = false,
                Name = "Game 1",
                Price = 20.4f
            });

            Assert.IsNotNull(productRepository.Get(1));

        }

        [TestMethod]
        public void DeleteTest()
        {
            DataContext dataContext = new DataContext { Products = new List<Product>() };
            ProductRepository productRepository = new ProductRepository(dataContext);
            productRepository.Add(new Product
            {
                Id = 1,
                AllowedFromDate = new DateTime(2000, 1, 1),
                Author = "21Studios",
                IsLocked = false,
                Name = "Game 1",
                Price = 20.4f
            });
            productRepository.Delete(1);

            Assert.IsNull(productRepository.Get(1));
        }

        [TestMethod]
        public void UpdateTest()
        {
            DataContext dataContext = new DataContext { Products = new List<Product>() };
            ProductRepository productRepository = new ProductRepository(dataContext);
            productRepository.Add(new Product
            {
                Id = 1,
                AllowedFromDate = new DateTime(2000, 1, 1),
                Author = "21Studios",
                IsLocked = false,
                Name = "Game 1",
                Price = 20.4f
            });
            string newAuthor = "TSA";

            Product product2 = new Product
            {
                Id = 1,
                AllowedFromDate = new DateTime(2000, 1, 1),
                Author = newAuthor,
                IsLocked = false,
                Name = "Game 1",
                Price = 20.4f
            };
            productRepository.Update(1, product2);

            Assert.AreEqual(newAuthor, productRepository.Get(1).Author);

        }

        [TestMethod]
        public void FilterTest()
        {
            DataContext dataContext = new DataContext { Products = new List<Product>() };
            ProductRepository productRepository = new ProductRepository(dataContext);
            productRepository.Add(new Product
            {
                Id = 1,
                AllowedFromDate = new DateTime(2000, 1, 1),
                Author = "21Studios",
                IsLocked = false,
                Name = "Game 1",
                Price = 20.4f
            });


            productRepository.Add(new Product
            {
                Id = 1,
                AllowedFromDate = new DateTime(2001, 1, 1),
                Author = "Boom",
                IsLocked = false,
                Name = "Game 2",
                Price = 25.4f
            });

            List<Product> products = productRepository.Get(c => c.AllowedFromDate == new DateTime(2000, 1, 1)).ToList();
            Assert.AreEqual(1, products.Count());
        }
    }
}
