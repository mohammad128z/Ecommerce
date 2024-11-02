using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Contexts.EF_Core;
using Application.Services.PreInvoiceHeaderServices.Command;
using Common.Dto;
using Application.Services.PreInvoiceHeaderServices.Queries;
using Humanizer;
using Application.Dtos.PreInvoiceHeaderDtos;

namespace EndPoint.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreInvoiceHeadersController : ControllerBase
    {
        private readonly DataBaseContext _context;
        private readonly AddPreInvoiceHeaderService _addPreInvoiceHeaderService;
        private readonly DeletePreInvoiceHeaderService _deletePreInvoiceHeaderService;
        private readonly UpdatePreInvoiceHeaderService _updatePreInvoiceHeaderService;
        private readonly GetPreInvoiceHeaderService _getPreInvoiceHeaderService;
        private readonly GetAllPreInvoiceHeaderService _getAllPreInvoiceHeaderService;

        public PreInvoiceHeadersController(DataBaseContext context, AddPreInvoiceHeaderService addPreInvoiceHeaderService, DeletePreInvoiceHeaderService deletePreInvoiceHeaderService, UpdatePreInvoiceHeaderService updatePreInvoiceHeaderService, GetPreInvoiceHeaderService getPreInvoiceHeaderService, GetAllPreInvoiceHeaderService getAllPreInvoiceHeaderService)
        {
            _context = context;
            _addPreInvoiceHeaderService = addPreInvoiceHeaderService;
            _deletePreInvoiceHeaderService = deletePreInvoiceHeaderService;
            _updatePreInvoiceHeaderService = updatePreInvoiceHeaderService;
            _getPreInvoiceHeaderService = getPreInvoiceHeaderService;
            _getAllPreInvoiceHeaderService = getAllPreInvoiceHeaderService;
        }

        // GET: api/PreInvoiceHeaders
        [HttpGet]
        public async Task<ActionResult<ResultDto>> GetPreInvoiceHeader()
        {
            return await _getAllPreInvoiceHeaderService.Execute();
        }

        // GET: api/PreInvoiceHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultDto>> GetPreInvoiceHeader(int id)
        {
            var ServiceResult = await _getPreInvoiceHeaderService.Execute(id);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // PUT: api/PreInvoiceHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ResultDto>> PutPreInvoiceHeader(int id, UpdatePreInvoiceHeaderDto Dto)
        {
            var ServiceResult = await _updatePreInvoiceHeaderService.Execute(Dto, id);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // POST: api/PreInvoiceHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResultDto>> PostPreInvoiceHeader(AddPreInvoiceHeaderDto Dto)
        {
            var ServiceResult = await _addPreInvoiceHeaderService.Execute(Dto);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // DELETE: api/PreInvoiceHeaders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultDto>> DeletePreInvoiceHeader(int id)
        {
            var ServiceResult = await _deletePreInvoiceHeaderService.Execute(id);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }
    }
}
