using DatabaseSynchronizationService.synchronizer.syncdata;
using DatabaseSynchronizationService.util;
using ProductManagementService.entities.produt;
using ProductManagementService.services;
using ProductManagementService.services.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSynchronizationService.product.synchronizer
{
    public class ProductSynchronizer
    {
        private ProductService productService;

        public ProductSynchronizer()
        {
            productService = new DefaultProductService();
        }
        /// <summary>
        /// this method synchornize products from remote to local
        /// </summary>
        public void SynchronizeProductsFromRemoteToLocalSync(string productGetURL)
        {
            List<ProductModel> products =  SynchronizerExtension.FetchEntitiesFromRemoteSync<ProductModel>(productGetURL);
            if(products.Count != 0)
            {
                productService.BulkSave(products);
                //after synchronizing from remote to local,we have to send the signal to remote that
                //we have synchronized the database.
                SendProductSynchedStatus(products, productGetURL);
            }
        }

        public void SendProductSynchedStatus(List<ProductModel> products,string productPostURL)
        {
            List<BaseSyncDataUpStream> syncStatues = new List<BaseSyncDataUpStream>();
            foreach(ProductModel model in products)
            {
                BaseSyncDataUpStream syncStatus = new BaseSyncDataUpStream { Id = model.ProductName, SyncStatus = true };
                syncStatues.Add(syncStatus);
            }
            SynchronizerExtension.SendSynchStatusOkayToRemote<BaseSyncDataUpStream>(productPostURL,syncStatues);
        }
    }
}
