using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class PreInvoiceHeaderDto
    {
        public StateType State { get; set; }

        public int SalesLineId { get; set; }

        public int CustomerId { get; set; }

        public int SellerId { get; set; }
    }
}
