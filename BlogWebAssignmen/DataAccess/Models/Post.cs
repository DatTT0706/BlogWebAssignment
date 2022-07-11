using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataAccess.Models
{
    public partial class Post
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
            PostMeta = new HashSet<PostMeta>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int? AuthorId { get; set; }
        [Required]
        public int? ParentId { get; set; }
        [Required,StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(150)]
        public string MetaTitle { get; set; }
        [Required, StringLength(150)]
        public string Slug { get; set; }
        [Required, StringLength(255)]
        public string Summary { get; set; }
        [Required]
        public int? Published { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        [Required]
        public string Content { get; set; }

        public virtual User Author { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostMeta> PostMeta { get; set; }
    }
}
