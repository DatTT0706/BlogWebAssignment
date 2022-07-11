using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class PostComment
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public int? Published { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string Content { get; set; }

        public virtual Post Post { get; set; }
    }
}
