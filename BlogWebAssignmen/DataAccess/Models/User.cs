using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        [EmailAddress, Required, StringLength(50)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Intro { get; set; }
        public string Proflie { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
