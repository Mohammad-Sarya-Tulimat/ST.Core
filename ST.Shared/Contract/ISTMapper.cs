using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ST.Shared.Contract
{
    public interface ISTMapper<TSource, TDestination> where TDestination : new()
    {
        TDestination Map(TSource source); 
        void Map(TSource source,TDestination target);
        IEnumerable<TDestination> Map(IEnumerable<TSource> source);
        IQueryable<TDestination> Map(IQueryable<TSource> source);
        Expression<Func<TSource, TDestination>> GetMapExpression();
    }
}
