using Application.CustomeAttributes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.PreInvoiceHeaderDtos
{
    public class UpdatePreInvoiceHeaderDto
    {
        [EnumDataType(typeof(StateType))]
        public StateType State { get; set; }
        [ExistsInDatabase<SalesLine>]
        public int SalesLineId { get; set; }
        [ExistsInDatabase<Customer>]
        public int CustomerId { get; set; }
        [ExistsInDatabase<Seller>]
        public int SellerId { get; set; }
    }
}
