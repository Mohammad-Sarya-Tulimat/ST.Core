using System;
using System.Threading;
using System.Threading.Tasks;

namespace ST.Persistence.Abstractions.Contracts
{
    public interface IUnitOfWork<out TRepo> : IDisposable where TRepo : class
    {
        TRepo Repositories { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        ITransaction GetTransaction(System.Data.IsolationLevel isolation = System.Data.IsolationLevel.ReadCommitted);
        Task<ITransaction> GetTransactionAsync(System.Data.IsolationLevel isolation = System.Data.IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);

    }
}
