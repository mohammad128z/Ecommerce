using Domain.Entities;

namespace Application.Dtos
{
    public class DetailPreInvoiceDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

    }
}
