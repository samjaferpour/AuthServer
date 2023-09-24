using AuthServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.DatabaseContexts
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }   
        public DbSet<UserRole> UserRoles { get; set; }   
    }
}
