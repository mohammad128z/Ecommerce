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

namespace Application.Services.DetailPreInvoiceServices.Command
{
    public class UpdateDetailPreInvoiceService
    {
        private readonly IDataBaseContext _context;
        public UpdateDetailPreInvoiceService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(DetailPreInvoiceDto Dto,int InvoiceDetailId)
        {
            var InvoiceDetail = await _context.DetailPreInvoice.FindAsync(InvoiceDetailId);
            if (InvoiceDetail == null)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "شناسه وارد شده صحیح نمیباشد"
                };
            }
            Dto.Adapt(InvoiceDetail);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
