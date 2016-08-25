using ProductManagementService.entities.produt;
using ProductManagementService.services;
using ProductManagementService.services.product;
using QrCodeManagementService.entities.qrcode;
using QrCodeManagementService.services.qrcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;
using UserManagementService.services.distributors;

namespace QrCodeManagementService.services.binding
{
    public class DefaultBindingService : BindingService
    {
        private ProductService productService;
        private DistributorService distributorService;
        private QrCodeService qrCodeService;
        public void BindProductWithDistributor(string qrCode, string productName, string distributorName)
        {
            QrCodeModel qrCodeModel = qrCodeService.FindById(qrCode);
            ProductModel product = productService.FindByProductName(productName);
            DistributorModel distributor = distributorService.FindDistributorByName(distributorName);
            qrCodeModel.Distributor = distributor;
            qrCodeModel.Product = product;
            qrCodeService.Update(qrCodeModel);
        }

        public DefaultBindingService()
        {
            productService = new DefaultProductService();
            distributorService = new DefaultDistributorService();
            qrCodeService = new DefaultQrCodeService();
        }
    }
}
