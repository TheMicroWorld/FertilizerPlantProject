using Core.Persistence.Generic.Repositories;
using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.Repositories;
using Core.Persistence.NHibernate.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.users;

namespace UserManagementService.services.users
{
    public class DefaultUserService : UserService
    {
        private IRepository<UserModel, int> userRepository;
        private NHibernateUnitOfWork unitOfWork;

        private void StartNewUnitOfWork()
        {
            unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            userRepository = new NHibernateRepository<UserModel, int>(unitOfWork);
        }
        private void EndUnitOfWork()
        {
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }

        public void Add(UserModel user)
        {
            StartNewUnitOfWork();
            userRepository.Add(user);
            EndUnitOfWork();
        }

        public void BulkSave(IList<UserModel> users)
        {
            StartNewUnitOfWork();
            userRepository.BulkSave(users);
            EndUnitOfWork();
        }
    }
}
