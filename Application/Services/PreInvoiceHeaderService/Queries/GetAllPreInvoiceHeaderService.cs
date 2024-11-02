using Application.Dtos.PreInvoiceHeaderDtos;
using Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Domain.Entities;
using Mapster;
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

        public async Task<ResultDto<IEnumerable<GetListPreInvoiceHeaderDto>>> Execute()
        {
            var Headers = await _context.PreInvoiceHeader
                .ProjectToType<GetListPreInvoiceHeaderDto>()
                .ToListAsync();
            
            return new ResultDto<IEnumerable<GetListPreInvoiceHeaderDto>>()
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد",
                Data = Headers
            };
        }
    }
}
