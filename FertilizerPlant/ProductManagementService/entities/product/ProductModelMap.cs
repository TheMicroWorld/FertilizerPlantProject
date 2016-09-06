using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProductManagementService.entities.produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementService.entities.product
{
    public class ProductModelMap : ClassMapping<ProductModel>
    {
        public ProductModelMap()
        {
            Table("Products");
            Id(c => c.ProductName, map =>
            {
                map.Generator(Generators.Assigned);
                map.Column("ProductId");
            });
            Property(c=>c.BrandName);
            Property(c => c.Specification);
            Property(c => c.UnitName);
            Bag(c => c.StockLevels, map =>
            {
                map.Table("ProductStockLevels");
                map.Key(k => k.Column("ProductId"));
                map.Cascade(Cascade.Persist);
                map.Inverse(true);
            }, rel => rel.ManyToMany(m => m.Column("StockLevelId")));
        }
    }
}
