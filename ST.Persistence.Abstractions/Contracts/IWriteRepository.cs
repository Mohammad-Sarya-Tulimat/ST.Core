using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ST.Persistence.Abstractions.Contracts
{
    public interface IWriteRepository<TEntity, TKey> : IReadRepository<TEntity, TKey> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity,CancellationToken cancellationToken=default);  
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default); 
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default); 
        void Add(IEnumerable<TEntity> entities);
        Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        void Update(IEnumerable<TEntity> entities);
        Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        void Delete(IEnumerable<TEntity> entities);
        Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        int Delete(Expression<Func<TEntity, bool>> predicate);
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
     
    }
}
