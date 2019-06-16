using Application.Commands.User;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Users
{
    public class EfGetUserCommand : BaseEfCommand, IGetUserCommand
    {
        public EfGetUserCommand(AspAppShopContext context) : base(context)
        {
        }

        public UserDto Execute(int request)
        {
            var user = Context.Users.Find(request);

            if (user == null)
            {
                throw new EntityNotFound();
            }

            return new UserDto
            {
                UserId = user.Id,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Username=user.Username,
                GroupId=user.Group.Id
            };
        }
    }
}
