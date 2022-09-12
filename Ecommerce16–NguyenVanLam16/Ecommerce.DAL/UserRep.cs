using Ecommerce.Common.Rsp;
using Ecommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common;
using Ecommerce.Common.DAL;

namespace Ecommerce.DAL
{
    public class UserRep:GenericRep<EcommerceDbContext, User>
    {
        #region -- Overrides --
        public override User Read(int id)
        {
            return All.FirstOrDefault(c => c.Id == id);
        }
        #endregion

        #region -- Methods
        public SingleRsp AddUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Users.Add(user);

                        context.SaveChanges();
                        tran.Commit();

                        res.SetData("201", user);
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

        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Users.Update(user);

                        context.SaveChanges();
                        tran.Commit();

                        res.SetData("200", user);
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

        public SingleRsp DeleteUser(int id)
        {
            var res = new SingleRsp();

            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var u = context.Users.Where(c => c.Id == id).First();

                        context.Remove(u);
                        context.SaveChanges();

                        tran.Commit();

                        res.SetData("204", u);
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
