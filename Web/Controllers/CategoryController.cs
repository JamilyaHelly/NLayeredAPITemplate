using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
             _categoryService=categoryService;
             _mapper=mapper;
        }
        public  async Task<IActionResult> Index()
        {
            var categories =await _categoryService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<Category>>(categories));
        }
    }
}