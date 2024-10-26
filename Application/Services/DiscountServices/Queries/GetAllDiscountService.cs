using Application.Interfaces;
using Common.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DiscountServices.Queries
{
    public class GetAllDiscountService
    {
        private readonly IDataBaseContext _context;

        public GetAllDiscountService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<IEnumerable<Discount>>> Execute()
        {
            var entitys = await _context.Discount.ToListAsync();
            return new ResultDto<IEnumerable<Discount>>() 
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد",
                Data = entitys
            };
        }
    }
}
