using Ecommerce.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using System.Linq;
using Ecommerce.BLL;
using Ecommerce.Common.Req;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Ecommerce.Common.Rsp;

namespace Ecommerce16_NguyenVanLam16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private StatsSvc statsSvc;

        public StatsController()
        {
            this.statsSvc = new StatsSvc();
        }


        [HttpGet("/product-statistics-by-category")]
        public IActionResult ProductStatisticsByCategory()
        {
            return Ok(this.statsSvc.ProductStatisticsByCategory());
        }

        [HttpGet("/revenue-statistics-by-category")]
        public IActionResult RevenueStatisticsByCategory([FromQuery] StatsReq statsReq)
        {
            SingleRsp res;

            if (statsReq != null)
            {
                res = this.statsSvc.RevenueStatisticsByCategory(statsReq.Year);
            }
            else
            {
                res = this.statsSvc.RevenueStatisticsByCategory(null);
            }
            return Ok(res);
        }
    }
}
