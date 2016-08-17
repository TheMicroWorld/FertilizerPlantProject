using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.entities.stock
{
    public class StockLevelModelMap : ClassMapping<StockLevelModel>
    {
        public StockLevelModelMap()
        {
            Table("StockLevels");
            Id(c => c.Id, map => map.Generator(Generators.Identity));
            Property(c => c.Amount);
            Bag(c => c.Products, map =>
            {
                map.Table("ProductStockLevels");
                map.Key(k => k.Column("StockLevelId"));
            }, rel => rel.ManyToMany(m => m.Column("ProductId")));
            Bag(c => c.Warehouses, map =>
            {
                map.Table("WarehouseStockLevels");
                map.Key(k => k.Column("StockLevelId"));
            }, rel => rel.ManyToMany(m => m.Column("WarehouseId")));
        }
    }
}
