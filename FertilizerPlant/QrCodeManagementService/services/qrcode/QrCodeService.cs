using QrCodeManagementService.entities.qrcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeManagementService.services.qrcode
{
    public interface QrCodeService
    {
        void Add(QrCodeModel qrCode);
        /// <summary>
        /// Update actually do the update model
        /// </summary>
        /// <param name="qrCode"></param>
        void Update(QrCodeModel qrCode);

        QrCodeModel FindById(string qrCodeId);


    }
}
