using ProductManagementService.entities.produt;
using ProductManagementService.services;
using QrCodeManagementService.entities.qrcode;
using QrCodeManagementService.services.qrcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;
using UserManagementService.services.distributors;

namespace QrCodeManagementService.services.binding
{
    public class DefaultBindingService : BindingService
    {
        private readonly object lockObject = new object();
        private IList<string> collectedQrCodes;
        private ProductService productService;
        private DistributorService distributorService;
        private QrCodeService qrCodeService;
        public void BindProductToDistributor(string qrCode, string productName, string distributorName)
        {
            QrCodeModel qrCodeModel = qrCodeService.FindById(qrCode);
            ProductModel product = productService.FindByProductName(productName);
            DistributorModel distributor = distributorService.FindByDistributorByName(distributorName);
            qrCodeModel.Distributor = distributor;
            qrCodeModel.Product = product;
            qrCodeService.Update(qrCodeModel);
        }

        public void StartBackgroundBindingThread()
        {
            Thread thread = new Thread(() => StartBinding());
            thread.Start();
        }

        public DefaultBindingService()
        {
            StartBackgroundBindingThread();
        }

        private void StartBinding()
        {
            lock (lockObject)
            {
                if (collectedQrCodes.Count == 0)
                {
                    Monitor.Wait(lockObject);
                }
                //I need to get the selected product,and distributor
                string qrCode = collectedQrCodes[collectedQrCodes.Count - 1];
                collectedQrCodes.RemoveAt(collectedQrCodes.Count - 1);

            }
        }
    }
}
