using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Users
{
    public class EfEditUserCommand : BaseEfCommand, IEditUserCommand
    {
        public EfEditUserCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(UserDto request)
        {
            var user = Context.Users.Find(request.UserId);

            if (user == null)
            {
                throw new EntityNotFound("User");
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.ModifiedAt = DateTime.Now;
            user.Username = request.Username;
            user.GroupId = request.GroupId;

            Context.SaveChanges();
        }

       
    }
}
