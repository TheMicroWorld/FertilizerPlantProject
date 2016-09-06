using ProductManagementService.entities.stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.entities.produt
{
    public class ProductModel
    {
        /// <summary>
        /// product brand.One brand can have many products
        /// </summary>
        private string brandName;
        /// <summary>
        /// product name
        /// </summary>
        private string productName;
        /// <summary>
        /// product specification
        /// </summary>
        private string specification;
        private string unitName;


        /// <summary>
        /// one product can have many stock level in different warehouses
        /// </summary>
        private IList<StockLevelModel> stockLevels = new List<StockLevelModel>();

        public virtual string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
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

        public virtual IList<StockLevelModel> StockLevels
        {
            get
            {
                return stockLevels;
            }

            set
            {
                stockLevels = value;
            }
        }

        public virtual string BrandName
        {
            get
            {
                return brandName;
            }

            set
            {
                brandName = value;
            }
        }

        public virtual string Specification
        {
            get
            {
                return specification;
            }

            set
            {
                specification = value;
            }
        }
    }
}
