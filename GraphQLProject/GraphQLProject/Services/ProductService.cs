using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLProject.Services
{
    public class ProductService : IProduct
    {
        private GraphQLDbContext _dbContext;

        public ProductService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Product.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var excluir = _dbContext.Product.FirstOrDefault(a => a.Id == id);
            if (excluir == null)
            {
                throw new Exception("Product not found");
            }
            _dbContext.Product.Remove(excluir);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Product.ToList();
        }

        public Product GetProductById(int id)
        {
            var produto = _dbContext.Product.Where(a => a.Id == id)
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
            var update = _dbContext.Product.FirstOrDefault(a => a.Id == id);
            if (update == null)
            {
                throw new Exception("Product not found");
            }
            update.Name = product.Name;
            update.Price = product.Price;
            _dbContext.Add(update);
            _dbContext.SaveChanges();
            return update;
        }
    }
}
