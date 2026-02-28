using Microsoft.EntityFrameworkCore.Storage;
using ST.Persistence.Abstractions.Contracts;

namespace ST.Persistence.EFCore.Services
{
    public class EFCoreTransaction : ITransaction
    {
        IDbContextTransaction _transaction;
        public EFCoreTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
           await _transaction.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }
    }
}
