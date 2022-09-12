using Ecommerce.BLL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce16_NguyenVanLam16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderSvc orderSvc;
        public OrderController()
        {
            orderSvc = new OrderSvc();
        }

        [HttpGet("{orderId}")]

        public IActionResult GetOrderByID(int orderId)
        {

            var res = new SingleRsp();
            res = orderSvc.Read(orderId);
            return Ok(res);
        }
        [HttpDelete("{orderId}")]

        public IActionResult DeleteOrderByID(int orderId)
        {
            var res = new SingleRsp();
            res = orderSvc.Delete(orderId);
            return Ok(res);
        }

        [HttpPost("")]
        public IActionResult CreateOrder([FromBody] OrderReq orderReq)
        {
            var res = orderSvc.CreateOrder(orderReq);
            return Ok(res);
        }
        [HttpGet("Users/{userId}")]
        public IActionResult GetOrderByUserId(int userId)
        {
            var res = orderSvc.GetOrderByUserId(userId);
            return Ok(res);
        }

        [HttpPut("{orderId}")]
        public IActionResult UpdateUserId([FromBody] OrderReq orderReq, int orderId)
        {
            var res = orderSvc.UpdateOrder(orderReq, orderId);
            return Ok(res);
        }
        [HttpPost("top-5-orders")]
        public IActionResult GetTop5OrdersInMonth([FromQuery] String? monthReq)
        {
            var res = new SingleRsp(); ;
            if (monthReq == null)
                res = orderSvc.GetTop5OrdersInMonth(null);
            else
                res = orderSvc.GetTop5OrdersInMonth(monthReq);
            return Ok(res);
        }
    }
}
