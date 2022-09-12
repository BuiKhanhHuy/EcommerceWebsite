using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Req
{
    public class StatsReq
    {
        public String? Year { get; set; } = DateTime.Now.Year.ToString();
    }
}
