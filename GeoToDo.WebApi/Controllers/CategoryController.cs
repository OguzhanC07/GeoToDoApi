using AutoMapper;
using GeoToDo.Business.Interfaces;
using GeoToDo.DTO.DTOs.CategoryDto;
using GeoToDo.Entities.Concrete;
using GeoToDo.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoToDo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByAppUserId(int id)
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetCategoryByAppUserId(id)));
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CategoryListDto>(await _categoryService.GetByIdAsync(id)));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Member")]
        [ValidModel]
        public async Task<IActionResult> AddCategory([FromForm] CategoryAddDto addCategoryDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(addCategoryDto));
            return Created("", addCategoryDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Member")]
        [ServiceFilter(typeof(ValidId<Category>))]
        [ValidModel]
        public async Task<IActionResult> UpdateCategory(int id, [FromForm] CategoryListDto categoryListDto)
        {
            if (id == categoryListDto.Id)
            {
                return BadRequest("Invalid Id");
            }
            else
            {
                var updatedCategory = await _categoryService.GetByIdAsync(id);
                updatedCategory.Id = categoryListDto.Id;
                updatedCategory.Name = categoryListDto.Name;
                await _categoryService.UpdateAsync(updatedCategory);
                return NoContent();
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin,Member")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category!=null)
            {
                category.IsVisible = false;
                await _categoryService.UpdateAsync(category);
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

    }
}
