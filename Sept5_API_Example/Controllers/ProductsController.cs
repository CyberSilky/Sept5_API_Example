using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sept5_API_Example.Models;

namespace Sept5_API_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>()
        {

            new Product{Id = 1, ProductCategory = "Electronics", ProductName = "TV", Price = 499.99, Tax = .08}, 
            new Product{Id = 2, ProductCategory = "Grocery", ProductName = "Eggs", Price = 4.99, Tax = .05 }

        };
        // GET: api/Products
        [HttpGet]
        public List<Product> Get()
        {
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return StatusCode(404, null);
            else
                return StatusCode(200, product);

        }

        // POST: api/Products
        [HttpPost]
        public IActionResult AddProduct([FromBody] Product value)
        {
            products.Add(value);
            return StatusCode(200, products);

        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct (int id, [FromBody] Product value)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return StatusCode(400, null);
            else
            {
                products.Remove(products.FirstOrDefault(p => p.Id == id));
                products.Add(value);
                return StatusCode(200, products);
            }
                
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return StatusCode(400, null);
            else
            {
                products.Remove(products.FirstOrDefault(p => p.Id == id));
                return StatusCode(200, products);
            }
        }
    }
}
