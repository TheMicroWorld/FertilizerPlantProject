using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeManagementService.services.binding
{
    public interface BindingService
    {
        void BindProductWithDistributor(string qrCodeId, string productNameId, string distributorId);
    }
}
