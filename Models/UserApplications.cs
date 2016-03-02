
namespace Guardian.Models
{
    public class UserApplications
    {
        public int Id { get; set; }
        public int UseId { get; set; }
        public User User { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}