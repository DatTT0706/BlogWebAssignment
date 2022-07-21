using System;

namespace DataAccess.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public int Published { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }
    }
}
