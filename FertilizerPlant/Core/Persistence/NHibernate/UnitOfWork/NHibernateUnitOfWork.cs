using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.Generic.UnitOfWork.Factories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.NHibernate.UnitOfWork
{
    public class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory; 
        private readonly ISession session;
        public ITransaction transaction;

        public ISession Session
        {
            get
            {
                return session;
            }
        }

        public NHibernateUnitOfWork(IUnitOfWorkFactory unitOfWorkFactory,ISession session)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.session = session;
            session.FlushMode = FlushMode.Auto;
        }

        /// <summary>
        /// Starts a transaction with the database. Uses IsolationLevel.ReadCommitted
        /// </summary>
        public void BeginTransaction()
        {
            transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        /// <summary>
        /// starts a transaction with the database.
        /// </summary>
        /// <param name="level">IsolationLevel the transaction should run in.</param>
        public void BeginTransaction(IsolationLevel level)
        {
            transaction = Session.BeginTransaction(level);
        }

        private bool IsTransactionActive()
        {
            return transaction.IsActive;
        }

        /// <summary>
        /// Commits the transaction and writes to the database.
        /// </summary>
        public void Commit()
        {
            // make sure a transaction was started before we try to commit.
            if (!IsTransactionActive())
            {
                throw new InvalidOperationException("Oops! We don't have an active transaction. Did a rollback occur before this commit was triggered: "
                                                            + transaction.WasRolledBack + " did a commit happen before this commit: " + transaction.WasCommitted);
            }

            transaction.Commit();
        }

        /// <summary>
        /// Rollback any writes to the databases.
        /// </summary>
        public void Rollback()
        {
            if (IsTransactionActive())
            {
                transaction.Rollback();
            }
        }

        public void Dispose() // don't know where to call this to see if it will solve my problem
        {
            if (Session.IsOpen)
            {
                Session.Close();
            }
        }

        public void SaveChanges()
        {
            Commit();
        }
    }
}
