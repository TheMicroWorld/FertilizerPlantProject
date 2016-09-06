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
            Id(c => c.Name, map =>
            {
                map.Generator(Generators.Assigned);
                map.Column("UserId");
            });
            Property(c => c.Address);
            Property(c => c.CellPhone);
            Discriminator(c =>
            {
                c.Column("Discriminator");
            });
        }
    }
}
