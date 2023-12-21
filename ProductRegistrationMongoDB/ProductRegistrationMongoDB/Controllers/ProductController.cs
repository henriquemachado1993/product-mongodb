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

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var produto = await _productService.GetByIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductRequestModel product)
        {
            // TODO: colocar automapper.
            await _productService.CreateAsync(new Product()
            {
                Name = product.Name,
                Categories = product.Categories,
                Price = product.Price
            });


            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductRequestModel product)
        {
            if (await _productService.GetByIdAsync(product.Id) == null)
            {
                return NotFound();
            }

            // TODO: colocar automapper.
            return Ok(await _productService.UpdateAsync(new Product()
            {
                Id = ObjectId.Parse(product.Id),
                Name = product.Name,
                Categories = product.Categories,
                Price = product.Price
            }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var produto = await _productService.GetByIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);

            return NoContent();
        }

    }
}
