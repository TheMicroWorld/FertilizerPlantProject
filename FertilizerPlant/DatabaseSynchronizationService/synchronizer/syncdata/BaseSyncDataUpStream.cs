using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSynchronizationService.synchronizer.syncdata
{
    /// <summary>
    /// this data structure is used to send back to server when we pulled down the unsynched data.
    /// Ex when a certain ProductModel is synced,we have to send the product id back to server to 
    /// make it mark that product item is synched.The next time,server will not send the already 
    /// synced item again
    /// </summary>
    public class BaseSyncDataUpStream
    {
        /// <summary>
        /// this is the primary key of the synched item
        /// </summary>
        private string id;
        /// <summary>
        /// send the synched status back to server
        /// </summary>
        private bool syncStatus;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool SyncStatus
        {
            get
            {
                return syncStatus;
            }

            set
            {
                syncStatus = value;
            }
        }
    }
}
