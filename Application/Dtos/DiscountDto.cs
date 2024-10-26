using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class DiscountDto
    {
        public int? DetailPreInvoiceId { get; set; }

        public int PreInvoiceHeaderId { get; set; }

        public DiscountType DiscountType { get; set; }

        public int DiscountAmount { get; set; }

    }
}
