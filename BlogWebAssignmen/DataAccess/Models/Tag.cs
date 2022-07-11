using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataAccess.Models
{
    public partial class Tag
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(150)]
        public string MetaTitle { get; set; }
        [Required, StringLength(150)]
        public string Slug { get; set; }
        [Required, StringLength(int.MaxValue)]
        public string Content { get; set; }
    }
}
