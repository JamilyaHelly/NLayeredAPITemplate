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
    public class OrderItemController:ControllerBase
    {
        public readonly IOrderItemService _orderItemService;
        public readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService,IMapper mapper)
        {
            _orderItemService=orderItemService;
            _mapper=mapper;
        }


         [HttpGet]
        public async Task<IActionResult> GetAll()
        {
               var ordeItemGetAll = await _orderItemService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<OrderItemDto>>(ordeItemGetAll));
        }


         [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orderItemById = await _orderItemService.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderItemDto>(orderItemById));
        }


         [HttpPost]
        public async Task<IActionResult> Save(OrderItemDto orderItemDto)
        {
            var orderItemSave = await _orderItemService.AddAsync(_mapper.Map<OrderItem>(orderItemDto));
            return Created(string.Empty, _mapper.Map<OrderItemDto>(orderItemSave));

        }


         [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<OrderItemDto> orderItemDtos)
        {

            var ordeItemRange = await _orderItemService.AddRangeAsync(_mapper.Map<IEnumerable<OrderItem>>(orderItemDtos));
            return Ok(_mapper.Map<IEnumerable<OrderItemDto>>(ordeItemRange));

        }

         [HttpPut]
        public IActionResult Update(OrderItemDto orderItemDto)
        {            
            var ordeItemUpdate = _orderItemService.Update(_mapper.Map<OrderItem>(orderItemDto));
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {

            var orderItemRemove = _orderItemService.GetByIdAsync(id).Result;
          _orderItemService.Remove(orderItemRemove);

            return NoContent();

        }


        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var orderItemRange = _orderItemService.Where(x => ids.Contains(x.Id)).Result;
            _orderItemService.RemoveRange(orderItemRange);
            return NoContent();
        }

        
    }
}