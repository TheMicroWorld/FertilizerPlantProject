using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementService.entities.user
{
    public class UserModel
    {
        private long id;
        private string name;
        private string phoneNumber;
        private string address;

        public virtual long Id
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

        public virtual string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }

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
    }
}
