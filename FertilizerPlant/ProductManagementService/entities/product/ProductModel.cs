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
        private int id;
        /// <summary>
        /// product name
        /// </summary>
        private string productName;
        private string unitName;

        /// <summary>
        /// one product can have many stock level in different warehouses
        /// </summary>
        private IList<StockLevelModel> stockLevels = new List<StockLevelModel>();
        public virtual int Id
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
    }
}
