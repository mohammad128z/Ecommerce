using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Contexts.EF_Core;
using Application.Services.DiscountServices.Command;
using Application.Services.PreInvoiceHeaderServices.Queries;
using Application.Services.DiscountServices.Queries;
using Common.Dto;
using Application.Dtos.DiscountDtos;


namespace EndPoint.Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly DataBaseContext _context;
        private readonly AddDiscountService _addDiscountService;
        private readonly DeleteDiscountService _deleteDiscountService;
        private readonly UpdateDiscountService _updateDiscountService;
        private readonly GetDiscountService _getDiscountService;
        private readonly GetAllDiscountService _getAllDiscountService;

        public DiscountsController(DataBaseContext context, AddDiscountService addDiscountService, DeleteDiscountService deleteDiscountService, UpdateDiscountService updateDiscountService, GetDiscountService getDiscountService, GetAllDiscountService getAllDiscountService)
        {
            _context = context;
            _addDiscountService = addDiscountService;
            _deleteDiscountService = deleteDiscountService;
            _updateDiscountService = updateDiscountService;
            _getDiscountService = getDiscountService;
            _getAllDiscountService = getAllDiscountService;
        }

        // GET: api/Discounts
        [HttpGet]
        public async Task<ActionResult<ResultDto>> GetDiscount()
        {
            return await _getAllDiscountService.Execute();
        }

        // GET: api/Discounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> GetDiscount(int id)
        {
            var ServiceResult = await _getDiscountService.Execute(id);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // PUT: api/Discounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ResultDto>> PutDiscount(int id, AddDiscountDto Dto)
        {
            var ServiceResult = await _updateDiscountService.Execute(Dto, id);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }

        // POST: api/Discounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discount>> PostDiscount(AddDiscountDto Dto)
        {
            var ServiceResult = await _addDiscountService.Execute(Dto);
            if (ServiceResult.IsSuccess)
            {
                return Ok(ServiceResult);
            }
            return BadRequest(ServiceResult);
        }
    }
}
