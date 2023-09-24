namespace AuthServer.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitChangesAsync();
    }
}
