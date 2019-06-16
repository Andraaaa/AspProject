using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CatalogViewModel
    {
        public IEnumerable<ProductDto> Products  { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
