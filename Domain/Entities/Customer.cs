﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength = 2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
