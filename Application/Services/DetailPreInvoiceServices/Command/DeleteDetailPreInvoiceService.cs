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
    public class DeleteDetailPreInvoiceService
    {
        private readonly IDataBaseContext _context;

        public DeleteDetailPreInvoiceService(IDataBaseContext context)
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
                    Message = "شناسه معتبر نمیباشد"
                };
            }

            _context.DetailPreInvoice.Remove(entity);
            await _context.SaveChangesAsync();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
