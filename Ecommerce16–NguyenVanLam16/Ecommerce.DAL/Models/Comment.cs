using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.DAL.Models
{
    public partial class Comment
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? ProductId { get; set; }
        public long? UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
