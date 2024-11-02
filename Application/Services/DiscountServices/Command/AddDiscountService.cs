using Application.Dtos.DiscountDtos;
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

namespace Application.Services.DiscountServices.Command
{
    public class AddDiscountService
    {
        private readonly IDataBaseContext _context;

        public AddDiscountService(IDataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(AddDiscountDto Dto)
        {
            if (Dto.DiscountType == DiscountType.Row && Dto.DetailPreInvoiceId == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "در حالت نوع تخفیف ردیفی شناسه جزعیات پیش فاکتور اجباری میباشد"
                };
            }
            if (Dto.DiscountType == DiscountType.Document && Dto.DetailPreInvoiceId != null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "در حالت نوع تخفیف سندی نمیتوان جزعیات پیش فاکتور ثبت کرد"
                };
            };

            if (!await IsValidDiscountAmount(Dto.DiscountAmount, Dto.DetailPreInvoiceId))
            {
                return new ResultDto 
                {
                    IsSuccess = false,
                    Message = "مبلغ تخفیف نمیتواند بیشتر از مبلغ پیش فاکتور باشد"
                };
            }

            var InvoiceDetail = await _context.DetailPreInvoice.FindAsync(Dto.DetailPreInvoiceId);
            var InvoiceHeader = await _context.PreInvoiceHeader.FindAsync(Dto.PreInvoiceHeaderId);

            if (InvoiceDetail != null && InvoiceHeader != null)
            {
                var entity = Dto.Adapt<Discount>();
                await _context.Discount.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "عملیات با موفقیت انجام شد"
                };
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "شناسه وارد شده صحیح نمیباشد"
            };
        }
        private async Task<bool> IsValidDiscountAmount(int DiscountAmount, int? InvoiceDetailId)
        {
            var InvoiceDetail = await _context.DetailPreInvoice
                .Include(e => e.Discounts)
                .FirstOrDefaultAsync(e => e.Id == InvoiceDetailId);

            return InvoiceDetail?.Discounts.Sum(e => e.DiscountAmount) <= DiscountAmount;
        }
    }
}