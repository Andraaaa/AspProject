using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
