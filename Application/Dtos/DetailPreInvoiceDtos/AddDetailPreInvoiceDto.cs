using Application.CustomeAttributes;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.DetailPreInvoiceDtos
{
    public class AddDetailPreInvoiceDto
    {
        [Required]
        [ExistsInDatabase<PreInvoiceHeader>]
        public int PreInvoiceHeaderId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
        
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
    }
}
