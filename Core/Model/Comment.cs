using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId{ get; set; }
        public int ProductId{ get; set; }
        public int CommentStar { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsOkey { get; set; }

        public User User { get; set; }
        public Product Product{ get; set; }
    }
}
