using Ecommerce.Common.BLL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;
using Ecommerce.DAL.Models;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL
{
    public class CommentSvc : GenericSvc<CommentRep, Comment>
    {
        private CommentRep commentRep;

        public CommentSvc()
        {
            this.commentRep = new CommentRep();
        }

        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = commentRep.Read(id);

            return res;
        }

        #endregion

        #region -- Methods
        public SingleRsp GetCommentByUserId(int userId)
        {
            var res = this.commentRep.GetCommentByUserId(userId);
            return res;
        }

        public SingleRsp GetCommentByProductId(int productId)
        {
            var res = this.commentRep.GetCommentByProductId(productId);
            return res;
        }

        public SingleRsp AddComment(CommentReq commentReq)
        {
            var res = new SingleRsp();
            Comment comment = new Comment();

            comment.Content = commentReq.Content;
            comment.CreatedDate = DateTime.Now;
            comment.ProductId = commentReq.ProductId;
            comment.UserId = commentReq.UserId;

            res = commentRep.AddComment(comment);

            return res;
        }

        public SingleRsp UpdateComment(int id, CommentReq commentReq)
        {
            var res = new SingleRsp();
            Comment comment = new Comment();

            comment.Id = id;
            comment.Content = commentReq.Content;
            comment.CreatedDate = DateTime.Now;
            comment.ProductId = commentReq.ProductId;
            comment.UserId = commentReq.UserId;

            res = commentRep.UpdateComment(comment);

            return res;
        }

        public SingleRsp DeleteComment(int id)
        {
            var res = new SingleRsp();

            res = commentRep.DeleteComment(id);

            return res;
        }
        #endregion
    }

}
