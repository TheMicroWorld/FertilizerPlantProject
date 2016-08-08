using Core.Persistence.Generic.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.NHibernate.Repositories
{
    class NHibernateRepository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class
    {
        private readonly ISession session;

        public NHibernateRepository(ISession session)
        {
            this.session = session;
        }

        protected ISession Session
        {
            get
            {
                return session;
            }
        }
        public TEntity Get(TKey id)
        {
            return session.Get<TEntity>(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return session.CreateQuery("from " + typeof(TEntity)).List<TEntity>();
        }

        public void Add(TEntity entity)
        {
            session.SaveOrUpdate(entity);
        }

        public  void Remove(TEntity entity)
        {
            session.Delete(entity);
        }

    }
}
