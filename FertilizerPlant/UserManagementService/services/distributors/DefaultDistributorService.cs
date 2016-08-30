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
using UserManagementService.services.users;

namespace UserManagementService.services.distributors
{
    public class DefaultDistributorService : DefaultUserService,DistributorService
    {
        public void Add(DistributorModel distributor)
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<DistributorModel, int> distributorRepository = new NHibernateRepository<DistributorModel, int>(unitOfWork);
            distributorRepository.Add(distributor);
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }

        public DistributorModel FindDistributorByName(string distributorName)
        {
            return new DistributorModel();
        }

        public IList<string> GetAllDistributorNames()
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<DistributorModel, int> distributorRepository = new NHibernateRepository<DistributorModel, int>(unitOfWork);
            IList<DistributorModel> distributors = (List<DistributorModel>)distributorRepository.GetAll();
            IList<string> distributorNames = distributors.Select(d => d.Name).ToList();
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
            return distributorNames;
        }
    }
}
