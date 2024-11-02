using Application.Dtos.DetailPreInvoiceDtos;
using Application.Dtos.SalesLineDtos;
using Application.Dtos.SellerDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dtos.PreInvoiceHeaderDtos
{
    public class GetListPreInvoiceHeaderDto
    {
        public int Id { get; set; }
        public StateType State { get; set; }
        public Customer Customer { get; set; }
        
        [JsonPropertyName("SalesLine")]
        public GetSalesLineDto SalesLineInSellerSalesLine { get; set; }
        
        [JsonPropertyName("Seller")]
        public GetSellerDto SalesLineInSellerSeller { get; set; }
        public GetDetailPreInvoiceDto DetailPreInvoice { get; set; }        
    }
}
