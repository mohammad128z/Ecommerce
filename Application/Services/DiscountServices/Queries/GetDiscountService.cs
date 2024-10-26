
using Application.Interfaces;
using Common.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GetDiscountServices.Queries
{
    public class GetDiscountService
    {


        private readonly IDataBaseContext _context;

        public GetDiscountService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int Id)
        {
            var entity = await _context.DetailPreInvoice.FindAsync(Id);
            if (entity == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "شناسه وارد شده معتبر نمیباشد"
                };
            }
            return new ResultDto<DetailPreInvoice>()
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد",
                Data = entity
            };
        }
    }

}
