using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Picture : BaseEntity
    {
        public string Route { get; set; }
        public string Descritption { get; set; }
        public ICollection<ProductPicture> PictureProducts { get; set; }
    }
}
