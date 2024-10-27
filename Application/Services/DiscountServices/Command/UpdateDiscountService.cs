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
    public class UpdateDiscountService
    {
        private readonly IDataBaseContext _context;
        public UpdateDiscountService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(DiscountDto Dto, int DiscountId)
        {
            var Discount = await _context.DetailPreInvoice.FindAsync(DiscountId);
            if (Discount == null)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "شناسه وارد شده صحیح نمیباشد"
                };
            }
            Dto.Adapt(Discount);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
