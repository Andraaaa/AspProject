using Application.Commands.Groups;
using Application.DTO;
using Application.Searches;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Groups
{
    public class EfGetGroupsCommand : BaseEfCommand, IGetGroupsCommand
    {
        public EfGetGroupsCommand(AspAppShopContext context) : base(context)
        {
        }

        public IEnumerable<GroupDto> Execute(GroupSearch request)
        {
            var query = Context.Groups.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(g =>g.Name.ToLower().Contains(request.Keyword.ToLower()));
            }

            return query.Select(g => new GroupDto
            {
                GroupId=g.Id,
                Name=g.Name
            });
        }
    }
}
