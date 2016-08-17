using NUnit.Framework;
using ProductManagementService.services;
using ProductManagementService.services.product;
using ProductManagementService.services.stock;
using ProductManagementService.services.warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private void ConfigureHibernateMapping()
        {

        }
    }
}
