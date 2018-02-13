using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 
/// </summary>
namespace SwaggerDemo.Controllers
{
    /// <summary>
    /// Products Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        public ProductsController()
        {
            if (_products == null)
            {
                _products = new List<Product> {
                { new Product{ ProductId = 1, Name = "iPhone X, Space Grey, 64 GB", Price = 999 }},
                { new Product{ ProductId = 2, Name = "iPhone 8 Plus, Gold, 64 GB", Price = 798 }}};
            }
        }

        /// <summary>
        /// Gets all the products available.
        /// </summary>
        /// <returns>An array of products.</returns>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        /// <summary>
        /// Gets the Product by Product ID.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <returns>Product</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!_products.Any(p => p.ProductId == id))
            {
                return NotFound();
            }
            return Ok(_products.Where(p => p.ProductId == id).First());
        }


        /// <summary>
        /// Create a product.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="productName">Name of the product.</param>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        [HttpPost("{id}/{productName}/{price}")]
        public IActionResult Post(int id, string productName, double price)
        {
            _products.Add(new Product { ProductId = id, Name = productName, Price = price });
            return Ok();
        }

        /// <summary>
        /// Update product.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="productName">Name of the product.</param>
        /// <param name="price">The price.</param>
        /// <returns>Updated Product</returns>
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


        /// <summary>
        /// Deletes the specified Product.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _products.Remove(_products.Where(p => p.ProductId == id).First());
            return Ok();
        }
    }
}