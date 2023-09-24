using AuthServer.Entities;

namespace AuthServer.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsUserExistsAsync(string username);
        Task<User> SelectByIdAsync(Guid id);
        Task<List<User>> SelectAllAsync();
        Task<Guid> InsertAsync(User user);
        Task Delete(Guid id);
        Task Update(User user);
    }
}
