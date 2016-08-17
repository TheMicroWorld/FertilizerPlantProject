using Core.Persistence.Generic.Repositories;
using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.Repositories;
using Core.Persistence.NHibernate.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;

namespace UserManagementService.services.distributors
{
    public class DefaultDistributorService
    {
        public void Add(DistributorModel distributor)
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<DistributorModel, int> distributorRepository = new NHibernateRepository<DistributorModel, int>(unitOfWork);
            distributorRepository.Add(distributor);
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
    }
}
