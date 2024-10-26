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

        public StateType State { get; set; } = StateType.Draft;

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual SalesLineInSeller SalesLineInSeller { get; set; }
    }

    public enum StateType
    {
        Draft = 0,
        Final = 1
    }
}
