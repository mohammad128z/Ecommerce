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
using Microsoft.EntityFrameworkCore;

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
            var InvoiceHeader = await _context.PreInvoiceHeader.FindAsync(Dto.PreInvoiceHeaderId);

            if (InvoiceHeader == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "شناسه هدر پیش فاکتور وارد شده وجود ندارد"
                };
            }

            if (!InvoiceHeader.SalesLineInSeller.SalesLine.SalesLineInProducts.Any(e => e.ProductId == Dto.ProductId))
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصولی با این شناسه در لاین ثبت شده در هدر پیش فاکتور وجود ندارد"
                };
            }

            if (await _context.DetailPreInvoice.AnyAsync(dpi => dpi.ProductId != Dto.ProductId))
            {
                var NewDetailPreInvoice = Dto.Adapt<DetailPreInvoice>();

                await _context.DetailPreInvoice.AddAsync(NewDetailPreInvoice);
                await _context.SaveChangesAsync();

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "عملیات با موفقیت انجام شد"
                };
            }

            return new ResultDto
            {
                IsSuccess = true,
                Message = "شناسه محصول تکراری است"
            };
        }
    }
}