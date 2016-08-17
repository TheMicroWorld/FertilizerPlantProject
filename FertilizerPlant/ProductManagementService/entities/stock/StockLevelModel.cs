using ProductManagementService.entities.produt;
using ProductManagementService.entities.warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.entities.stock
{
    public class StockLevelModel
    {
        private int id;
        /// <summary>
        /// this field is the stock level
        /// </summary>
        private int amount;
        /// <summary>
        /// actually stock level with product is many to one relation.We used
        /// many to many in order to create intermediate table
        /// </summary>
        private IList<ProductModel> products = new List<ProductModel>();
        /// <summary>
        /// same as product
        /// </summary>
        private IList<WarehouseModel> warehouses = new List<WarehouseModel>();

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

        public virtual int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
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

        public virtual IList<WarehouseModel> Warehouses
        {
            get
            {
                return warehouses;
            }

            set
            {
                warehouses = value;
            }
        }
    }
}
