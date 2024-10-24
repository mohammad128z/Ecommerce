using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesLineInSeller
    {
        public SalesLine SalesLine { get; set; }
        public int SalesLineId { get; set; }

        public Seller Seller { get; set; }
        public int SellerId { get; set; }
    }
}
