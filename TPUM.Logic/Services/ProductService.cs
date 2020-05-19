using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPUM.Data;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;
using TPUM.Data.Repositiories;
using TPUM.Logic.DTOs;

namespace TPUM.Logic.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository(DbContext.Instance);
        }

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            Product product = _productRepository.Get(id);
            return Mappings.MapProduct(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            DbContext.Instance.ToString();
            IEnumerable<Product> products = _productRepository.Get();

            return products.Select(c => Mappings.MapProduct(c)).ToList();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsFromAge(int age)
        {
            IEnumerable<Product> products = _productRepository.Get(c => c.AllowedFromDate.Year >= DateTime.Now.Year - age);

            return products.Select(c => Mappings.MapProduct(c)).ToList();
        }
    }
}
