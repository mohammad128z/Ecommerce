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
    public class GetAllDetailPreInvoiceService
    {
        private readonly IDataBaseContext _context;

        public GetAllDetailPreInvoiceService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<IEnumerable<GetDetailPreInvoiceDto>>> Execute()
        {
            return new ResultDto<IEnumerable<GetDetailPreInvoiceDto>>()
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد",
                Data = await _context.DetailPreInvoice.ProjectToType<GetDetailPreInvoiceDto>().ToListAsync()
            };
        }
    }
}
