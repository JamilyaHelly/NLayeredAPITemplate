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
    public class OrderController:ControllerBase
    {
        public readonly IOrderService _orderService;
        public readonly IMapper _mapper;

        public OrderController(IOrderService orderService,IMapper mapper)
        {
            _mapper=mapper;
            _orderService=orderService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var orderById = await _orderService.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderDto>(orderById));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(_mapper.Map<OrderDto>(orders));
        }
        [HttpGet("{id}/orderitem")]
        public async Task<IActionResult> GetWithProductById(int id)
        {

            var orderitemtId = await _orderService.GetWithOrderItemByIdAsync(id);

            return Ok(_mapper.Map<OrderWithOrderItemDto>(orderitemtId));
        }

        [HttpPost]
        public async Task<IActionResult> Save(OrderDto orderDto)
        {
            var orderSave = await _orderService.AddAsync(_mapper.Map<Order>(orderDto));
            return Created(string.Empty, _mapper.Map<OrderDto>(orderSave));
        }
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<Order> orderDto)
        {

            var orderRange = await _orderService.AddRangeAsync(_mapper.Map<IEnumerable<Order>>(orderDto));
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orderRange));
        }

        [HttpPut]
        public IActionResult Update(OrderDto orderDto)
        {
            var orderupdate = _orderService.Update(_mapper.Map<Order>(orderDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var orderRemove = _orderService.GetByIdAsync(id).Result;
            _orderService.Remove(orderRemove);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var orderGetRange = _orderService.Where(x => ids.Contains(x.Id)).Result;
            _orderService.RemoveRange(orderGetRange);
            return NoContent();
        }




    }
}

        
 