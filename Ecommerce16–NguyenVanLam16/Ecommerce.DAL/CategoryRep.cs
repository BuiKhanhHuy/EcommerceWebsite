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
                        var c = context.Categories.Add(category);
                        context.SaveChanges();
                        tran.Commit();

                        res.Data = c;
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

        public SingleRsp Delete(int id)
        {
            var res = new SingleRsp();

            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var cat = base.All.First(c => c.Id == id);

                        cat = base.Delete(cat);

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.Message);
                    }
                }
            }

            return res;
        }
        #endregion
    }
}
