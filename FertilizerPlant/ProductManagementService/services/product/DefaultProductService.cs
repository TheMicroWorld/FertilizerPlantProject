using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementService.entities.produt;
using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.Repositories;
using Core.Persistence.Generic.Repositories;
using Core.Persistence.NHibernate.UnitOfWork;

namespace ProductManagementService.services.product
{
    public class DefaultProductService : ProductService
    {
        public void Add(ProductModel product)
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<ProductModel, int> productRepository = new NHibernateRepository<ProductModel, int>(unitOfWork);
        }

        public IList<ProductModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<string> GetAllProductNames()
        {
            throw new NotImplementedException();
        }
    }
}
