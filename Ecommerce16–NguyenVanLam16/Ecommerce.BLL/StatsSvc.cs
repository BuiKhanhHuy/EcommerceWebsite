using Ecommerce.Common.Rsp;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL
{
    public class StatsSvc
    {
        private StatsRep statsRep;
        public StatsSvc()
        {
            this.statsRep = new StatsRep();
        }

        public SingleRsp ProductStatisticsByCategory()
        {
            SingleRsp result = statsRep.ProductStatisticsByCategory();

            return result;
        }
    }
}
