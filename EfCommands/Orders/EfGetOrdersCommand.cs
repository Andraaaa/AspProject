using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands.Orders;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using AspAppShop.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.Orders
{
    public class EfGetOrdersCommand : BaseEfCommand,IGetOrdersCommand
    {
        public EfGetOrdersCommand(AspAppShopContext context) : base(context)
        {
        }

       

        public IEnumerable<OrderDto> Execute(OrderSearch request)
        {
            var query = Context.Orders.AsQueryable();

            if (query == null)
            {
                throw new EntityNotFound("Order");
            }

           return query.Select(o => new OrderDto
            {
                UserId = o.UserId,
                Address = o.Address,
                City = o.City,
                Amount = o.Amount
            });
        }
    }
}
