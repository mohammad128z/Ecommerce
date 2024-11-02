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
    public class AddPreInvoiceHeaderService
    {
        private readonly IDataBaseContext _context;

        public AddPreInvoiceHeaderService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(AddPreInvoiceHeaderDto Dto)
        {                        
            var NewPreInvoiceHeader = new PreInvoiceHeader
            {
                CustomerId = Dto.CustomerId,
            };

            var NewSalesLineInSeller = new SalesLineInSeller
            {
                PreInvoiceHeader = NewPreInvoiceHeader,
                SalesLineId = Dto.SalesLineId,
                SellerId = Dto.SellerId,
            };

            await _context.PreInvoiceHeader.AddAsync(NewPreInvoiceHeader);            
            await _context.SalesLineInSeller.AddAsync(NewSalesLineInSeller);
            await _context.SaveChangesAsync();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }
}
