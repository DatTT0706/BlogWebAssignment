using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Post
    {
        public Post()
        {
            PostCategories = new HashSet<PostCategory>();
            PostComments = new HashSet<PostComment>();
            PostMeta = new HashSet<PostMeta>();
        }

        public int Id { get; set; }
        public int? AuthorId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public int? Published { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
 
        public string Content { get; set; }

        public virtual User Author { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostMeta> PostMeta { get; set; }
    }
}
