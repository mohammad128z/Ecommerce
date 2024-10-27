using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Contexts.EF_Core;
using Application.Services.DetailPreInvoiceServices.Command;
using Application.Dtos;
using Common.Dto;
using Application.Services.DetailPreInvoiceServices.Queries;
using Application.Services.PreInvoiceHeaderServices.Queries;

namespace EndPoint.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailPreInvoicesController : ControllerBase
    {
        private readonly DataBaseContext _context;
        private readonly AddDetailPreInvoiceService _addDetailPreInvoiceService;
        private readonly DeleteDetailPreInvoiceService _deleteDetailPreInvoiceService;
        private readonly UpdateDetailPreInvoiceService _updateDetailPreInvoiceService;
        private readonly GetDetailPreInvoiceService _getDetailPreInvoiceService;
        private readonly GetAllDetailPreInvoiceService _getAllDetailPreInvoiceService;


        public DetailPreInvoicesController(DataBaseContext context, AddDetailPreInvoiceService addDetailPreInvoiceService, DeleteDetailPreInvoiceService deleteDetailPreInvoiceService, UpdateDetailPreInvoiceService updateDetailPreInvoiceService, GetDetailPreInvoiceService getDetailPreInvoiceService, GetAllDetailPreInvoiceService getAllDetailPreInvoiceService)
        {
            _context = context;
            _addDetailPreInvoiceService = addDetailPreInvoiceService;
            _deleteDetailPreInvoiceService = deleteDetailPreInvoiceService;
            _updateDetailPreInvoiceService = updateDetailPreInvoiceService;
            _getDetailPreInvoiceService = getDetailPreInvoiceService;
            _getAllDetailPreInvoiceService = getAllDetailPreInvoiceService;
        }

        // GET: api/DetailPreInvoices
        [HttpGet]
        public async Task<ActionResult<ResultDto>> GetDetailPreInvoice()
        {
            var ServiceResult = await _getAllDetailPreInvoiceService.Execute();
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // GET: api/DetailPreInvoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultDto>> GetDetailPreInvoice(int id)
        {
            var ServiceResult = await _getDetailPreInvoiceService.Execute(id);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // PUT: api/DetailPreInvoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ResultDto>> PutDetailPreInvoice(int id, DetailPreInvoiceDto Dto)
        {
            var ServiceResult = await _updateDetailPreInvoiceService.Execute(Dto, id);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // POST: api/DetailPreInvoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResultDto>> PostDetailPreInvoice(DetailPreInvoiceDto Dto)
        {
            var ServiceResult = await _addDetailPreInvoiceService.Execute(Dto);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // DELETE: api/DetailPreInvoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultDto>> DeleteDetailPreInvoice(int id)
        {
            var ServiceResult = await _deleteDetailPreInvoiceService.Execute(id);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }
    }
}
