using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeManagementService.services.binding
{
    public interface BindingService
    {
        bool bindProductToDistributor(string qrCode, string productName, string distributorName);
        void StartBindingService();
    }
}
