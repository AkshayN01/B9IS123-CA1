using HotelManagementSystem.Library.Services.Data.Admin;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Contracts.Entities.Admin;

namespace HotelManagementSystem.Library
{
    public class ManagementService
    {
        private readonly IAdminUnitOfWork _unitOfWork;

        public ManagementService(IAdminUnitOfWork unitOfWork, HotelBranchService branchService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<HotelBranch>> GetAllBranches()
        {
            return await _unitOfWork.HotelBranchRepository.GetAllAsync();
        }

        public async Task<List<Role>> GetRolesAsync(int branchId)
        {
           return await _unitOfWork.RoleRepository.GetRoleByBranchIdAsync(branchId);
        }
        public async Task<List<Permission>> GetRolePermissionsAsync(int roleId, int branchId)
        {
            var permissions = await _unitOfWork.PermissionRepository.GetRolePermissionsAsync(roleId, branchId);

            return permissions;
        }
    }
}
