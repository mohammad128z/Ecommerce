using Domain.Entities;
using Application.Interfaces;
using Common.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Dtos.DetailPreInvoiceDtos;

namespace Application.Services.DetailPreInvoiceServices.Command
{
    public class AddDetailPreInvoiceService
    {
        private readonly IDataBaseContext _context;

        public AddDetailPreInvoiceService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(AddDetailPreInvoiceDto Dto)
        {
            var IncludedInvoiceHeader = await _context.PreInvoiceHeader
                .Include(e => e.DetailPreInvoice).Include(e => e.SalesLineInSeller)
                .ThenInclude(e => e.SalesLine).ThenInclude(e => e.SalesLineInProducts)
                .FirstOrDefaultAsync(e => e.Id == Dto.PreInvoiceHeaderId);

            if (IncludedInvoiceHeader != null && IncludedInvoiceHeader.DetailPreInvoice != null)            
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "جزعیات پیش فاکترو قبلا برای این پیش فاکتور ثبت شده است"
                };            

            if(await _context.DetailPreInvoice.AnyAsync(e => e.ProductId == Dto.ProductId))
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "امکان ثبت محصول تکراری وجود ندارد"
                };

            if (IncludedInvoiceHeader != null && IncludedInvoiceHeader.SalesLineInSeller.SalesLine
                .SalesLineInProducts.Any(e => e.ProductId == Dto.ProductId))
            {
                var NewDetailInvoice = Dto.Adapt<DetailPreInvoice>();
                await _context.DetailPreInvoice.AddAsync(NewDetailInvoice);
                await _context.SaveChangesAsync();

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "عملیات با موفقیت انجام شد"
                };
            }
            return new ResultDto
            {
                IsSuccess = false,
                Message = "محصولی با این شناسه در لاین ثبت شده در هدر پیش فاکتور وجود ندارد"
            };
        }
    }
}