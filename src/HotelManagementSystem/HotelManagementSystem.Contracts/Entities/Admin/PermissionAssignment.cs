using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class PermissionAssignment
    {
        public int PermissionAssignmentId { get; set; }
        public int HotelBranchId { get; set; }
        public int PermissionId { get; set; } // Required foreign key property
        public int RoleId { get; set; } // Required foreign key property
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Permission Permission { get; set; } = null!; // Required reference navigation to principal
        public Role Role { get; set; } = null!; // Required reference navigation to principal
    }
}
