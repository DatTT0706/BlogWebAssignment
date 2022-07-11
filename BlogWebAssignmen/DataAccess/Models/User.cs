using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string MiddleName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(50)]
        public string Mobile { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(50)]
        public string PasswordHash { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public DateTime? LastLogin { get; set; }
        [Required, StringLength(255)]
        public string Intro { get; set; }
        [Required, StringLength(int.MaxValue)]
        public string Proflie { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
