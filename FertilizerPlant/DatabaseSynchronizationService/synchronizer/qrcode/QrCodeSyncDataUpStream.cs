using DatabaseSynchronizationService.synchronizer.syncdata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSynchronizationService.synchronizer.qrcode
{
    public class QrCodeSyncDataUpStream : BaseSyncDataUpStream
    {
        /// <summary>
        /// we will jsonize this data,and send it to server.To make server know that
        /// this qrcode is binded with distributorId and productId
        /// </summary>
        private string distributorId;
        private string productId;

        public string DistributorId
        {
            get
            {
                return distributorId;
            }

            set
            {
                distributorId = value;
            }
        }

        public string ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
            }
        }
    }
}
