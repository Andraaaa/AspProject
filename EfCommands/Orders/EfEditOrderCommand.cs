using Application.Commands.Orders;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Orders
{
    public class EfEditOrderCommand : BaseEfCommand, IEditOrderCommand
    {
        public EfEditOrderCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(OrderDto request)
        {
            var order = Context.Orders.Find(request.OrderId);

            if (order == null)
            {
                throw new EntityNotFound("Category");
            }


            order.UserId = request.UserId;
            order.Address = request.Address;
            order.City = request.City;
            order.Amount = request.Amount;

            Context.SaveChanges();
        }
    }
}
