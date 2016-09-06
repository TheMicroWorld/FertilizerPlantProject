using FertilizerPlant.global.context;
using NUnit.Framework;
using ProductManagementService.entities.produt;
using ProductManagementService.services;
using ProductManagementService.services.product;
using ProductManagementService.services.stock;
using ProductManagementService.services.warehouse;
using QrCodeManagementService.entities.qrcode;
using QrCodeManagementService.services.binding;
using QrCodeManagementService.services.qrcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;
using UserManagementService.services.distributors;

namespace FertilizerPlantWindowsTest.qrcode.binding
{
    public class BindingServiceTest
    {
        private ProductService productService;
        private DistributorService distributorService;
        private QrCodeService qrcodeService;
        private ApplicationContext applicationContext;
        private BindingService bindingService;

        [SetUp]
        public void SetUp()
        {
            productService = new DefaultProductService();
            distributorService = new DefaultDistributorService();
            qrcodeService = new DefaultQrCodeService();
            bindingService = new DefaultBindingService();
            applicationContext = new ApplicationContext();
            applicationContext.ConfigureHibernateMapping();
        }

        [Test]
        public void TestBindingService()
        {
            string qrcode = "http://192.168.1.101:8080/qrcode-manage/0";
            string distributorName = "河北";
            string productName = "咳咳音乐";
            QrCodeModel qrcodeModel = qrcodeService.FindById(qrcode);
            DistributorModel distributorModel = distributorService.FindById(distributorName);
            ProductModel productModel = productService.FindById(productName);

            qrcodeModel.Distributor = distributorModel;
            qrcodeModel.Product = productModel;

            qrcodeService.Add(qrcodeModel);
        }
    }
}
