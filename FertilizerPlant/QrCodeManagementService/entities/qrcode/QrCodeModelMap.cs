using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeManagementService.entities.qrcode
{
    public class QrCodeModelMap : ClassMapping<QrCodeModel>
    {
        public QrCodeModelMap()
        {
            Table("QrCodes");
            Id(c => c.EncodedValue, map =>
            {
                map.Generator(Generators.Assigned);
                map.Column("QrCodeId");
            });
            ManyToOne(c => c.Products, map => map.Column("ProductId"));
            ManyToOne(c => c.Distributors, map => map.Column("DistributorId"));
        }
    }
}
