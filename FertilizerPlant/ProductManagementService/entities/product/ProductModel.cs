using ProductManagementService.entities.brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.entities.produt
{
    public class ProductModel
    {
        private long id;
        private string product_name;
        private BrandModel brand;
        private string unitName;
        private int quantity;

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

        public virtual string Product_name
        {
            get
            {
                return product_name;
            }

            set
            {
                product_name = value;
            }
        }

        public virtual BrandModel Brand
        {
            get
            {
                return brand;
            }

            set
            {
                brand = value;
            }
        }

        public virtual string UnitName
        {
            get
            {
                return unitName;
            }

            set
            {
                unitName = value;
            }
        }

        public virtual int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
    }
}
