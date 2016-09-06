using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.users;

namespace UserManagementService.services.users
{
    public interface UserService
    {
        void Add(UserModel user);
        void BulkSave(IList<UserModel> users);
    }
}
