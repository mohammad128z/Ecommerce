
using Application.Dtos.DetailPreInvoiceDtos;
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

namespace Application.Services.DetailPreInvoiceServices.Queries
{
    public class GetDetailPreInvoiceService
    {
        private readonly IDataBaseContext _context;

        public GetDetailPreInvoiceService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(int Id)
        {
            var entity = await _context.DetailPreInvoice.ProjectToType<GetDetailPreInvoiceDto>()
                .FirstOrDefaultAsync(e => e.Id == Id);

            if (entity == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "شناسه وارد شده معتبر نمیباشد"
                };
            }
            return new ResultDto<GetDetailPreInvoiceDto>()
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد",
                Data = entity
            };
        }
    }

}
