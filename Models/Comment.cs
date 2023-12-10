using EuphoriaShop.Controllers;
using System;
using System.Collections.Generic;

namespace EuphoriaShop.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Các khóa ngoại và quan hệ
        public virtual Product Product { get; set; }
    }
}
