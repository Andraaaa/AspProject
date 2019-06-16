using Application.Commands.Orders;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Orders
{
    public class EfDeleteOrderCommand : BaseEfCommand, IDeleteOrderCommand
    {
        public EfDeleteOrderCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var order = Context.Orders.Find(request);
            if (order == null)
            {
                throw new EntityNotFound("Order");
            }
            Context.Orders.Remove(order);
            Context.SaveChanges();
        }
    }
}
