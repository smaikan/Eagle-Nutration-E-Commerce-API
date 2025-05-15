using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Comment
    {
        public int CommentId { get; set; }
        public int UserId{ get; set; }
        public int ProductId{ get; set; }
        public int CommentStar { get; set; }
        public string CommentDescription { get; set; }
        public bool IsOkey { get; set; }
    }
}
