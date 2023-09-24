using AuthServer.DatabaseContexts;
using AuthServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _dbContext;

        public UserRepository(AuthDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task Delete(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            _dbContext.Users.Remove(user);
        }

        public async Task<Guid> InsertAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return user.Id;
        }

        public async Task<bool> IsUserExistsAsync(string username)
        {
            var user = await _dbContext.Users.AnyAsync(x => x.Username == username);
            return user;
        }

        public async Task<List<User>> SelectAllAsync()
        {
            var users = await _dbContext.Users
                .Include(x => x.UserRoles)
                .AsNoTracking()
                .ToListAsync();
            return users;
        }

        public async Task<User> SelectByIdAsync(Guid id)
        {
            var user = await _dbContext.Users
                .Include(x => x.UserRoles)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id); ;
            return user;
        }

        public async Task Update(User user)
        {
            await Task.Run(() =>
            {
                _dbContext.Users.Update(user);
            });
        }
    }
}
