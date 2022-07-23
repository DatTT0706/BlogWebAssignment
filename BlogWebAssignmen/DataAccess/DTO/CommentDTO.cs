using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public int Published { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
        public UserDTO User { get; set; }
        public string UserName => User.FullName;
    }
}