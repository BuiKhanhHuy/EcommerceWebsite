using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Req
{
    public class CommentReq
    {
        public string Content { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
