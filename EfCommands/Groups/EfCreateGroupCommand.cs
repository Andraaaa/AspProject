using Application.Commands.Groups;
using Application.DTO;
using AspAppShop.DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Groups
{
    public class EfCreateGroupCommand : BaseEfCommand, ICreateGroupCommand
    {
        public EfCreateGroupCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(GroupDto request)
        {
            Context.Groups.Add(new Group
            {
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
