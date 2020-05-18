using System;
using System.Linq;
using System.Threading.Tasks;
using TPUM.Data.Model;
using TPUM.Logic.DTOs;

namespace TPUM.Logic
{
    public static class Mappings
    {
        public static ClientDTO MapClient(Client client)
        {
            ClientDTO clientDTO = new ClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                LastName = client.LastName,
                Age = DateTime.Now.Year - client.DateOfBirth.Year,
                Cart = MapCart(client.Cart)
            };

            return clientDTO;
        }

        public static ProductDTO MapProduct(Product product)
        {
            ProductDTO productDTO = new ProductDTO
            {
                Id = product.Id,
                Author = product.Author,
                Name = product.Name,
                MinimalAge = DateTime.Now.Year - product.AllowedFromDate.Year,
                Price = product.Price
            };

            return productDTO;
        }

        public static CartDTO MapCart(Cart cart)
        {
            CartDTO cartDTO = new CartDTO
            {
                Products = cart.Products.Select(MapProduct).ToList()
            };
            return cartDTO;
        }
    }
}
