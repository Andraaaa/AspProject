using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0,10000)]
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
        public IEnumerable<string> CategoryNames { get; set; }
        public IEnumerable<decimal> OrderAmounts { get; set; }
        public IEnumerable<string> PictureRoutes { get; set; }


    }
}
