using DatabaseSynchronizationService.synchronizer.syncdata;
using DatabaseSynchronizationService.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;
using UserManagementService.services.distributors;

namespace DatabaseSynchronizationService.distributor.synchronizer
{
    public class DistributorSynchronizer
    {
        private DistributorService distributorService;

        public DistributorSynchronizer()
        {
            distributorService = new DefaultDistributorService();
        }
        /// <summary>
        /// This method will synchronize distributors from remote to local
        /// </summary>
        public  void SynchronizeDistributorsFromRemoteToLocalSync(string distributorSyncURL)
        {
            List<DistributorModel> distributors =  SynchronizerExtension.FetchEntitiesFromRemoteSync<DistributorModel>(distributorSyncURL);
            //Console.WriteLine(distributors[0].Address);
            if (distributors.Count > 0)
            {
                distributorService.BulkSave(distributors);
                SendDistributorsSynchedStatus(distributors,distributorSyncURL);
            }
        }

        public void SendDistributorsSynchedStatus(List<DistributorModel> distributors, string distributorPostURL)
        {
            List<BaseSyncDataUpStream> syncStatues = new List<BaseSyncDataUpStream>();
            foreach (DistributorModel model in distributors)
            {
                BaseSyncDataUpStream syncStatus = new BaseSyncDataUpStream { Id = model.Name, SyncStatus = true };
                syncStatues.Add(syncStatus);
            }
            SynchronizerExtension.SendSynchStatusOkayToRemote<BaseSyncDataUpStream>(distributorPostURL, syncStatues);
        }
    }
}
