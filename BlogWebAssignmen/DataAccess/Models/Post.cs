﻿using System;
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
        public int AuthorId { get; set; }
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
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<PostMeta> PostMeta { get; set; }
    }
}
