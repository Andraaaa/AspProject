using Application.DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Products
{
    public interface IEditProductCommand:ICommand<ProductDto>
    {
    }
}
