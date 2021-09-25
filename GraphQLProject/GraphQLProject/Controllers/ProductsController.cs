using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GraphQLProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct _productService;

        public ProductsController(IProduct productService)
        {
            _productService = productService;
        }
        
        
        [HttpGet]
        public IEnumerable<Product> ListarProdutos()
        {
            return _productService.GetAllProducts();
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            return _productService.AddProduct(product);
        }
    }
}
