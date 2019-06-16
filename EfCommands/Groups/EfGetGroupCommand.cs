using Application.Commands.Groups;
using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Groups
{
    public class EfGetGroupCommand : BaseEfCommand, IGetGroupCommand
    {
        public EfGetGroupCommand(AspAppShopContext context) : base(context)
        {
        }

        public GroupDto Execute(int request)
        {
            var group = Context.Groups.Find(request);

            if (group == null)
            {
                throw new EntityNotFound();
            }

            return new GroupDto
            {
                GroupId=group.Id,
                Name=group.Name
            };
        }
    }
}
