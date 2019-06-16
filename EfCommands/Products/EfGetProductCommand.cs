using Application.Commands;
using Application.Commands.Products;
using Application.DTO;
using Application.Exceptions;
using AspAppShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Products
{
    public class EfGetProductCommand : BaseEfCommand, IGetProductCommand
    {
        public EfGetProductCommand(AspAppShopContext context) : base(context)
        {
        }

        public ProductDto Execute(int request)
        {
            var product = Context.Products.Find(request);

            if (product == null)
            {
                throw new EntityNotFound();
            }

            return new ProductDto
            {
                ProductId = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryNames = product.ProductCategories.Select(pc => pc.Category.Name),
               // PictureRoutes = product.ProductPictures.Select(pp => pp.Picture.Route),
                //OrderAmounts = product.ProductOrders.Select(po => po.Order.Amount)
            };
        }
    }
}
