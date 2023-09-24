using System.ComponentModel.DataAnnotations;

namespace AuthServer.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
