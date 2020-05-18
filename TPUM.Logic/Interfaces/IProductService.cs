using System.Collections.Generic;
using TPUM.Logic.DTOs;

namespace TPUM.Logic.Interfaces
{
    interface IProductService
    {
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProductsByMinAge(int age);
    }
}
