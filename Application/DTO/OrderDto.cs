using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MinLength (10)]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MinLength(0)]
        public decimal Amount { get; set; }
    }
}
