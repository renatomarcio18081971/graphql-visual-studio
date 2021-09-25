using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLProject.Services
{
    public class ProductService : IProduct
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "beans", Price = 10},
            new Product { Id = 2, Name = "rice", Price = 15}
        };

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public void DeleteProduct(int id)
        {
            products.RemoveAt(id);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            var produto = products.Where(a => a.Id == id)
                                  .Select(a => new Product
                                  {
                                      Id = a.Id,
                                      Name = a.Name,
                                      Price = a.Price
                                  })
                                  .FirstOrDefault();
            return produto;
        }

        public Product UpdateProduct(int id, Product product)
        {
            products[id] = product;
            return product;
        }
    }
}
