using Ecommerce.Common.BLL;
using Ecommerce.Common.Req;
using Ecommerce.Common.Rsp;
using Ecommerce.Common.Utils;
using Ecommerce.DAL;
using Ecommerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep userRep;

        public UserSvc()
        {
            this.userRep = new UserRep();
        }

        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = userRep.Read(id);

            return res;
        }

        #endregion

        #region -- Methods
        public SingleRsp AddUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();

            user.Username = userReq.Username;
            user.Email = userReq.Email;
            user.Password = PasswordEncryption.PasswordHashing(userReq.Password);
            user.FullName = userReq.FullName;
            user.Phone = userReq.Phone;
            user.Active = userReq.Active;
            user.Role = userReq.Role;
            user.CreatedDate = userReq.CreatedDate;
            res = userRep.AddUser(user);

            return res;
        }

        public SingleRsp UpdateUser(int id, UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();

            user.Id = id;
            user.Username = userReq.Username;
            user.Email = userReq.Email;
            user.Password = PasswordEncryption.PasswordHashing(userReq.Password);
            user.FullName = userReq.FullName;
            user.Phone = userReq.Phone;
            user.Active = userReq.Active;
            user.Role = userReq.Role;
            user.CreatedDate = userReq.CreatedDate;
            res = userRep.UpdateUser(user);

            return res;
        }

        public SingleRsp DeleteUser(int id)
        {
            var res = new SingleRsp();

            res = userRep.DeleteUser(id);

            return res;
        }

        public object SearchUser(SearchUserReq searchUserReq)
        {
            var users = All;
            if (searchUserReq.Keyword != null)
            {
                users = users.Where(x => x.Username.Contains(searchUserReq.Keyword) 
                || x.FullName.Contains(searchUserReq.Keyword)
                || x.Email.Contains(searchUserReq.Keyword)
                || x.Phone.Contains(searchUserReq.Keyword));
            }

            var offset = (searchUserReq.Page - 1) * searchUserReq.Size;
            var total = users.Count();

            int totalPage = (int)Math.Ceiling((decimal)total / searchUserReq.Size);

            var data = users.Take(searchUserReq.Size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPage,
                Page = searchUserReq.Page,
                Size = searchUserReq.Size

            };

            return res;
        }
        #endregion
    }
}
