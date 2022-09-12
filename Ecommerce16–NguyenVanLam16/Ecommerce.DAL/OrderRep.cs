using Ecommerce.Common.DAL;
using Ecommerce.Common.Rsp;
using Ecommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class OrderRep : GenericRep<EcommerceDbContext, Order>
    {
        private EcommerceDbContext context;
        public OrderRep()
        {
            context = new EcommerceDbContext();
        }

        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(od => od.Id == id);
            return res;
        }

        public SingleRsp CreateOrder(Order order)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Orders.Add(order);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateOrder(Order order)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Orders.Update(order);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteOrder(int id)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = base.All.First(e => e.Id == id);
                        var p = context.Orders.Remove(m);
                        res.SetData("204", "Xoá Thành Công");
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }

            return res;
        }


        public SingleRsp GetOrderByUserId(int userId)
        {
            var res = new SingleRsp();
            res.Data = base.All.Where(o => o.UserId == userId);

            return res;
        }
        public SingleRsp GetTop5OrderInMonth(string month)
        {
            int monthQuery;
            if (month != null && month != string.Empty)
                monthQuery = Int32.Parse(month);
            else
            {
                DateTime today = DateTime.Today;
                monthQuery = today.Month;

            }
            var res = new SingleRsp();

            try
            {
                //var result = context.Orders.Where(o => o.CreatedDate.Value.Month == monthQuery)
                //.GroupBy(o => o.UserId).OrderByDescending(o => o.Amount).Select(o => new { userId = o.Key}).Take(5);
                var result = (from o in context.Orders
                              where o.CreatedDate.Value.Month == monthQuery
                              orderby o.Amount descending
                              group o by o.UserId into g
                              select g.Key).Take(5);

                res.SetData("200", result);
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);


            }
            return res;
        }
    }
}
