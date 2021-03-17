using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Filters;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var categoryById = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(categoryById));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var category = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(category));
        }

        [HttpGet("{id}/product")]
        public async Task<IActionResult> GetWithProductById(int id)
        {

            var categoryProductId = await _categoryService.GetWithProductByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithProductDto>(categoryProductId));
        }


        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var categorySave = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            return Created(string.Empty, _mapper.Map<CategoryDto>(categorySave));
        }

        [ValidationFilter]
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<Category> categoryDtos)
        {

            var categoryRange = await _categoryService.AddRangeAsync(_mapper.Map<IEnumerable<Category>>(categoryDtos));
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categoryRange));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var categoryupdate = _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var categoryRemove = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(categoryRemove);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var categoryGetRange = _categoryService.Where(x => ids.Contains(x.Id)).Result;
            _categoryService.RemoveRange(categoryGetRange);
            return NoContent();
        }




    }
}