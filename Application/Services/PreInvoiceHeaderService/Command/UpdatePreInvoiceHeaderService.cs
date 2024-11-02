using Application.Dtos.PreInvoiceHeaderDtos;
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

namespace Application.Services.PreInvoiceHeaderServices.Command
{
    public class UpdatePreInvoiceHeaderService
    {
        private readonly IDataBaseContext _context;
        public UpdatePreInvoiceHeaderService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(UpdatePreInvoiceHeaderDto Dto, int InvoiceHeaderId)
        {
            var InvoiceHeader = await _context.PreInvoiceHeader.Include(e => e.SalesLineInSeller)
                .FirstOrDefaultAsync(e => e.Id == InvoiceHeaderId);
            if (InvoiceHeader == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "شناسه وارد شده صحیح نمیباشد"
                };
            }
            if (InvoiceHeader.State == StateType.Final)
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "اجازه ی تغییر در اطلاعات مرتبط با فاکتور نهایی شده وجود ندارد"
                };

            InvoiceHeader.State = Dto.State;
            InvoiceHeader.CustomerId = Dto.CustomerId;
            InvoiceHeader.SalesLineInSeller.SalesLineId = Dto.SalesLineId;
            InvoiceHeader.SalesLineInSeller.SellerId = Dto.SellerId;            
            
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
