using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Berg8.Core.Domain;

namespace Berg8.Core.Data
{
    public interface IReadOnlyRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> AsQueryable();

        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
