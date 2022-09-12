using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Req
{
    public class OrderReq
    {
        public decimal? Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UserId { get; set; }

    }
}
