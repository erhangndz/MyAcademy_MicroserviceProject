using ECommerce.Catalog.DTOs.CategoryDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Repositories.CategoryRepositories;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CategoriesController(ICategoryRepository _categoryRepository) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories.Adapt<List<ResultCategoryDto>>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            var category = categoryDto.Adapt<Category>();
            await _categoryRepository.CreateAsync(category);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category is null)
            {
                return BadRequest("Category Not Found");
            }

            return Ok(category.Adapt<ResultCategoryDto>());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {

            var category = await _categoryRepository.GetByIdAsync(categoryDto.Id);
            if (category is null)
            {
                return BadRequest("Category Not Found");
            }
            category = categoryDto.Adapt<Category>();
            await _categoryRepository.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if(category is null)
            {
                return BadRequest("Category Not Found");
            }

            await _categoryRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
