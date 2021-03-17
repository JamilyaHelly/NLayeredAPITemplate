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
    public class UserController :ControllerBase
    {
        public readonly IUserService _userService;
        public readonly IMapper _mapper;
        public UserController( IUserService userService,IMapper mapper)
        {
            _userService=userService;
            _mapper=mapper;
        }
         [HttpGet]
        public async Task<IActionResult> GetAll()
        {
               var userGetAll = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userGetAll));
        }
         [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userById = await _userService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserDto>(userById));
        }
         [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var userSave = await _userService.AddAsync(_mapper.Map<User>(userDto));
            return Created(string.Empty, _mapper.Map<UserDto>(userSave));

        }
         [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<UserDto> userDtos)
        {
            var userRange = await _userService.AddRangeAsync(_mapper.Map<IEnumerable<User>>(userDtos));
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userRange));
        }

         [HttpPut]
        public IActionResult Update(UserDto userDto)
        {            
            var userUpdate = _userService.Update(_mapper.Map<User>(userDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var userRemove = _userService.GetByIdAsync(id).Result;
           _userService.Remove(userRemove);
            return NoContent();

        }
        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var userRange = _userService.Where(x => ids.Contains(x.Id)).Result;
            _userService.RemoveRange(userRange);
            return NoContent();
        }


        
    }
}