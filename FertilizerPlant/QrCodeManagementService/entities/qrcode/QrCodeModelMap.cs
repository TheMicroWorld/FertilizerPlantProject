using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
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
            Property(c => c.SyncStatus, map => map.Type<YesNoType>());
            ManyToOne(c => c.Product, map =>
            {
                map.Column("ProductId");
            });
            ManyToOne(c => c.Distributor, map => map.Column("DistributorId"));
        }
    }
}
