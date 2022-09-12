using Ecommerce.BLL;
using Ecommerce.Common.Req;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.Common.Rsp;

namespace Ecommerce16_NguyenVanLam16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }

        [HttpGet("get-product-by-id/{Id}")]
        public IActionResult GetProductByID(int Id)
        {
            var res = new SingleRsp();
            res = productSvc.Read(Id);
            return Ok(res);
        }

        [HttpGet("get-product-by-catagory-id/{CategoryId}")]
        public IActionResult GetProductByIdCat(int CategoryId)
        {
            var res = new MultipleRsp();
            res = productSvc.ReadByIdCat(CategoryId);
            return Ok(res);
        }

        [HttpGet("get-product")]
        public IActionResult GetProduct(string? kw=null)
        {
            var res = new MultipleRsp();
            res = productSvc.Read(kw);
            return Ok(res);
        }

        [HttpDelete("del-product-by-id/{Id}")]
        public IActionResult DeleteProductByID(int Id)
        {
            var res = new SingleRsp();
            res = productSvc.Delete(Id);
            return Ok(res);
        }

        [HttpPut("update-product/{Id}")]
        public IActionResult UpdateProduct(int Id,[FromBody] ProductAddOrUpdateReq productAddOrUpdateReq)
        {
            var res = new SingleRsp();
            res = productSvc.Update(Id, productAddOrUpdateReq);
            return Ok(res);
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody] ProductAddReq productAddReq)
        {
            var res = new SingleRsp();
            res = productSvc.AddProdcut(productAddReq);
            return Ok(res);
        }
    }
}
