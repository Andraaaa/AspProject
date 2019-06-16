using Application.Commands;
using Application.Commands.User;
using Application.DTO;
using Application.Searches;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Users
{
    public class EfGetUsersCommand : BaseEfCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(AspAppShopContext context) : base(context)
        {
        }

        public IEnumerable<UserDto> Execute(UserSearch request)
        {
            var query = Context.Users.AsQueryable();

            if (request.FirstName != null)
            {
                query = query.Where(c => c.FirstName.ToLower().Contains(request.FirstName.ToLower()));
            }

            return query.Select(u=>new UserDto
            {
                UserId = u.Id,
                FirstName = u.FirstName,
                LastName=u.LastName,
                Username=u.Username
            });
        }
    }
}
