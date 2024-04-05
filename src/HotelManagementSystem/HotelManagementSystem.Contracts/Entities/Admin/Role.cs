namespace HotelManagementSystem.Contracts.Entities.Admin
{
    public class Role
    {
        public int RoleId { get; set; }
        public int HotelBranchId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual ICollection<RoleAssignment> RoleAssignments { get; set; }
        public virtual ICollection<PermissionAssignment> PermissionAssignments { get; set; }
    }
}
