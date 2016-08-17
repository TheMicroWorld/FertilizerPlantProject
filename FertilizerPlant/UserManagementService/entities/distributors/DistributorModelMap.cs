using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.entities.distributors
{
    public class DistributorModelMap : SubclassMapping<DistributorModel>
    {
        public DistributorModelMap()
        {
            DiscriminatorValue("Distributor");
        }
    }
}
