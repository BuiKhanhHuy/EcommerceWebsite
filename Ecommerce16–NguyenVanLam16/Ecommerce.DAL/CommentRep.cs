using Ecommerce.Common.DAL;
using Ecommerce.Common.Rsp;
using Ecommerce.DAL.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL
{
    public class CommentRep : GenericRep<EcommerceDbContext, Comment>
    {
        #region -- Overrides --
        public override Comment Read(int id)
        {
            return All.FirstOrDefault(c => c.Id == id);
        }
        #endregion

        #region -- Methods
        public SingleRsp GetCommentByUserId(int userId)
        {
            var res = new SingleRsp();
            res.Data = base.All.Where(c => c.UserId == userId);

            return res;
        }

        public SingleRsp GetCommentByProductId(int productId)
        {
            var res = new SingleRsp();
            res.Data = base.All.Where(c => c.ProductId == productId);

            return res;
        }

        public SingleRsp AddComment(Comment comment)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Comments.Add(comment);

                        context.SaveChanges();
                        tran.Commit();

                        res.SetData("201", comment);
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

        public SingleRsp UpdateComment(Comment comment)
        {
            var res = new SingleRsp();
            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Comments.Update(comment);

                        context.SaveChanges();
                        tran.Commit();

                        res.SetData("200", comment);
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

        public SingleRsp DeleteComment(int id)
        {
            var res = new SingleRsp();

            using (var context = new EcommerceDbContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var com = context.Comments.Where(c => c.Id == id).First();

                        context.Remove(com);
                        context.SaveChanges();

                        tran.Commit();

                        res.SetData("204", com);
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
