using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Library.Services.Data;
using HotelManagementSystem.Library.Services.Data.Admin;

namespace HotelManagementSystem.Library.Services
{
    public class HotelBranchService
    {
        private readonly IAdminUnitOfWork _unitOfWork;

        public HotelBranchService(IAdminUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<HotelBranch> GetCurrentInstance()
        {
            var branch = await _unitOfWork.HotelBranchRepository.GetCurrentBranchAsync();

            return branch;
        }
    }
}
