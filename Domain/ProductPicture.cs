using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProductPicture
    {
        public int ProductId { get; set; }
        public int PictureId { get; set; }
        public Product Product { get; set; }
        public Picture Picture { get; set; }
    }
}
