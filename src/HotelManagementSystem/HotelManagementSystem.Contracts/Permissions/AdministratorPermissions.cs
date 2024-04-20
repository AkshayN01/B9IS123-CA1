using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.Permissions
{
    public static class AdministratorPermissions
    {
        public const string AddRole = "admin:role:add";
        public const string ViewRole = "admin:role:view";
        public const string EditRole = "admin:role:edit";
        public const string DeleteRole = "admin:role:delete";


        public const string AddPermission = "admin:permission:add";
        public const string ViewPermission = "admin:permission:view";
        public const string EditPermission = "admin:permission:edit";
        public const string DeletePermission = "admin:permission:delete";
    }
}