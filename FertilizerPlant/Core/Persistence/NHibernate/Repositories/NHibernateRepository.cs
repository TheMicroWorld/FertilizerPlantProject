using Core.Persistence.Generic.Repositories;
using Core.Persistence.NHibernate.UnitOfWork;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.ObjectModel;
using System.Configuration;
using NHibernate.Criterion;

namespace Core.Persistence.NHibernate.Repositories
{
    public class NHibernateRepository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class
    {
        private int batchSize = Convert.ToInt32(ConfigurationManager.AppSettings["hibernate_batch_size"]);
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
        public IList<TEntity> GetAll()
        {
            return session.QueryOver<TEntity>().List();
        }

        public void Add(TEntity entity)
        {
            session.Merge(entity);
        }

        public  void Remove(TEntity entity)
        {
            session.Delete(entity);
        }

        public IList<TEntity> BulkSave(IList<TEntity> entities)
        {
            List<TEntity> savedEntities = new List<TEntity>(entities.Count);
            int i = 0;
            foreach(TEntity t in entities)
            {
                savedEntities.Add(session.Merge(t));
                i++;
                if(i % batchSize == 0)
                {
                    session.Flush();
                    session.Clear();
                }
            }
            return savedEntities;
        }

        public TEntity FindBy(Expression<Func<TEntity, bool>> expression)
        {
            return FilterBy(expression).FirstOrDefault();
        }

        public IList<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression)
        {
            return session.QueryOver<TEntity>().Where(expression).List();
        }
    }
}
