using Application.Dtos.DetailPreInvoiceDtos;
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

        public async Task<ResultDto> Execute(AddDetailPreInvoiceDto Dto,int InvoiceDetailId)
        {
            var InvoiceDetail = await _context.DetailPreInvoice.FindAsync(InvoiceDetailId);
            if (InvoiceDetail == null)            
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "شناسه وارد شده صحیح نمیباشد"
                };
            
            await _context.Entry(InvoiceDetail).Reference(e => e.PreInvoiceHeader).LoadAsync();
            if (InvoiceDetail.PreInvoiceHeader.State == StateType.Final)
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "اجازه ی تغییر در اطلاعات مرتبط با فاکتور نهایی شده وجود ندارد"
                };

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
