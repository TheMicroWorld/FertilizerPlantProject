using Core.Persistence.Generic.UnitOfWork;
using Core.Persistence.NHibernate.UnitOfWork.Factories;
using FertilizerPlant.global.context;
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
using UserManagementService.services.distributors;

namespace FertilizerPlantWindowsTest.products
{
    [TestFixture]
    public class FertilizerPlantTest
    {
        private ProductService productService;
        private StockLevelService stockLevelService;
        private WarehouseService warehouseService;
        private DistributorService distributorService;
        private ApplicationContext applicationContext;
        
        [SetUp]
        public void SetUp()
        {
            productService = new DefaultProductService();
            stockLevelService = new DefaultStockLevelService();
            warehouseService = new DefaultWarehouseService();
            distributorService = new DefaultDistributorService();
            applicationContext = new ApplicationContext();
            applicationContext.Init();
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

            IList<string> productNames = productService.GetAllProductNames();
            Console.WriteLine(productNames);

            DistributorModel distributor = new DistributorModel();
            distributor.Name = "黄凯";
            distributor.Address = "贵州";

            distributorService.Add(distributor);

           IList<string> distributorNames = distributorService.GetAllDistributorNames();
           Console.WriteLine(distributorNames);
        }
    }
}
