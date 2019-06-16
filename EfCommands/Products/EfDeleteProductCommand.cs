using Application.Commands;
using Application.Commands.Products;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Products
{
    public class EfDeleteProductCommand :BaseEfCommand, IDeleteProductCommand
    {
    

        public EfDeleteProductCommand(AspAppShopContext context):base(context)
        {
            
        }

        public void Execute(int request)
        {
            var product = Context.Products.Find(request);

            if (product == null)
            {
                throw new EntityNotFound();
            }

            Context.Products.Remove(product);
            Context.SaveChanges();
        }
    }
}
