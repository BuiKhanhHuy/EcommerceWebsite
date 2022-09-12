using Ecommerce.Common.DAL;
using Ecommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.Rsp;
using System.Text.Json.Nodes;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL
{
    public class StatsRep
    {
        private EcommerceDbContext context;

        public StatsRep()
        {
            this.context = new EcommerceDbContext();
        }

        public SingleRsp ProductStatisticsByCategory()
        {
            SingleRsp singleRsp = new SingleRsp();
            try
            {
                var result = context.Products.GroupBy(x => new { x.CategoryId, x.Category.Name })
                    .Select(t => new
                    {
                        categoryId = t.Key.CategoryId,
                        categoryName = t.Key.Name,
                        quantity = t.Count(),
                        maxPrice = t.Max(prop => prop.Price),
                        minPrice = t.Min(prop => prop.Price),
                        avgPrice = t.Average(prop => prop.Price)
                    });
                singleRsp.SetData("200", result);
            }
            catch (Exception ex)
            {
                singleRsp.SetData("500", ex.StackTrace);
            }

            return singleRsp;
        }


        public SingleRsp RevenueStatisticsByCategory(String year)
        {
            SingleRsp singleRsp = new SingleRsp();
            try
            {
                var result = context.OrderDetails
                    .Where(od => od.Order.CreatedDate.Value.Year == Int32.Parse(year))
                        .GroupBy(od => new { categoryId = od.Product.CategoryId, categoryName = od.Product.Name})
                     .Select(t => new
                     {
                         categoryId = t.Key.categoryId,
                         categoryName = t.Key.categoryName,
                         turnover = t.Sum(p => p.Num * p.UnitPrice)
                     });


                singleRsp.SetData("200", result);
            }
            catch (Exception ex)
            {
                singleRsp.SetData("500", ex.StackTrace);
            }

            return singleRsp;
        }
    }
}
