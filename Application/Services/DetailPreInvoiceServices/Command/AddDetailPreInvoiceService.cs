using Application.Dtos;
using Domain.Entities;
using Application.Interfaces;
using Common.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DetailPreInvoiceServices.Command
{
    public class AddDetailPreInvoiceService
    {
        private readonly IDataBaseContext _context;

        public AddDetailPreInvoiceService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(DetailPreInvoiceDto Dto)
        {
            var entity = Dto.Adapt<DetailPreInvoice>();
            
            await _context.DetailPreInvoice.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
