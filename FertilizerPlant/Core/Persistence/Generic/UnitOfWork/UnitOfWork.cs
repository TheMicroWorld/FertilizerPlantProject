using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Generic.UnitOfWork.Factories;
using Core.Persistence.NHibernate.UnitOfWork.Factories;

namespace Core.Persistence.Generic.UnitOfWork
{
    public static class UnitOfWork
    {
        private static IUnitOfWorkFactory unitOfWorkFactory = new NHibernateUnitOfWorkFactory();
        private static IUnitOfWork innerUnitOfWork;
        public static IUnitOfWork Start()
        {
            if (innerUnitOfWork != null)
                throw new InvalidOperationException("You can not start more than one unit of work at the same time");
            innerUnitOfWork = unitOfWorkFactory.Create();
            return innerUnitOfWork;
        }
        public static IUnitOfWork Current
        {
            get
            {
                if (innerUnitOfWork == null)
                    throw new InvalidOperationException("You are not in a unit of work");
                return innerUnitOfWork;
            }
        }
        public static bool IsStarted
        {
            get { return innerUnitOfWork != null; }
        }
    }
}
