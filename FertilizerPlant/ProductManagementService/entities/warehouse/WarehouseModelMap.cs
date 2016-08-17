using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.entities.warehouse
{
    public class WarehouseModelMap : ClassMapping<WarehouseModel>
    {
        public WarehouseModelMap()
        {
            Table("Warehouses");
            Id(c => c.Id, map => map.Generator(Generators.Identity));
            Property(c => c.Address);
            Bag(c => c.StockLevels, map =>
            {
                map.Table("WarehouseStockLevels");
                map.Key(k => k.Column("WarehouseId"));
            }, rel => rel.ManyToMany(m => m.Column("StockLevelId")));
        }
    }
}
