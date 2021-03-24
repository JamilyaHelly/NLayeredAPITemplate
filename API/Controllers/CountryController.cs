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

    [Route("id/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public readonly ICountryService _countryService;
        public readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var countryById = await _countryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CountryDto>(countryById));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var country = await _countryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CountryDto>>(country));
        }

        [HttpGet("{id}/cities")]
        public async Task<IActionResult> GetWithCityById(int id)
        {

            var countryProductId = await _countryService.GetWithCityByIdAsync(id);

            return Ok(_mapper.Map<CountryWithCityDto>(countryProductId));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CountryDto countryDto)
        {
            var countrySave = await _countryService.AddAsync(_mapper.Map<Country>(countryDto));
            return Created(string.Empty, _mapper.Map<CountryDto>(countrySave));
        }

    
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<Country> countryDtos)
        {

            var countryRange = await _countryService.AddRangeAsync(_mapper.Map<IEnumerable<Country>>(countryDtos));
            return Ok(_mapper.Map<IEnumerable<CountryDto>>(countryDtos));
        }

        [HttpPut]
        public IActionResult Update(CountryDto countryDto)
        {
            var countryUpdate = _countryService.Update(_mapper.Map<Country>(countryDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var coutryRemove = _countryService.GetByIdAsync(id).Result;
            _countryService.Remove(coutryRemove);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var countryGetRange = _countryService.Where(x => ids.Contains(x.Id)).Result;
            _countryService.RemoveRange(countryGetRange);
            return NoContent();
        }
    }
}