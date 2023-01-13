using System.Linq.Expressions;

namespace Gestion_note.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();  
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);

        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity>  entity);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entity);

    }
}
