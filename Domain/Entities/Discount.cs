using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        public int? DetailPreInvoiceId{ get; set; }
        public DetailPreInvoice DetailPreInvoice { get; set; }

        public PreInvoiceHeader PreInvoiceHeader { get; set; }
        public int PreInvoiceHeaderId { get; set; }

        public DiscountType DiscountType { get; set; }

        public int DiscountAmount { get; set; }
    }

    public enum DiscountType
    {
        Row = 0,
        Document = 1
    }
}
