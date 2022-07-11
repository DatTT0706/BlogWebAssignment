using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataAccess.Models
{
    [Table("post_meta")]
    public partial class PostMeta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? PostId { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }

        public virtual Post Post { get; set; }
    }
}
