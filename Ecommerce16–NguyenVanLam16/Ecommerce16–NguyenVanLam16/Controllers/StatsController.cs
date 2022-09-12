using Ecommerce.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;
using System.Linq;

namespace Ecommerce16_NguyenVanLam16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private EcommerceDbContext context = new EcommerceDbContext();
        public IActionResult Index()
        {


            var stats = context.Products
                .GroupBy(p => p.Category)
                .Select(t =>
                new
                {
                    t.Key.Id,
                    t.Key.Name,
                });

            return Json(stats);

        }
    }
}
