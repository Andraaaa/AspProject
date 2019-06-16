using Application.Commands;
using Application.Commands.Categories;
using Application.DTO;
using Application.Searches;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Categories
{
    public class EfGetCategoriesCommand : BaseEfCommand,IGetCategoriesCommand
    {

        public EfGetCategoriesCommand(AspAppShopContext context):base(context)
        {
         
        }

        public IEnumerable<CategoryDto> Execute(CategorySearch request)
        {
            var query = Context.Categories.AsQueryable();

            if (request.Keyword != null)
            {
                query = query.Where(c => c.Name.ToLower().Contains(request.Keyword.ToLower()));
            }

            return query.Select(c => new CategoryDto
            {
                CategoryId=c.Id,
                Name=c.Name
            });
        }
    }
}
