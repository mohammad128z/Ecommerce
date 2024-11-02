using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesLineInSeller
    {
        public int Id { get; set; }

        public int PreInvoiceHeaderId { get; set; }
        public virtual PreInvoiceHeader PreInvoiceHeader { get; set; }

        public virtual SalesLine SalesLine { get; set; }
        public int SalesLineId { get; set; }

        public virtual Seller Seller { get; set; }
        public int SellerId { get; set; }
    }
}
