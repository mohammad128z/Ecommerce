using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PreInvoiceHeader
    {
        public int Id { get; set; }
        public StateType State { get; set; }

        public SalesLine SalesLine { get; set; }
        public int SalesLineId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int SellerId { get; set; }
        public Seller Seller { get; set; }

    }

    public enum StateType
    {
        Draft = 0,
        Final = 1
    }
}
