using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.UnitOfWork.Factories;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using ProductManagementService.entities.product;
using ProductManagementService.entities.produt;
using ProductManagementService.entities.stock;
using ProductManagementService.entities.warehouse;
using ProductManagementService.services;
using ProductManagementService.services.product;
using ProductManagementService.services.stock;
using ProductManagementService.services.warehouse;
using QrCodeManagementService.entities.qrcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;

namespace FertilizerPlantWindowsTest.products
{
    [TestFixture]
    public class FertilizerPlantTest
    {
        private ProductService productService;
        private StockLevelService stockLevelService;
        private WarehouseService warehouseService;
        
        [SetUp]
        public void SetUp()
        {
            productService = new DefaultProductService();
            stockLevelService = new DefaultStockLevelService();
            warehouseService = new DefaultWarehouseService();
            ConfigureHibernateMapping();
        }
        [Test]
        public void CreateDatabaseSchemaTest()
        {
            ProductModel product = new ProductModel();
            StockLevelModel stockLevel1 = new StockLevelModel();
            stockLevel1.Amount = 10;
            stockLevel1.Products.Add(product);
            product.ProductName = "可口可乐";
            product.UnitName = "瓶子";
            product.StockLevels.Add(stockLevel1);
            productService.Add(product);
            stockLevelService.Add(stockLevel1);

            WarehouseModel warehouse = new WarehouseModel();
            warehouse.Address = "chengdu shi";
            warehouse.StockLevels.Add(stockLevel1);
            stockLevel1.Warehouses.Add(warehouse);

            warehouseService.Add(warehouse);
        }
        private void ConfigureHibernateMapping()
        {
            Configuration hibernateConfig = (UnitOfWork.UnitOfWorkFactory as NHibernateUnitOfWorkFactory).Configuration;
            var mapper = new ModelMapper();
            mapper.AddMappings(typeof(ProductModelMap).Assembly.GetExportedTypes());
            mapper.AddMappings(typeof(DistributorModelMap).Assembly.GetExportedTypes());
            mapper.AddMappings(typeof(QrCodeModel).Assembly.GetExportedTypes());

            hibernateConfig.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), "FertilizerPlantScheme");
            SchemaExport schema = new SchemaExport(hibernateConfig);
            schema.Create(false, true);
        }
    }
}
