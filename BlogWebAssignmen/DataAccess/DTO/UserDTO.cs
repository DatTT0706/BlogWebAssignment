using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{LastName} {MiddleName} {FirstName}";
        public string Mobile { get; set; }
        [EmailAddress, Required, StringLength(50)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastLogin { get; set; }
        public string Intro { get; set; }
        public string Proflie { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role{ get; set; }
    }
}
