using Ecommerce.BLL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce16_NguyenVanLam16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private CommentSvc commentSvc;

        public CommentController()
        {
            this.commentSvc = new CommentSvc();
        }

        [HttpGet("")]
        public IActionResult GetComments()
        {
            var res = new SingleRsp();
            res.Data = commentSvc.All;

            return Ok(res);
        }

        [HttpPost("")]
        public IActionResult AddComment([FromBody] CommentReq commentReq)
        {
            var res = commentSvc.AddComment(commentReq);

            return Ok(res);
        }


        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var res = commentSvc.Read(id);

            return Ok(res);
        }

        [HttpGet("Users/{userId}")]
        public IActionResult GetCommentByUserId(int userId)
        {
            var res = commentSvc.GetCommentByUserId(userId);

            return Ok(res);
        }

        [HttpGet("Products/{productId}")]
        public IActionResult GetCommentByProductId(int productId)
        {
            var res = commentSvc.GetCommentByProductId(productId);

            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] CommentReq commentReq)
        {
            var res = commentSvc.UpdateComment(id, commentReq);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCommentById(int id)
        {
            var res = commentSvc.DeleteComment(id);

            return Ok(res);
        }
    }
}
