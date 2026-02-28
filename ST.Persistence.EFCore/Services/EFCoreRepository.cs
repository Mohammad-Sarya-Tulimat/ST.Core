using Microsoft.EntityFrameworkCore;
using ST.Core.Enums;
using ST.Core.Models;
using ST.Persistence.Abstractions.Contracts;
using ST.Core.Extensions;
using System.Linq.Expressions;
namespace ST.Persistence.EFCore.Services
{
    public class EFCoreRepository<TEntity, TKey> : IReadRepository<TEntity, TKey>, IWriteRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbSet<TEntity> _set;
        public EFCoreRepository(DbSet<TEntity> set)
        {
            _set = set;
        }
        #region IWriteRepository
        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            _set.AddRange(entities);
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _set.AddAsync(entity, cancellationToken);
        }

        public async Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _set.AddRangeAsync(entities, cancellationToken);
        }


        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            _set.UpdateRange(entities);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _set.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _set.UpdateRange(entities);
            return Task.CompletedTask;
        }
        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            _set.RemoveRange(entities);
        }

        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _set.Where(predicate).ExecuteDelete();
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _set.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {

            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return await _set.Where(predicate).ExecuteDeleteAsync(cancellationToken);
        }
        #endregion

        #region IReadRepository
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return this.GetIQueryable(predicate).Count();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            return this.GetIQueryable(predicate).CountAsync(cancellationToken);
        }
        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return this.GetIQueryable(predicate).Any();
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return this.GetIQueryable(predicate).AnyAsync(cancellationToken);
        } 

        #region FirstOrDefaultAsync
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await this.GetIQueryable(predicate).FirstOrDefaultAsync(cancellationToken);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.GetIQueryable(predicate).FirstOrDefault();
        }

        public TEntity FirstOrDefault(IEnumerable<Expression<Func<TEntity, bool>>> predicates)
        {
            return this.GetIQueryable(predicates).FirstOrDefault();
        }

        public async Task<TEntity> FirstOrDefaultAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates, CancellationToken cancellationToken = default)
        {
            return await this.GetIQueryable(predicates).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await this.GetIQueryable(predicate).Select(mapExpression).FirstOrDefaultAsync(cancellationToken);
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate)
        {
            return this.GetIQueryable(predicate).Select(mapExpression).FirstOrDefault();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicates)
        {
            return this.GetIQueryable(predicates).Select(mapExpression).FirstOrDefault();
        }

        public Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicates, CancellationToken cancellationToken = default)
        {
            return this.GetIQueryable(predicates).Select(mapExpression).FirstOrDefaultAsync(cancellationToken);
        }
        public TEntity Get(TKey id)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            return this._set.Find(id);
        }

        public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            return await this._set.FindAsync(id);
        }
        #endregion


        #region GetList
        public IEnumerable<TEntity> Get()
        {
            return _set.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await this.GetIQueryable(predicate).ToListAsync(cancellationToken);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return this.GetIQueryable(predicate).ToList();
        }

        public IEnumerable<TEntity> Get(IEnumerable<Expression<Func<TEntity, bool>>> predicates)
        {
            return this.GetIQueryable(predicates).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates, CancellationToken cancellationToken = default)
        {
            return await this.GetIQueryable(predicates).ToListAsync(cancellationToken);
        }

        public IEnumerable<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression)
        {
            return _set.Select(mapExpression).ToList();
        }

        public async Task<IEnumerable<TResult>> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await this.GetIQueryable(predicate).Select(mapExpression).ToListAsync(cancellationToken);
        }

        public IEnumerable<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate)
        {
            return this.GetIQueryable(predicate).Select(mapExpression).ToList();
        }

        public IEnumerable<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicates)
        {
            return this.GetIQueryable(predicates).Select(mapExpression).ToList();
        }

        public async Task<IEnumerable<TResult>> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicates, CancellationToken cancellationToken = default)
        {
            return await this.GetIQueryable(predicates).Select(mapExpression).ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _set.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, CancellationToken cancellationToken = default)
        {
            return await _set.Select(mapExpression).ToListAsync(cancellationToken);
        }
        #endregion

        #region GetPageWithFullCount
        public PageResult<TEntity> GetPageWithFullCount(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildWithFullCount(query, pageIndex, pageSize);
        }
        public PageResult<TResult> GetPageWithFullCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildWithFullCount(query, pageIndex, pageSize);
        }
        public async Task<PageResult<TResult>> GetPageWithFullCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildPageWithFullCountAsync(query, pageIndex, pageSize, cancellationToken);

        }
        public PageResult<TEntity> GetPageWithFullCount(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildWithFullCount(query, pageIndex, pageSize, orderBy, orderByDirection);
        }
        public PageResult<TResult> GetPageWithFullCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildWithFullCount(query, pageIndex, pageSize, orderBy, orderByDirection);
        }

        public Task<PageResult<TEntity>> GetPageWithFullCountAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return this.BuildPageWithFullCountAsync(query, pageIndex, pageSize, cancellationToken);
        }

        public async Task<PageResult<TEntity>> GetPageWithFullCountAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildPageWithFullCountAsync(query, pageIndex, pageSize, orderBy, orderByDirection, cancellationToken);
        }
        public async Task<PageResult<TResult>> GetPageWithFullCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildPageWithFullCountAsync(query, pageIndex, pageSize, orderBy, orderByDirection, cancellationToken);
        }
        public PageResult<TEntity> GetPageWithFullCount(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildWithFullCount(query, pageIndex, pageSize);
        }

        public PageResult<TEntity> GetPageWithFullCount(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildWithFullCount(query, pageIndex, pageSize, orderBy, orderByDirection);
        }

        public PageResult<TResult> GetPageWithFullCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildWithFullCount(query, pageIndex, pageSize);
        }
        public PageResult<TResult> GetPageWithFullCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildWithFullCount(query, pageIndex, pageSize, orderBy, orderByDirection);
        }

        public async Task<PageResult<TEntity>> GetPageWithFullCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildPageWithFullCountAsync(query, pageIndex, pageSize, cancellationToken);
        }

        public async Task<PageResult<TEntity>> GetPageWithFullCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildPageWithFullCountAsync(query, pageIndex, pageSize,orderBy,orderByDirection, cancellationToken);
        }

        public async Task<PageResult<TResult>> GetPageWithFullCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildPageWithFullCountAsync(query, pageIndex, pageSize, cancellationToken);
        }

        public async Task<PageResult<TResult>> GetPageWithFullCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildPageWithFullCountAsync(query, pageIndex, pageSize, orderBy, orderByDirection, cancellationToken);
        }

        #endregion

        #region GetPageWithPartialCount
        public PageResult<TEntity> GetPageWithPartialCount(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildWithPartialCount(query, pageIndex, pageSize, additionalPagesToCount);
        }

        public PageResult<TEntity> GetPageWithPartialCount(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildWithPartialCount(query, pageIndex, pageSize, additionalPagesToCount, orderBy, orderByDirection);
        }
        public PageResult<TResult> GetPageWithPartialCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection)
        {

            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildWithPartialCount(query, pageIndex, pageSize, additionalPagesToCount, orderBy, orderByDirection);
        }

        public PageResult<TResult> GetPageWithPartialCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildWithPartialCount(query, pageIndex, pageSize, additionalPagesToCount);
        }
        public async Task<PageResult<TEntity>> GetPageWithPartialCountAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildPageWithPartialCountAsync(query, pageIndex, pageSize, additionalPagesToCount, cancellationToken);
        }

        public async Task<PageResult<TEntity>> GetPageWithPartialCountAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildPageWithPartialCountAsync(query, pageIndex, pageSize, additionalPagesToCount, orderBy, orderByDirection, cancellationToken);
        }

        public async Task<PageResult<TResult>> GetPageWithPartialCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildPageWithPartialCountAsync(query, pageIndex, pageSize, additionalPagesToCount, cancellationToken);
        }

        public async Task<PageResult<TResult>> GetPageWithPartialCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildPageWithPartialCountAsync(query, pageIndex, pageSize, additionalPagesToCount, orderBy, orderByDirection, cancellationToken);
        }



        public PageResult<TEntity> GetPageWithPartialCount(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildWithPartialCount(query, pageIndex, pageSize,additionalPagesToCount);
        }

        public PageResult<TEntity> GetPageWithPartialCount(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildWithPartialCount(query, pageIndex, pageSize, additionalPagesToCount,orderBy,orderByDirection);
        }
        public PageResult<TResult> GetPageWithPartialCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount)
        { 
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildWithPartialCount(query, pageIndex, pageSize, additionalPagesToCount);
        }

        public PageResult<TResult> GetPageWithPartialCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection)
        { 
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildWithPartialCount(query, pageIndex, pageSize, additionalPagesToCount, orderBy, orderByDirection);
        } 
        public async Task<PageResult<TEntity>> GetPageWithPartialCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildPageWithPartialCountAsync(query, pageIndex, pageSize, additionalPagesToCount,cancellationToken);
        }

        public async Task<PageResult<TEntity>> GetPageWithPartialCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildPageWithPartialCountAsync(query, pageIndex, pageSize, additionalPagesToCount,orderBy,orderByDirection, cancellationToken);
        } 

        public async Task<PageResult<TResult>> GetPageWithPartialCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildPageWithPartialCountAsync(query, pageIndex, pageSize, additionalPagesToCount, cancellationToken);
        } 
        public async Task<PageResult<TResult>> GetPageWithPartialCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildPageWithPartialCountAsync(query, pageIndex, pageSize, additionalPagesToCount, orderBy, orderByDirection, cancellationToken);
        }

        #endregion
        #region GetScrollingPage
        public PageResult<TEntity> GetScrollingPage(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildScrollingPage(query, pageIndex, pageSize);
        }

        public PageResult<TEntity> GetScrollingPage(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildScrollingPage(query, pageIndex, pageSize, orderBy, orderByDirection);
        }

        public PageResult<TEntity> GetScrollingPage(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildScrollingPage(query, pageIndex, pageSize);
        }

        public PageResult<TEntity> GetScrollingPage(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate);
            return PageResult.BuildScrollingPage(query, pageIndex, pageSize, orderBy, orderByDirection); 
        }

        public async Task<PageResult<TEntity>> GetScrollingPageAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);  
            return await this.BuildScrollingPage(query, pageIndex, pageSize, cancellationToken);
        }

        public async Task<PageResult<TEntity>> GetScrollingPageAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildScrollingPage(query, pageIndex, pageSize, orderBy, orderByDirection, cancellationToken);
        }

        public async Task<PageResult<TEntity>> GetScrollingPageAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildScrollingPage(query, pageIndex, pageSize, cancellationToken);
        }

        public async Task<PageResult<TEntity>> GetScrollingPageAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate);
            return await this.BuildScrollingPage(query, pageIndex, pageSize, orderBy, orderByDirection, cancellationToken);
        }

        public PageResult<TResult> GetScrollingPage<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildScrollingPage(query, pageIndex, pageSize);
        }

        public PageResult<TResult> GetScrollingPage<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildScrollingPage(query, pageIndex, pageSize, orderBy, orderByDirection);
        }

        public PageResult<TResult> GetScrollingPage<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildScrollingPage(query, pageIndex, pageSize);
        }

        public PageResult<TResult> GetScrollingPage<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return PageResult.BuildScrollingPage(query, pageIndex, pageSize, orderBy, orderByDirection);
        }

        public async Task<PageResult<TResult>> GetScrollingPageAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildScrollingPage(query, pageIndex, pageSize, cancellationToken);
        }

        public async Task<PageResult<TResult>> GetScrollingPageAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildScrollingPage(query, pageIndex, pageSize, orderBy, orderByDirection, cancellationToken);
        }

        public async Task<PageResult<TResult>> GetScrollingPageAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildScrollingPage(query, pageIndex, pageSize, cancellationToken);
        }

        public async Task<PageResult<TResult>> GetScrollingPageAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var query = this.GetIQueryable(predicate).Select(mapExpression);
            return await this.BuildScrollingPage(query, pageIndex, pageSize, orderBy, orderByDirection, cancellationToken);
        }

        #endregion

        #endregion

        #region Helpers
        protected IQueryable<TEntity> GetIQueryable(IEnumerable<Expression<Func<TEntity, bool>>> predicates)
        {
            IQueryable<TEntity> query = _set;
            if (predicates != null)
            {
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
            }
            return query;
        }
        protected IQueryable<TEntity> GetIQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _set;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        protected async Task<PageResult<T>> BuildPageWithFullCountAsync<T>(IQueryable<T> query, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
        {
            var count = await query.LongCountAsync(cancellationToken);
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Count = count,
                Items = await query.ToListAsync(cancellationToken),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
        protected async Task<PageResult<T>> BuildPageWithFullCountAsync<T>(IQueryable<T> query, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var count = await query.LongCountAsync(cancellationToken);
            if (orderByDirection == OrderByDirection.Ascending)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Count = count,
                Items = await query.ToListAsync(cancellationToken),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        protected async Task<PageResult<T>> BuildPageWithPartialCountAsync<T>(IQueryable<T> query, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default)
        {
            var take = (pageIndex + additionalPagesToCount) * pageSize;
            var count = await query.Take(take).LongCountAsync(cancellationToken);
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Count = count,
                Items = await query.ToListAsync(cancellationToken),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
        protected async Task<PageResult<T>> BuildPageWithPartialCountAsync<T>(IQueryable<T> query, int pageIndex, int pageSize, int additionalPagesToCount, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            var take = (pageIndex + additionalPagesToCount) * pageSize;
            var count = await query.Take(take).LongCountAsync(cancellationToken);
            if (orderByDirection == OrderByDirection.Ascending)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Count = count,
                Items = await query.ToListAsync(cancellationToken),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }


        protected async Task<PageResult<T>> BuildScrollingPage<T>(IQueryable<T> query, int pageIndex, int pageSize,CancellationToken cancellationToken = default)
        {
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Items = await query.ToListAsync(cancellationToken),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
        protected async Task<PageResult<T>> BuildScrollingPage<T>(IQueryable<T> query, int pageIndex, int pageSize, string orderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default)
        {
            if (orderByDirection == OrderByDirection.Ascending)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
            var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new PageResult<T>()
            {
                Items = await query.ToListAsync(cancellationToken),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }
        #endregion

    }
}
