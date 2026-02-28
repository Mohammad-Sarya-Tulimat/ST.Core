using Microsoft.EntityFrameworkCore;
using ST.Persistence.Abstractions.Contracts;
using System.Data; 
namespace ST.Persistence.EFCore.Services
{
    public abstract class EFCoreUnitOfWork<TRepo> : IUnitOfWork<TRepo> where TRepo : class
    {
        public abstract TRepo Repositories { get; }
        public EFCoreUnitOfWork(DbContext context)
        {
            Context = context;
        }
        protected DbContext Context { get; }
        public void Dispose()
        {
            this.Context?.Dispose();
        }
        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await this.Context.SaveChangesAsync(cancellationToken);
        }

        public ITransaction GetTransaction(IsolationLevel isolation = IsolationLevel.ReadCommitted)
        {  
            return new EFCoreTransaction(this.Context.Database.BeginTransaction(isolation));

        }

        public async Task<ITransaction> GetTransactionAsync(IsolationLevel isolation = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            var transaction =await this.Context.Database.BeginTransactionAsync(isolation,cancellationToken);
            return new EFCoreTransaction(transaction);
        }
    }
}
