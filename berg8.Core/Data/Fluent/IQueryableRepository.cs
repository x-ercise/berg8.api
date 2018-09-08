using Berg8.Core.Domain;

namespace Berg8.Core.Data.Fluent
{
    public interface IQueryableRepository<TEntity, out TQueryBuilder>
        where TEntity : BaseEntity
        where TQueryBuilder : class, IQueryBuilder<TEntity, TQueryBuilder>
    {
        TQueryBuilder Query();
    }
}
