using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.Commands.Products;
using Application.DTO;
using AspAppShop.DataAccess;
using Domain;

namespace EfCommands.Products
{
    public class EfCreateProductCommand : BaseEfCommand,ICreateProductCommand
    {
        public EfCreateProductCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(ProductDto request)
        {
            Context.Products.Add(new Product
            {
                Name = request.Name,
                Description=request.Description,
                Price=request.Price
            });
            Context.SaveChanges();
        }
    }
}
