using AuthServer.DatabaseContexts;
using AuthServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AuthDbContext _dbContext;

        public UserRoleRepository(AuthDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Delete(Guid id)
        {
            var userRole = await _dbContext.UserRoles.FirstOrDefaultAsync(u => u.Id == id);
            _dbContext.UserRoles.Remove(userRole);
        }

        public async Task<Guid> InsertAsync(UserRole userRole)
        {
            await _dbContext.UserRoles.AddAsync(userRole);
            return userRole.Id;
        }

        public async Task<List<UserRole>> SelectAllAsync()
        {
            var userRoles = await _dbContext.UserRoles
                .Include(x => x.User)
                .Include(x => x.Role)
                .AsNoTracking()
                .ToListAsync();
            return userRoles;
        }

        public async Task<UserRole> SelectByIdAsync(Guid id)
        {
            var userRole = await _dbContext.UserRoles
                .Include(x => x.User)
                .Include(x => x.Role)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id); ;
            return userRole;
        }

        public async Task Update(UserRole userRole)
        {
            await Task.Run(() =>
            {
                _dbContext.UserRoles.Update(userRole);
            });
        }
    }
}
