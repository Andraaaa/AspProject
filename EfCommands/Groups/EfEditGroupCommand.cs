using Application.Commands.Groups;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Groups
{
    public class EfEditGroupCommand : BaseEfCommand, IEditGroupCommand
    {
        public EfEditGroupCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(GroupDto request)
        {
            var group = Context.Groups.Find(request.GroupId);

            if (group == null)
            {
                throw new EntityNotFound("Group");
            }
            if (Context.Categories.Any(g => g.Name == request.Name))
            {
                throw new EntityNotFound("Group");
            }

            group.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
