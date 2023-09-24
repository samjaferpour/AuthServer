using AuthServer.Entities;

namespace AuthServer.Repositories
{
    public interface IUserRoleRepository
    {
        Task<UserRole> SelectByIdAsync(Guid id);
        Task<List<UserRole>> SelectAllAsync();
        Task<Guid> InsertAsync(UserRole userRole);
        Task Delete(Guid id);
        Task Update(UserRole userRole);
    }
}
