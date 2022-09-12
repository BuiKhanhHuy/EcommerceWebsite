using Ecommerce.Common.DAL;
using Ecommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Common.Rsp;
using System.Text.Json.Nodes;

namespace Ecommerce.DAL
{
    public class StatsRep
    {
        private EcommerceDbContext context;

        public StatsRep()
        {
            this.context = new EcommerceDbContext();
        }

        public SingleRsp ProductStatisticsByCategory()
        {
            SingleRsp singleRsp = new SingleRsp();
            try
            {
                var result = context.Products.GroupBy(p => p.Category);
                singleRsp.SetData("200", result);
            }
            catch (Exception ex)
            {
                singleRsp.SetData("500", ex.StackTrace);
            }

            return singleRsp;
        }
    }
}
