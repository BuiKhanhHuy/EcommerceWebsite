using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.DAL.Models
{
    public partial class OrderDetail
    {
        public long Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Num { get; set; }
        public long? OrderId { get; set; }
        public long? ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
