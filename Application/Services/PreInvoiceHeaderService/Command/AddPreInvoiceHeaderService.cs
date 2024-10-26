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

namespace Application.Services.PreInvoiceHeaderServices.Command
{
    public class AddPreInvoiceHeaderService
    {
        private readonly IDataBaseContext _context;

        public AddPreInvoiceHeaderService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(PreInvoiceHeaderDto Dto)
        {
            var entity = Dto.Adapt<PreInvoiceHeader>();
            await _context.PreInvoiceHeader.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new ResultDto()
            { 
                IsSuccess = true,
            };
        }
    }
}
