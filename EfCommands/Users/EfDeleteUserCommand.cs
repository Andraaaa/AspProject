using Application.Commands.User;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Users
{
    public class EfDeleteUserCommand : BaseEfCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNotFound("Category");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
        }
    }
}
