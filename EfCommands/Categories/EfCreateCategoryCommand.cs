using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.Commands.Categories;
using Application.DTO;
using AspAppShop.DataAccess;
using Domain;

namespace EfCommands.Categories
{
    public class EfCreateCategoryCommand : BaseEfCommand,ICreateCategoryCommand
    {
        public EfCreateCategoryCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            Context.Categories.Add(new Category
            {
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
