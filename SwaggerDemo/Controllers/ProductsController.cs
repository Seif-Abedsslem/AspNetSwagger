using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace SwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> _products;

        public ProductsController()
        {
            if (_products == null)
            {
                _products = new List<Product> {
                { new Product{ ProductId = 1, Name = "iPhone X, Space Grey, 64 GB", Price = 999 }},
                { new Product{ ProductId = 2, Name = "iPhone 8 Plus, Gold, 64 GB", Price = 798 }}};
            }
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!_products.Any(p => p.ProductId == id))
            {
                return NotFound();
            }
            return Ok(_products.Where(p => p.ProductId == id).First());
        }

        [HttpPost("{id}/{productName}/{price}")]
        public IActionResult Post(int id, string productName, double price)
        {
            _products.Add(new Product { ProductId = id, Name = productName, Price = price });
            return Ok();
        }

        [HttpPut("{id}/{productName}/{price}")]
        public IActionResult Put(int id, string productName, double price)
        {
            if (!_products.Any(p => p.ProductId == id))
                return NotFound();
            var prod = _products.Where(p => p.ProductId == id).First();

            prod.Name = productName;
            prod.Price = price;
            return Ok(prod);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _products.Remove(_products.Where(p => p.ProductId == id).First());
            return Ok();
        }
    }
}