using ECommerce.Catalog.DTOs.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Repositories.ProductRepositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository _productRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();        
            return Ok(products.Adapt<List<ResultProductDto>>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {  
            var product = productDto.Adapt<Product>();
            await _productRepository.CreateAsync(product);
            return Created();
           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                return BadRequest("Product Not Found");
            }
            return Ok(product.Adapt<ResultProductDto>());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(productDto.Id);
            if (product == null)
            {
                return BadRequest("Product Not Found");
            }

            productDto.Adapt(product);
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return BadRequest("Product Not Found");
            }

            await _productRepository.DeleteAsync(id);
            return NoContent();

        }

    }
}
