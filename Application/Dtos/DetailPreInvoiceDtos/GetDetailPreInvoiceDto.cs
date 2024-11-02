using Application.Dtos.ProductDtos;
using Application.Dtos.SalesLineDtos;
using Application.Dtos.SellerDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dtos.DetailPreInvoiceDtos
{
    public class GetDetailPreInvoiceDto
    {
        public int Id { get; set; }
        public GetProductDto Product { get; set; }
        public GetPreInvoiceHeaderInDetailDto PreInvoiceHeader { get; set; }
        public int Count { get; set; }        
        public int Price { get; set; }
    }
    public class GetPreInvoiceHeaderInDetailDto
    {
        public StateType State { get; set; }
        public Customer Customer { get; set; }        
    }
}
