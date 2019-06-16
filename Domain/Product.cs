using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
