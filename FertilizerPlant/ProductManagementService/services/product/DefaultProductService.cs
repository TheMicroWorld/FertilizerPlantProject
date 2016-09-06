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
        private IRepository<ProductModel,string> productRepository;
        private NHibernateUnitOfWork unitOfWork;

        private void StartNewUnitOfWork()
        {
            unitOfWork = (NHibernateUnitOfWork)UnitOfWork.Start();
            productRepository = new NHibernateRepository<ProductModel, string>(unitOfWork);
        }
        private void EndUnitOfWork()
        {
            unitOfWork.SaveChanges();
            unitOfWork.Dispose();
        }
        public void Add(ProductModel product)
        {
            StartNewUnitOfWork();
            productRepository.Add(product);
            EndUnitOfWork();
        }

        public IList<ProductModel> GetAll()
        {
            StartNewUnitOfWork();
            IList<ProductModel> products = (List<ProductModel>)productRepository.GetAll();
            EndUnitOfWork();
            return products;
        }

        public IList<string> GetAllProductNames()
        {
            StartNewUnitOfWork();
            IList<ProductModel> products = productRepository.GetAll().ToList();
            IList<string> productNames = products.Select(p => p.ProductName).ToList();
            EndUnitOfWork();
            return productNames;
        }
        public void BulkSave(IList<ProductModel> products)
        {
            StartNewUnitOfWork();
            productRepository.BulkSave(products);
            EndUnitOfWork();
        }

        public ProductModel FindById(string id)
        {
            StartNewUnitOfWork();
            ProductModel productModel = productRepository.Get(id);
            EndUnitOfWork();
            return productModel;
        }
    }
}
