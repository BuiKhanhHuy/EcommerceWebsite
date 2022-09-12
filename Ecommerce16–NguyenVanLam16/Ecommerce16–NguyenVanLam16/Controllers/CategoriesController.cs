using Microsoft.AspNetCore.Mvc;
using Ecommerce.BLL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;

namespace Ecommerce16_NguyenVanLam16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private CategorySvc categorySvc;

        public CategoriesController()
        {
            this.categorySvc = new CategorySvc();
        }

        [HttpGet("")]
        public IActionResult GetCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;

            return Ok(res);
        }

        [HttpPost("")]
        public IActionResult AddCategory([FromBody] CategoryReq categoryReq)
        {
            var res = categorySvc.AddCategory(categoryReq);

            return Ok(res);
        }


        [HttpGet("{id}")]
        public IActionResult GetCatetoryById(int id)
        {
            var res = categorySvc.Read(id);

            return Ok(res);
        }

        [HttpPut ("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryReq categoryReq)
        {
            var res = categorySvc.UpdateCategory(id, categoryReq);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var res = categorySvc.DeleteCategory(id);

            return Ok(res);
        }

        [HttpGet("search")]
        public IActionResult SearchCategory([FromQuery] SearchCategoryReq searchCategoryReq)
        {
            var res = new SingleRsp();
            var categories = categorySvc.SearchCategory(searchCategoryReq);
            res.Data = categories;

            return Ok(res);
        }
    }
}
