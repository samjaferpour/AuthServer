using AuthServer.DatabaseContexts;

namespace AuthServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthDbContext _dbContext;

        public UnitOfWork(AuthDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task CommitChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
