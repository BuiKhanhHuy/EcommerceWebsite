using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Req
{
    public class SearchUserReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string? Keyword { get; set; }
    }
}
