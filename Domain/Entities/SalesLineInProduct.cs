using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesLineInProduct
    {
        public virtual SalesLine SalesLine { get; set; }
        public int SalesLineId { get; set; }

        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
