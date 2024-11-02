using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.SalesLineDtos
{
    public class AddSalesLineDto
    {        
        [Required]
        [MaxLength(100), MinLength(2)]
        public string Name { get; set; }
    }
}
