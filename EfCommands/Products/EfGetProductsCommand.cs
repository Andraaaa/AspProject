using Application.Commands;
using Application.Commands.Products;
using Application.DTO;
using Application.Searches;
using AspAppShop.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.Products
{
    public class EfGetProductsCommand : BaseEfCommand, IGetProductsCommand
    {
        public EfGetProductsCommand(AspAppShopContext context):base(context)
        {
            
        }

        public IEnumerable<ProductDto> Execute(ProductSearch request)
        {
            var query = Context.Products.AsQueryable();

            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >request.MinPrice);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price < request.MaxPrice);
            }

            if (request.ProductName != null)
            {
                var keyword = request.ProductName.ToLower();

                query = query.Where(p => p.Name.ToLower().Contains(keyword));
            }

            return query.Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Select(p => new ProductDto
                {
                    ProductId=p.Id,
                    AvailableCount=p.AvailableCount,
                    Name=p.Name,
                    Price=p.Price,
                    CategoryNames=p.ProductCategories.Select(pc=>pc.Category.Name),
                    PictureRoutes=p.ProductPictures.Select(pp=>pp.Picture.Route),
                    OrderAmounts=p.ProductOrders.Select(po=>po.Order.Amount),
                });
        }
    }
}
