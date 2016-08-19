using System.Collections.Generic;
namespace Core.Persistence.Generic.Repositories
{
    public interface IRepository<TEntity,in TKey> where TEntity : class
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void Remove(TEntity entity);
  
    }
}
