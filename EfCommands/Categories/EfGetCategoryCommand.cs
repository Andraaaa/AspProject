using Application.Commands;
using Application.Commands.Categories;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Categories
{
    public class EfGetCategoryCommand : BaseEfCommand, IGetCategoryCommand
    {
        public EfGetCategoryCommand(AspAppShopContext context) : base(context)
        {
        }

        public CategoryDto Execute(int request)
        {
            var category= Context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFound();
            }

            return new CategoryDto
            {
                CategoryId = category.Id,
                Name = category.Name
            };
        }
    }
}
