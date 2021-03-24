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
    public class CityController : ControllerBase
    {
        public readonly ICityService _cityService;
        public readonly IMapper _mapper;
        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cityAll = await _cityService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CityDto>>(cityAll));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cityById = await _cityService.GetByIdAsync(id);
            return Ok(_mapper.Map<CityDto>(cityById));
        }

        
        [HttpPost]
        public async Task<IActionResult> Save(CityDto cityDto)
        {
            var citySave = await _cityService.AddAsync(_mapper.Map<City>(cityDto));
            return Created(string.Empty, _mapper.Map<CityDto>(citySave));

        }
        
        
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<CityDto> cityDtos)
        {

            var cityRange = await _cityService.AddRangeAsync(_mapper.Map<IEnumerable<City>>(cityDtos));
            return Ok(_mapper.Map<IEnumerable<CityDto>>(cityRange));

        }

        [HttpPut]
        public IActionResult Update(CityDto cityDto)
        {
            var cityUpdate = _cityService.Update(_mapper.Map<City>(cityDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            var cityRemove = _cityService.GetByIdAsync(id).Result;
            _cityService.Remove(cityRemove);
            return NoContent();

        }

        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var cityRange = _cityService.Where(x => ids.Contains(x.Id)).Result;
            _cityService.RemoveRange(cityRange);
            return NoContent();
        }

    }
}