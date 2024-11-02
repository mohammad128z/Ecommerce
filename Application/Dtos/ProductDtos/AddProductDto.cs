using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.ProductDtos
{
    public class AddProductDto
    {
        [Required]
        [MaxLength(100), MinLength(2)]
        public string Name { get; set; }
    }
}
