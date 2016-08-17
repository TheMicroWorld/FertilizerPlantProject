using Core.Persistence.Generic.Repositories;
using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.Repositories;
using Core.Persistence.NHibernate.UnitOfWork;
using ProductManagementService.entities.stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.services.stock
{
    public class DefaultStockLevelService : StockLevelService
    {
        public void Add(StockLevelModel stockLevel)
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<StockLevelModel, int> stockLevelRepository = new NHibernateRepository<StockLevelModel, int>(unitOfWork);
            stockLevelRepository.Add(stockLevel);
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
    }
}
