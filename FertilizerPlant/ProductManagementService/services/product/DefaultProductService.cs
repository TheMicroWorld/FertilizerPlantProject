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
            productRepository.Add(product);
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }

        /// <summary>
        /// This function will try to find the product by name.Actually i should set the product name as the primary key
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        public ProductModel FindByProductName(string productName)
        {
            return new entities.produt.ProductModel();
        }

        public IList<ProductModel> GetAll()
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<ProductModel, int> productRepository = new NHibernateRepository<ProductModel, int>(unitOfWork);
            IList<ProductModel> products = (List<ProductModel>)productRepository.GetAll();
            unitOfWork.SaveChanges();//do the commit
            unitOfWork.Dispose();//dispose unitOfWork
            return products;
        }

        public IList<string> GetAllProductNames()
        {
            NHibernateUnitOfWork unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            IRepository<ProductModel, int> productRepository = new NHibernateRepository<ProductModel, int>(unitOfWork);
            IList<ProductModel> products = (List<ProductModel>)productRepository.GetAll();
            IList<string> productNames = products.Select(p => p.ProductName).ToList();
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
            return productNames;
        }
    }
}
