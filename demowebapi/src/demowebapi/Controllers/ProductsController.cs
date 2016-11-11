using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using demowebapi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace demowebapi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        static List<Product> _products = new List<Product>
        {
            new Product {Id=1, Name= " Milk", Price=1.99m },
            new Product {Id=2, Name= " Cheese", Price=2.49m },
            new Product {Id=3, Name= "Lobtop ", Price=999.99m },
        };

        // api/products
        public IEnumerable<Product> Get()
        {
            return _products;

        }
        // / api/products/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _products.Find(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
        // /api/products
        [HttpPost]
        public IActionResult Post ([FromBody]Product product)
        {
            _products.Add(product);
            return Created("/products/" + product.Id, product);
        }
    }
}
