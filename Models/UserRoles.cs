
namespace Guardian.Models
{
    public class UserRoles
    {
        public int Id { get; set; }
        public int UseId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}