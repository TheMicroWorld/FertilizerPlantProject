using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementService.entities.warehouse;
using Core.Persistence.NHibernate.UnitOfWork;
using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.Generic.Repositories;
using Core.Persistence.NHibernate.Repositories;

namespace ProductManagementService.services.warehouse
{
    public class DefaultWarehouseService : WarehouseService
    {
        public void Add(WarehouseModel warehouse)
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<WarehouseModel, int> warehouseRepository = new NHibernateRepository<WarehouseModel, int>(unitOfWork);
            warehouseRepository.Add(warehouse);
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
    }
}
