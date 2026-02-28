using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ST.Persistence.Abstractions.Contracts
{
    public interface ITransaction:IDisposable
    {
        void Commit();
        void Rollback();
        Task CommitAsync(CancellationToken cancellationToken=default);
        Task RollbackAsync(CancellationToken cancellationToken=default);
    }
}
