using Ecommerce.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using System.Linq;
using Ecommerce.BLL;

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
    }
}
