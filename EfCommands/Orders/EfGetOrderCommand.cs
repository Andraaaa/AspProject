using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.Orders;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;

namespace EfCommands.Orders
{
    public class EfGetOrderCommand : BaseEfCommand,IGetOrderCommand
    {
        public EfGetOrderCommand(AspAppShopContext context) : base(context)
        {
        }

        public OrderDto Execute(int request)
        {
            var order = Context.Orders.Find(request);

            if (order == null)
            {
                throw new EntityNotFound();
            }

            return new OrderDto
            {
                UserId = order.UserId,
                Address = order.Address,
                City = order.City,
                Amount = order.Amount
            };
        }
    }
}
