using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.Commands.Products;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;

namespace EfCommands.Products
{
    public class EfEditProductCommand : BaseEfCommand,IEditProductCommand
    {
        public EfEditProductCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(ProductDto request)
        {
            var product = Context.Products.Find(request.ProductId);

            if (product == null)
            {
                throw new EntityNotFound("Category");
            }


            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            Context.SaveChanges();
        }
    }
}
