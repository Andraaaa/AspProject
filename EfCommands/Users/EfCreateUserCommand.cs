using Application.Commands.User;
using Application.DTO;
using AspAppShop.DataAccess;
using Domain;

namespace EfCommands.Users
{
    public class EfCreateUserCommand : BaseEfCommand,ICreateUserCommand
    {
        public EfCreateUserCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(UserDto request)
        {
            Context.Users.Add(new User
            {
                FirstName=request.FirstName,
                LastName=request.LastName,
                Username=request.Username,
                GroupId=request.GroupId
            });
            Context.SaveChanges();
        }
    }
}
