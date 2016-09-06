using DatabaseSynchronizationService.distributor.synchronizer;
using DatabaseSynchronizationService.product.synchronizer;
using DatabaseSynchronizationService.qrcode.synchronizer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSynchronizationService.service
{
    public interface DBSynchronizationService
    {
        void SynchronizeRemoteToLocalDatabase();
        void SynchronizeLocalToRemoteDatabase();
    }
}
