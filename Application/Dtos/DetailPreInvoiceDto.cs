using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class DetailPreInvoiceDto
    {        
        public int PreInvoiceHeaderId {  get; set; }
        public int ProductId { get; set; }
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
    }
}
