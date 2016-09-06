using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Persistence.Generic.Repositories
{
    public interface IRepository<TEntity,in TKey> where TEntity : class
    {
        TEntity Get(TKey id);


        IList<TEntity> GetAll();

        void Add(TEntity entity);
        void Remove(TEntity entity);

        IList<TEntity> BulkSave(IList<TEntity> entities);

        TEntity FindBy(Expression<Func<TEntity, bool>> expression);

        IList<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
    }
}
