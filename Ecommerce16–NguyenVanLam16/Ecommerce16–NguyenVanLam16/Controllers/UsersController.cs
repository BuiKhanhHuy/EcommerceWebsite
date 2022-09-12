using Ecommerce.BLL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce16_NguyenVanLam16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private UserSvc userSvc;

        public UsersController()
        {
            this.userSvc = new UserSvc();
        }

        [HttpGet("")]
        public IActionResult GetUsers()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;

            return Ok(res);
        }

        [HttpPost("")]
        public IActionResult AddUser([FromBody] UserReq userReq)
        {
            var res = userSvc.AddUser(userReq);

            return Ok(res);
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var res = userSvc.Read(id);

            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserReq userReq)
        {
            var res = userSvc.UpdateUser(id, userReq);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var res = userSvc.DeleteUser(id);

            return Ok(res);
        }

        [HttpGet("search")]
        public IActionResult SearchUser([FromQuery] SearchUserReq searchUserReq)
        {
            var res = new SingleRsp();
            var users = userSvc.SearchUser(searchUserReq);
            res.Data = users;

            return Ok(res);
        }
    }
}
