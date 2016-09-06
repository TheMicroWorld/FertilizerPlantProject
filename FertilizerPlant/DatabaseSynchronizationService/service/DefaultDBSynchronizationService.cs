using DatabaseSynchronizationService.distributor.synchronizer;
using DatabaseSynchronizationService.product.synchronizer;
using DatabaseSynchronizationService.qrcode.synchronizer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseSynchronizationService.service
{
    public class DefaultDBSynchronizationService : DBSynchronizationService
    {
        private static string SERVER_IP = ConfigurationManager.AppSettings["SERVER_IP"];
        private static string SERVER_PORT = ConfigurationManager.AppSettings["SERVER_PORT"];
        private static string PROTOCOL = "http:";
        private static string PRODUCT_SYNC_URL = PROTOCOL + "//" + SERVER_IP + ":" + SERVER_PORT + "/synchronization/products";
        private static string QRCODE_SYNC_URL = PROTOCOL + "//" + SERVER_IP + ":" + SERVER_PORT + "/synchronization/qrcodes";
        private static string DISTRIBUTOR_SYNC_URL = PROTOCOL + "//" + SERVER_IP + ":" + SERVER_PORT + "/synchronization/distributors";

        private ProductSynchronizer productSynchronizer;
        private DistributorSynchronizer distributorSynchronizer;
        private QrCodeSynchronizer qrcodeSynchronizer;

        public DefaultDBSynchronizationService()
        {
            productSynchronizer = new ProductSynchronizer();
            distributorSynchronizer = new DistributorSynchronizer();
            qrcodeSynchronizer = new QrCodeSynchronizer();
        }

        /// <summary>
        /// Start a job that synchronize remote database to local database
        /// </summary>
        public void SynchronizeRemoteToLocalDatabase()
        {
             productSynchronizer.SynchronizeProductsFromRemoteToLocalSync(PRODUCT_SYNC_URL);
             distributorSynchronizer.SynchronizeDistributorsFromRemoteToLocalSync(DISTRIBUTOR_SYNC_URL);
             qrcodeSynchronizer.SynchronizeQrCodesFromRemoteToLocalSync(QRCODE_SYNC_URL);
        }
        /// <summary>
        /// Start a background job that synchronize local database to remote database
        /// Here we only synchronize local qrcode table to remote database
        /// </summary>
        public  void SynchronizeQrCodeBindingInfoToRemoteDatabase()
        {
            Thread thread = new Thread(() => qrcodeSynchronizer.StartSyncProductDistributorBindingDataToServerJob(QRCODE_SYNC_URL));
            thread.Start();
        }

        public void SynchronizeLocalToRemoteDatabase()
        {
            SynchronizeQrCodeBindingInfoToRemoteDatabase();
        }
    }
}
