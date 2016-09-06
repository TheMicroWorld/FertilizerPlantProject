using ProductManagementService.entities.produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.entities.distributors;

namespace QrCodeManagementService.entities.qrcode
{
    public class QrCodeModel
    {
        /// <summary>
        /// encoded value is going to be the primary key
        /// </summary>
        private string encodedValue;
        /// <summary>
        /// Many to one 
        /// </summary>
        private ProductModel product;
        /// <summary>
        /// Many to one
        /// </summary>
        private DistributorModel distributor;

        private bool syncStatus = false;

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

        public virtual ProductModel Product
        {
            get
            {
                return product;
            }

            set
            {
                product = value;
            }
        }

        public virtual DistributorModel Distributor
        {
            get
            {
                return distributor;
            }

            set
            {
                distributor = value;
            }
        }

        public virtual bool SyncStatus
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
