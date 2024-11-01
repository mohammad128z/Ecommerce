﻿using Application.Dtos;
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
            bool SalesLineId = await _context.SalesLine.AnyAsync(e => e.Id == Dto.SalesLineId);
            bool CustomerId = await _context.Customer.AnyAsync(e => e.Id == Dto.CustomerId);
            bool SellerId = await _context.Seller.AnyAsync(e => e.Id == Dto.SellerId);

            if (!SalesLineId || !CustomerId || !SellerId)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "اطلاعات وارد شده صحیح نمیباشد"
                };
            }

            //var entity = Dto.Adapt<PreInvoiceHeader>();
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
            await _context.SaveChangesAsync();
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
