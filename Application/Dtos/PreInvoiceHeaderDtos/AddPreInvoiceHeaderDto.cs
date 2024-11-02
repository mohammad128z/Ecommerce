using Application.CustomeAttributes;
using Application.Dtos.DetailPreInvoiceDtos;
using Application.Dtos.SalesLineDtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dtos.PreInvoiceHeaderDtos
{
    public class AddPreInvoiceHeaderDto
    {               
        [ExistsInDatabase<SalesLine>]
        public int SalesLineId { get; set; }        
        [ExistsInDatabase<Customer>]
        public int CustomerId { get; set; }        
        [ExistsInDatabase<Seller>]
        public int SellerId { get; set; }
    }
}
