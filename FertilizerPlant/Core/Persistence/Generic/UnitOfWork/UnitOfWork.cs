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

        public static IUnitOfWorkFactory UnitOfWorkFactory
        {
            get
            {
                return unitOfWorkFactory;
            }
        }

        public static IUnitOfWork Start()
        {
            IUnitOfWork unitOfWork = UnitOfWorkFactory.Create();
            return unitOfWork;
        }
    }
}
