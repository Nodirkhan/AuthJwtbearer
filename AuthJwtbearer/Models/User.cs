using System;
using System.ComponentModel.DataAnnotations;

namespace AuthJwtbearer.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
    }
}
