using Application.Dtos.DiscountDtos;
using Application.Interfaces;
using Common.Dto;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ResultDto> Execute(AddDiscountDto Dto, int DiscountId)
        {
            var Discount = await _context.Discount.Include(e => e.PreInvoiceHeader)
                .FirstOrDefaultAsync(e => e.Id == DiscountId);

            if (Discount == null)            
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "شناسه وارد شده صحیح نمیباشد"
                };
                
            if(Discount.PreInvoiceHeader.State == StateType.Final)            
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "اجازه ی تغییر در اطلاعات مرتبط با فاکتور نهایی شده وجود ندارد"
                };
            
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
