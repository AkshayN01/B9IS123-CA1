using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.DataAccess.Entities
{
    public class PermissionAssignment
    {
        public int PermissionAssignmentId { get; set; }
        public int HotelBranchId { get; set; }
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}
