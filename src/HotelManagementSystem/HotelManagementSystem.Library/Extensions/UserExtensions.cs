using HotelManagementSystem.Contracts.Entities.Admin;

namespace HotelManagementSystem.Library.Extensions
{
    public static class UserExtensions
    {
        public static bool HasPermissions(this List<Permission> userPermissions, string requiredPermission)
        {
            bool hasPermissions = false;
            
            if(userPermissions.Count == 0) return hasPermissions;
            hasPermissions = userPermissions.Any(x => x.Name.ToLower() == requiredPermission.ToLower());
            
            return hasPermissions;
        }
    }
}
