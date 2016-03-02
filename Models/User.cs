
using System.Collections.Generic;

namespace Guardian.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public ICollection<UserRoles> Roles { get; set; }
        public ICollection<UserApplications> Applications { get; set; }
    }
}