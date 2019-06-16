using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.Groups;
using Application.Exceptions;
using AspAppShop.DataAccess;

namespace EfCommands.Groups
{
    public class EfDeleteGroupCommand : BaseEfCommand,IDeleteGroupCommand
    {
        public EfDeleteGroupCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var group = Context.Groups.Find(request);
            if (group == null)
            {
                throw new EntityNotFound("Group");
            }
            Context.Groups.Remove(group);
            Context.SaveChanges();
        }
    }
}
