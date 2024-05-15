using System.Linq.Expressions;

namespace EFCorePlayground;

public static class QueryableExtensions
{
    public static IQueryable<TSource> If<TSource>(
        this IQueryable<TSource> source,
        bool condition,
        Func<IQueryable<TSource>, IQueryable<TSource>> queryable)
    {
        return condition ? queryable(source) : source;
    }
    
    public static IQueryable<TSource> And<TSource>(
        this IQueryable<TSource> source,
        Expression<Func<TSource, bool>> predicate)
    {
        ArgumentNullException.ThrowIfNull(source, nameof (source));
        ArgumentNullException.ThrowIfNull(predicate, nameof (predicate));
        
        return source.Provider.CreateQuery<TSource>(
            Expression.Call(null,
                new Func<IQueryable<TSource>, Expression<Func<TSource, bool>>,
                IQueryable<TSource>>(Queryable.Where).Method,
                source.Expression, Expression.Quote(predicate))
            );
    }

    public static IQueryable<TSource> Or<TSource>(this IQueryable<TSource> source,
        params Expression<Func<TSource, bool>>[] predicates)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(predicates, nameof(predicates));

        var parameter = Expression.Parameter(typeof(TSource), "x");
        var combined = predicates
            .Select(p => Expression.Invoke(p, parameter))
            .Aggregate<Expression>(
                Expression.OrElse);

        var body = Expression.Lambda<Func<TSource, bool>>(combined, parameter);

        return source.Provider.CreateQuery<TSource>(
            Expression.Call(
                typeof(Queryable),
                nameof(Queryable.Where),
                new[] { typeof(TSource) },
                source.Expression,
                Expression.Quote(body)
            )
        );
    }
}