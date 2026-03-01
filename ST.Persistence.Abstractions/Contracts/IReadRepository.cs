using ST.Shared.Enums;
using ST.Shared.Models; 
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ST.Persistence.Abstractions.Contracts
{
 
    public interface IReadRepository<TEntity, TKey> where TEntity : class
    {
        TEntity Get(TKey id);
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default);

        IEnumerable<TEntity> Get();
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellationToken = default);



        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Get(IEnumerable<Expression<Func<TEntity, bool>>> predicates);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates, CancellationToken cancellationToken = default);



        IEnumerable<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression);
        IEnumerable<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicates);

        Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> Get<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicates, CancellationToken cancellationToken = default); 



        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(IEnumerable<Expression<Func<TEntity, bool>>> predicates);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates, CancellationToken cancellationToken = default);


        TResult FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate);
        TResult FirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicates);
        Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicates, CancellationToken cancellationToken = default);


        PageResult<TEntity> GetPageWithFullCount(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);
        PageResult<TEntity> GetPageWithFullCount(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection); 
        PageResult<TEntity> GetPageWithFullCount(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize);
        PageResult<TEntity> GetPageWithFullCount(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection);

        Task<PageResult<TEntity>> GetPageWithFullCountAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<PageResult<TEntity>> GetPageWithFullCountAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default); 
        Task<PageResult<TEntity>> GetPageWithFullCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<PageResult<TEntity>> GetPageWithFullCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);


        PageResult<TResult> GetPageWithFullCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);
        PageResult<TResult> GetPageWithFullCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection);
        PageResult<TResult> GetPageWithFullCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize);
        PageResult<TResult> GetPageWithFullCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection);


        Task<PageResult<TResult>> GetPageWithFullCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<PageResult<TResult>> GetPageWithFullCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);
        Task<PageResult<TResult>> GetPageWithFullCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<PageResult<TResult>> GetPageWithFullCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);



        PageResult<TEntity> GetPageWithPartialCount(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount);
        PageResult<TEntity> GetPageWithPartialCount(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string OrderBy, OrderByDirection orderByDirection);
        PageResult<TEntity> GetPageWithPartialCount(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount);
        PageResult<TEntity> GetPageWithPartialCount(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string OrderBy, OrderByDirection orderByDirection);


        Task<PageResult<TEntity>> GetPageWithPartialCountAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default);
        Task<PageResult<TEntity>> GetPageWithPartialCountAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);
        Task<PageResult<TEntity>> GetPageWithPartialCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default);
        Task<PageResult<TEntity>> GetPageWithPartialCountAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);


        PageResult<TResult> GetPageWithPartialCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount);
        PageResult<TResult> GetPageWithPartialCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string OrderBy, OrderByDirection orderByDirection);

        PageResult<TResult> GetPageWithPartialCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount);
        PageResult<TResult> GetPageWithPartialCount<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string OrderBy, OrderByDirection orderByDirection);


        Task<PageResult<TResult>> GetPageWithPartialCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default);
        Task<PageResult<TResult>> GetPageWithPartialCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);

        Task<PageResult<TResult>> GetPageWithPartialCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, CancellationToken cancellationToken = default);
        Task<PageResult<TResult>> GetPageWithPartialCountAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, int additionalPagesToCount, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);



        PageResult<TEntity> GetScrollingPage(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);
        PageResult<TEntity> GetScrollingPage(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection);
        PageResult<TEntity> GetScrollingPage(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize);
        PageResult<TEntity> GetScrollingPage(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection);

        Task<PageResult<TEntity>> GetScrollingPageAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<PageResult<TEntity>> GetScrollingPageAsync(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);
        Task<PageResult<TEntity>> GetScrollingPageAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<PageResult<TEntity>> GetScrollingPageAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);


        PageResult<TResult> GetScrollingPage<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);
        PageResult<TResult> GetScrollingPage<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection);
        PageResult<TResult> GetScrollingPage<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize);
        PageResult<TResult> GetScrollingPage<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection);


        Task<PageResult<TResult>> GetScrollingPageAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<PageResult<TResult>> GetScrollingPageAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);
        Task<PageResult<TResult>> GetScrollingPageAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
        Task<PageResult<TResult>> GetScrollingPageAsync<TResult>(Expression<Func<TEntity, TResult>> mapExpression, IEnumerable<Expression<Func<TEntity, bool>>> predicate, int pageIndex, int pageSize, string OrderBy, OrderByDirection orderByDirection, CancellationToken cancellationToken = default);
         

        bool Exists(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        int Count(Expression<Func<TEntity, bool>> predicate = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default);

    }
}
