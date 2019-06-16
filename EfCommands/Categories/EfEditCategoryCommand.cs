using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.Commands.Categories;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;

namespace EfCommands.Categories
{
    public class EfEditCategoryCommand : BaseEfCommand, IEditCategoryCommand
    {
        public EfEditCategoryCommand(AspAppShopContext context) : base(context)
        {
        }

        public void Execute(CategoryDto request)
        {
            var category = Context.Categories.Find(request.CategoryId);

            if (category == null)
            {
                throw new EntityNotFound("Category");
            }
            if (Context.Categories.Any(c => c.Name == request.Name))
            {
                throw new EntityNotFound("Category");
            }

            category.Name = request.Name;

            Context.SaveChanges();
        }
    }
}
