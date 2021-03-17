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
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController:ControllerBase
    {
         private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService,IMapper mapper)
        {
            _addressService=addressService;
            _mapper=mapper;
        }
         [HttpGet]
        public async Task<IActionResult> GetAll()
        {
               var addressGetAll = await _addressService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AddressDto>>(addressGetAll));
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var addressById = await _addressService.GetByIdAsync(id);
            return Ok(_mapper.Map<AddressDto>(addressById));
        }
         [HttpPost]
        public async Task<IActionResult> Save(AddressDto addressDto)
        {
            var addressSave = await _addressService.AddAsync(_mapper.Map<Address>(addressDto));
            return Created(string.Empty, _mapper.Map<AddressDto>(addressSave));

        }
         [HttpPost("addrange")]

        public async Task<IActionResult> AddRangeAsync(IEnumerable<AddressDto> addressDtos)
        {

            var addressRange = await _addressService.AddRangeAsync(_mapper.Map<IEnumerable<Address>>(addressDtos));
            return Ok(_mapper.Map<IEnumerable<AddressDto>>(addressRange));

        }
         [HttpPut]
        public IActionResult Update(AddressDto addressDto)
        {            
            var addressUpdate = _addressService.Update(_mapper.Map<Address>(addressDto));
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            var addressRemove = _addressService.GetByIdAsync(id).Result;
           _addressService.Remove(addressRemove);

            return NoContent();

        }
        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var addressRange = _addressService.Where(x => ids.Contains(x.Id)).Result;
            _addressService.RemoveRange(addressRange);
            return NoContent();
        }

    }
}