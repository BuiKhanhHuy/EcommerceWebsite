﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Req
{
    public class UserReq
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public bool? Active { get; set; }
        public string Role { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
