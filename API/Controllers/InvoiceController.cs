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
    public class InvoiceController : ControllerBase
    {

        public readonly IInvoiceService _invoiceService;
        public readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoiceGetAll = await _invoiceService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoiceGetAll));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invoiceById = await _invoiceService.GetByIdAsync(id);
            return Ok(_mapper.Map<CityDto>(invoiceById));
        }
        [HttpPost]
        public async Task<IActionResult> Save(InvoiceDto invoiceDto)
        {
            var invoiceSave = await _invoiceService.AddAsync(_mapper.Map<Invoice>(invoiceDto));
            return Created(string.Empty, _mapper.Map<InvoiceDto>(invoiceSave));

        }
        [HttpPost("addrange")]
        public async Task<IActionResult> AddRangeAsync(IEnumerable<InvoiceDto> invoiceDtos)
        {
            var invoiceRange = await _invoiceService.AddRangeAsync(_mapper.Map<IEnumerable<Invoice>>(invoiceDtos));
            return Ok(_mapper.Map<IEnumerable<InvoiceDto>>(invoiceRange));
        }

        [HttpPut]
        public IActionResult Update(InvoiceDto invoiceDto)
        {
            var invoiceUpdate = _invoiceService.Update(_mapper.Map<Invoice>(invoiceDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var invoiceRemove = _invoiceService.GetByIdAsync(id).Result;
            _invoiceService.Remove(invoiceRemove);
            return NoContent();

        }
        [HttpDelete]
        public IActionResult RemoveRange(IEnumerable<int> ids)
        {
            var invoiceRange = _invoiceService.Where(x => ids.Contains(x.Id)).Result;
            _invoiceService.RemoveRange(invoiceRange);
            return NoContent();
        }

    }
}