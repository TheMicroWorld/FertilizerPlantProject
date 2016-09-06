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
        private IRepository<DistributorModel, string> distributorRepository;
        private NHibernateUnitOfWork unitOfWork;

        private void StartNewUnitOfWork()
        {
            unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            distributorRepository = new NHibernateRepository<DistributorModel, string>(unitOfWork);
        }
        private void EndUnitOfWork()
        {
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }

        public void Add(DistributorModel distributor)
        {
            StartNewUnitOfWork();
            distributorRepository.Add(distributor);
            EndUnitOfWork();
        }

        public IList<string> GetAllDistributorNames()
        {
            StartNewUnitOfWork();
            IList<DistributorModel> distributors = distributorRepository.GetAll().ToList();
            IList<string> distributorNames = distributors.Select(d => d.Name).ToList();
            EndUnitOfWork();
            return distributorNames;
        }

        public void BulkSave(IList<DistributorModel> distributors)
        {
            StartNewUnitOfWork();
            distributorRepository.BulkSave(distributors);
            EndUnitOfWork();
        }

        public DistributorModel FindById(string id)
        {
            StartNewUnitOfWork();
            DistributorModel qrCodeModel = distributorRepository.Get(id);
            EndUnitOfWork();
            return qrCodeModel;
        }
    }
}
