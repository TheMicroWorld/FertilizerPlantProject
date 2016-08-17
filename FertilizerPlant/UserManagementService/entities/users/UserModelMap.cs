using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.users
{
    public class UserModelMap : ClassMapping<UserModel>
    {
        public UserModelMap()
        {
            Table("Users");
            Id(c => c.Id, map => map.Generator(Generators.Identity));
            Property(c => c.Address);
            Property(c => c.CellPhone);
            Property(c => c.Name);
            Discriminator(c =>
            {
                c.Column("Discriminator");
            });
        }
    }
}
