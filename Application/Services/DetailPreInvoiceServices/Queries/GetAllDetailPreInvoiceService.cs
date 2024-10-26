﻿using Application.Interfaces;
using Common.Dto;
using Domain.Entities;
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

        public async Task<ResultDto<IEnumerable<DetailPreInvoice>>> Execute()
        {
            var entitys = await _context.DetailPreInvoice.ToListAsync();
            return new ResultDto<IEnumerable<DetailPreInvoice>>() 
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد",
                Data = entitys
            };
        }
    }
}