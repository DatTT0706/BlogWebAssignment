using DataAccess.Models;

namespace DataAccess.DTO
{
    public class PostCategoryDTO
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryDTO Category { get; set; }
        public virtual PostDTO Post { get; set; }
    }
}