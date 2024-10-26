using Application.Dtos;
using Application.Interfaces;
using Common.Dto;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DiscountServices.Command
{
    public class AddDiscountService
    {
        private readonly IDataBaseContext _context;

        public AddDiscountService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(DiscountDto Dto) 
        {
            var entity = Dto.Adapt<Discount>();
            await _context.Discount.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new ResultDto() 
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
