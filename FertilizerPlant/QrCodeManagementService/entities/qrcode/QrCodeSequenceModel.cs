using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeManagementService.entities.qrcode
{
    public class QrCodeSequenceModel
    {
        private long id;
        private string encodedValue;

        public virtual long Id
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

        public virtual string EncodedValue
        {
            get
            {
                return encodedValue;
            }

            set
            {
                encodedValue = value;
            }
        }
    }
}
