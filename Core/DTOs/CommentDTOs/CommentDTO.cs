using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.CommentDTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        // Opsiyonel: kullanıcı adı da gösterilebilir
        public string UserFullName { get; set; }

    }
}
