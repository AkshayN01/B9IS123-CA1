using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DataAccess.Entities
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public int HotelBranchId { get; set; }
        public string Module { get; set; }
        public string SubModule { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<PermissionAssignment> PermissionAssignments { get; set; }
    }
}
