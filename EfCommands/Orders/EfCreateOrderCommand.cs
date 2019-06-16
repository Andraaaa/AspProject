using Application.Commands;
using Application.Commands.Orders;
using Application.DTO;
using AspAppShop.DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Orders
{
    public class EfCreateOrderCommand : BaseEfCommand, ICreateOrderCommand
    {
        public EfCreateOrderCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(OrderDto request)
        {
            Context.Orders.Add(new Order
            {
                UserId=request.UserId,
                CreatedAt=DateTime.Now,
                Address=request.Address,
                City=request.City,
                Amount=request.Amount,

            });
            Context.SaveChanges();
        }
    }
}
