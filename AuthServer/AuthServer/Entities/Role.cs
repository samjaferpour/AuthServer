using System.ComponentModel.DataAnnotations;

namespace AuthServer.Entities
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
