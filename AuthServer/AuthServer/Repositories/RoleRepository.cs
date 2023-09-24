using AuthServer.DatabaseContexts;
using AuthServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AuthDbContext _dbContext;

        public RoleRepository(AuthDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Delete(Guid id)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(u => u.Id == id);
            _dbContext.Roles.Remove(role);
        }

        public async Task<Guid> InsertAsync(Role role)
        {
            await _dbContext.Roles.AddAsync(role);
            return role.Id;
        }

        public async Task<List<Role>> SelectAllAsync()
        {
            var roles = await _dbContext.Roles
                .Include(x => x.UserRoles)
                .AsNoTracking()
                .ToListAsync();
            return roles;
        }

        public async Task<Role> SelectByIdAsync(Guid id)
        {
            var role = await _dbContext.Roles
                .Include(x => x.UserRoles)              
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id); ;
            return role;
        }

        public async Task Update(Role role)
        {
            await Task.Run(() =>
            {
                _dbContext.Roles.Update(role);
            });
        }
    }
}
