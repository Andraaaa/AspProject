using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order : BaseEntity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public ICollection<ProductOrder> OrderProducts { get; set; }
    }
}
