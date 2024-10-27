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

namespace Application.Services.PreInvoiceHeaderServices.Command
{
    public class UpdatePreInvoiceHeaderService
    {
        private readonly IDataBaseContext _context;
        public UpdatePreInvoiceHeaderService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(PreInvoiceHeaderDto Dto, int InvoiceHeaderId)
        {
            var InvoiceHeader = await _context.DetailPreInvoice.FindAsync(InvoiceHeaderId);
            if (InvoiceHeader == null)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "شناسه وارد شده صحیح نمیباشد"
                };
            }
            Dto.Adapt(InvoiceHeader);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
