using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Library.Services.Data;

namespace HotelManagementSystem.Library.Services
{
    public class HotelBranchService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HotelBranchService(IUnitOfWork unitOfWork)
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
