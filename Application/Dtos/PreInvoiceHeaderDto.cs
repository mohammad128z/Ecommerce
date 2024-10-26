using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class PreInvoiceHeaderDto
    {

        public StateType State { get; set; }
        [Required]
        public int SalesLineId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int SellerId { get; set; }
    }

    public class AddPreInvoiceHeaderDto
    {
        [Required]
        public int SalesLineId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int SellerId { get; set; }
    }
}
