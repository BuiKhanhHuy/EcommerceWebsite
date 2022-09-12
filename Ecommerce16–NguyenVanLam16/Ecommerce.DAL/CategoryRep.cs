using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.DAL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;
using Ecommerce.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL
{
    public class CategoryRep : GenericRep<EcommerceDbContext, Category>
    {
        #region -- Overrides --
        public override Category Read(int id)
        {
            return All.FirstOrDefault(c => c.Id == id);
        }
        #endregion

        #region -- Methods
        public SingleRsp AddCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Categories.Add(category);

                        context.SaveChanges();
                        tran.Commit();

                        res.SetData("201", category);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError("500", ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Categories.Update(category);

                        context.SaveChanges();
                        tran.Commit();

                        res.SetData("200", category);
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError("500", ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteCategory(int id)
        {
            var res = new SingleRsp();

            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var cat = context.Categories.Where(c => c.Id == id).First();

                        context.Remove(cat);    
                        context.SaveChanges();

                        tran.Commit();

                        res.SetData("204", cat);
                    }
                    catch (Exception ex)
                    {
                        res.SetError("500", ex.StackTrace);
                        tran.Rollback();
                    }
                }
            }

            return res;
        }
        #endregion
    }
}
