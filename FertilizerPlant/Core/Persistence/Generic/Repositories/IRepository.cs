using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Persistence.Generic.Repositories
{
    public interface IRepository<TEntity,in TKey> where TEntity : class
    {
        TEntity Get(TKey id);


        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);
        void Remove(TEntity entity);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
  
    }
}
