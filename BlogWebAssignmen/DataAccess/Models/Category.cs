using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            PostCategories = new HashSet<PostCategory>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }
    }
}
