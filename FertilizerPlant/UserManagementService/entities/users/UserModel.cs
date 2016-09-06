using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.users
{
    public class UserModel
    {
        private string address;
        private string cellPhone;
        private string name;

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

        public virtual string CellPhone
        {
            get
            {
                return cellPhone;
            }

            set
            {
                cellPhone = value;
            }
        }

        public virtual string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
