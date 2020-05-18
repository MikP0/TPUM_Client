using System;
using System.Collections.Generic;
using System.Linq;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;

namespace TPUM.Data.Repositiories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly DataContext _dataContext;
        private readonly object m_SyncObject = new object();

        public ProductRepository()
        {
            _dataContext = DbContext.Instance;
        }

        public ProductRepository(DataContext dbContext)
        {
            _dataContext = dbContext;
        }

        public Product Add(Product entity)
        {
            _dataContext.Products.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Product product = _dataContext.Products.FirstOrDefault(c => c.Id == id);
            _dataContext.Products.Remove(product);
        }

        public IEnumerable<Product> Get()
        {
            return _dataContext.Products;
        }

        public Product Get(int id)
        {
            return _dataContext.Products.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Product> Get(Func<Product, bool> filter)
        {
            return _dataContext.Products.Where(filter).ToList();
        }

        public Product Update(int id, Product entity)
        {
            lock (m_SyncObject)
            {
                Product product = _dataContext.Products.FirstOrDefault(c => c.Id == id);

                product.Author = entity.Author;
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.AllowedFromDate = entity.AllowedFromDate;
                product.IsLocked = entity.IsLocked;

                return product;
            }
        }
    }
}
