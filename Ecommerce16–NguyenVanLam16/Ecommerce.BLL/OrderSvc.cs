using Ecommerce.Common.BLL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;
using Ecommerce.DAL.Models;
using Ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL
{
    public class OrderSvc : GenericSvc<OrderRep, Order>
    {
        OrderRep req = new OrderRep();
        public OrderSvc() { }


        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        public SingleRsp GetOrderByUserId(int userId)
        {
            var res = new SingleRsp();
            res.Data = _rep.GetOrderByUserId(userId);
            return res;
        }
        public SingleRsp CreateOrder(OrderReq orderReq)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.Amount = orderReq.Amount;
            order.CreatedDate = orderReq.CreatedDate;
            order.UserId = orderReq.UserId;
            res = req.CreateOrder(order);
            return res;
        }
        public SingleRsp UpdateOrder(OrderReq orderReq, int orderId)
        {
            var res = new SingleRsp();
            Order order = new Order();
            order.Id = orderId;
            order.Amount = orderReq.Amount;
            order.CreatedDate = orderReq.CreatedDate;
            order.UserId = orderReq.UserId;
            res = req.UpdateOrder(order);
            return res;
        }
        public override SingleRsp Delete(int id)
        {
            return _rep.DeleteOrder(id); ;
        }

        public SingleRsp GetTop5OrdersInMonth(String month)
        {
            var res = new SingleRsp();
            res.Data = _rep.GetTop5OrderInMonth(month);
            return res;
        }


    }
}
