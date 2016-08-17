using ProductManagementService.entities.stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.entities.warehouse
{
    public class WarehouseModel
    {
        private int id;
        /// <summary>
        /// address of the warehouse
        /// </summary>
        private string address;
        /// <summary>
        /// this is the stock levels of the warehouse
        /// </summary>
        private IList<StockLevelModel> stockLevels = new List<StockLevelModel>();

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

        public virtual string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
    }
}
