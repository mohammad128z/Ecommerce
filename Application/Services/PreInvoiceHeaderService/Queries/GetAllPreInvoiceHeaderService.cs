using Application.Interfaces;
using Common.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PreInvoiceHeaderServices.Queries
{
    public class GetAllPreInvoiceHeaderService
    {
        private readonly IDataBaseContext _context;

        public GetAllPreInvoiceHeaderService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto<IEnumerable<PreInvoiceHeader>>> Execute()
        {
            var entitys = await _context.PreInvoiceHeader.ToListAsync();
            return new ResultDto<IEnumerable<PreInvoiceHeader>>() 
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد",
                Data = entitys
            };
        }
    }
}
