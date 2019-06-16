using Application.Commands;
using Application.Commands.Categories;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.Categories
{
    public class EfDeleteCategoryCommand : BaseEfCommand, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var category = Context.Categories.Find(request);
            if (category == null)
            {
                throw new EntityNotFound("Category");
            }
            Context.Categories.Remove(category);
            Context.SaveChanges();
        }
    }
}
