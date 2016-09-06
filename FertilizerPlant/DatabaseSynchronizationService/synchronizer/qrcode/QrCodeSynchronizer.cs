using DatabaseSynchronizationService.synchronizer.qrcode;
using DatabaseSynchronizationService.synchronizer.syncdata;
using DatabaseSynchronizationService.util;
using QrCodeManagementService.entities.qrcode;
using QrCodeManagementService.services.qrcode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseSynchronizationService.qrcode.synchronizer
{
    public class QrCodeSynchronizer
    {
        private QrCodeService qrCodeService;

        public QrCodeSynchronizer()
        {
            qrCodeService = new DefaultQrCodeService();
        }
        /// <summary>
        /// This method synchronize qrcodes from remote to local
        /// </summary>
        public void SynchronizeQrCodesFromRemoteToLocalSync(string qrCodeSyncURL)
        {
            List<QrCodeModel> qrcodes = SynchronizerExtension.FetchEntitiesFromRemoteSync<QrCodeModel>(qrCodeSyncURL);
            if (qrcodes.Count > 0)
            {
                qrCodeService.BulkSave(qrcodes);
                SendQrCodesSynchedStatus(qrcodes, qrCodeSyncURL);
            }
        }

        public void SendQrCodesSynchedStatus(List<QrCodeModel> qrcodes, string qrCodePostURL)
        {
            List<QrCodeSyncDataUpStream> syncStatues = new List<QrCodeSyncDataUpStream>();
            foreach (QrCodeModel model in qrcodes)
            {
                QrCodeSyncDataUpStream syncStatus = new QrCodeSyncDataUpStream { Id = model.EncodedValue, SyncStatus = true };
                syncStatues.Add(syncStatus);
            }
            SynchronizerExtension.SendSynchStatusOkayToRemote<QrCodeSyncDataUpStream>(qrCodePostURL, syncStatues);
        }

        public void StartSyncProductDistributorBindingDataToServerJob(string qrCodePostURL)
        {
            int interval = Convert.ToInt32(ConfigurationManager.AppSettings["binding_info_sync_job_time_interval"]);
            while (true)
            {
                SynchronizeBindingInforForQrToServer(qrCodePostURL);
                Thread.Sleep(interval);
            }
        }

        private void SynchronizeBindingInforForQrToServer(string qrCodePostURL)
        {
            List<QrCodeModel> qrcodes = qrCodeService.FindAllUnsynchedBindedQrCodes();
            List<QrCodeSyncDataUpStream> syncStatues = new List<QrCodeSyncDataUpStream>();
            foreach (QrCodeModel model in qrcodes)
            {
                QrCodeSyncDataUpStream syncStatus = new QrCodeSyncDataUpStream { Id = model.EncodedValue, ProductId = model.Product.ProductName,DistributorId = model.Distributor.Name,SyncStatus=true};
                syncStatues.Add(syncStatus);
            }
            if(SynchronizerExtension.SendSynchStatusOkayToRemote<QrCodeSyncDataUpStream>(qrCodePostURL, syncStatues))
            {
                foreach(QrCodeModel model in qrcodes)
                {
                    model.SyncStatus = true;
                }
                qrCodeService.BulkSave(qrcodes);
            }
        }
    }
}
