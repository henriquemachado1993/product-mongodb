using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProductRegistrationMongoDB.Domain.Entities;
using ProductRegistrationMongoDB.Domain.Interfaces;
using ProductRegistrationMongoDB.Models;

namespace ProductRegistrationMongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductRequestModel product)
        {
            // TODO: colocar automapper.
            await _productService.CreateAsync(new Product()
            {
                Id = ObjectId.Parse(product.Id),
                Name = product.Name,
                CategoryId = ObjectId.Parse(product.CategoryId),
                Price = product.Price
            });


            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
    }
}
