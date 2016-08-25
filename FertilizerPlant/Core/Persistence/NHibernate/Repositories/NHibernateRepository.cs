using Core.Persistence.Generic.Repositories;
using Core.Persistence.NHibernate.UnitOfWork;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Core.Persistence.NHibernate.Repositories
{
    public class NHibernateRepository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class
    {
        private readonly ISession session;
        private readonly NHibernateUnitOfWork unitOfWork;

        public NHibernateRepository(NHibernateUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.session = unitOfWork.Session;
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

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
