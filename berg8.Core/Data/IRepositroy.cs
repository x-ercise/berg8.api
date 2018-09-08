using System.Collections.Generic;
using Berg8.Core.Domain;

namespace Berg8.Core.Data
{
    public interface IRepositroy<TEntity> : IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}