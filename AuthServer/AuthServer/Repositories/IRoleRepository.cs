using AuthServer.Entities;

namespace AuthServer.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> SelectByIdAsync(Guid id);
        Task<List<Role>> SelectAllAsync();
        Task<Guid> InsertAsync(Role role);
        Task Delete(Guid id);
        Task Update(Role role);
    }
}
