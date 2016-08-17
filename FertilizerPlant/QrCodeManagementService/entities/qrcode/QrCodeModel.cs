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
        private IList<ProductModel> products;
        /// <summary>
        /// Many to one
        /// </summary>
        private IList<DistributorModel> distributors;

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

        public virtual IList<ProductModel> Products
        {
            get
            {
                return products;
            }

            set
            {
                products = value;
            }
        }

        public virtual IList<DistributorModel> Distributors
        {
            get
            {
                return distributors;
            }

            set
            {
                distributors = value;
            }
        }
    }
}
