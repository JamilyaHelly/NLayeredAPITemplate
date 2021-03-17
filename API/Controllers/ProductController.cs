using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("id/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        public readonly IProductService _productService;
        public readonly IMapper _mapper;
        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService=productService;
            _mapper=mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var productById = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(productById));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var product = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(product));
        }
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithProductById(int id)
        {

            var productCategoryId = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(productCategoryId));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var productSave = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created(string.Empty, _mapper.Map<ProductDto>(productSave));
        }
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<Product> productDtos)
        {

            var productRange = await _productService.AddRangeAsync(_mapper.Map<IEnumerable<Product>>(productDtos));
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(productRange));
        }

        [HttpPut]
        public IActionResult Update( ProductDto productDto)
        {
            var productupdate =_productService.Update(_mapper.Map<Product>(productDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var productRemove = _productService.GetByIdAsync(id).Result;
           _productService.Remove(productRemove);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var productGetRange = _productService.Where(x => ids.Contains(x.Id)).Result;
           _productService.RemoveRange(productGetRange);
            return NoContent();
        }
    }
}