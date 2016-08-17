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
        public void Add(UserModel user)
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<UserModel, int> userRepository = new NHibernateRepository<UserModel, int>(unitOfWork);
            userRepository.Add(user);
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
    }
}
