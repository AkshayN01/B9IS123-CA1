using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Library.Services.Data;
using HotelManagementSystem.Library.Services.Data.Admin;

namespace HotelManagementSystem.Library.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HotelBranchService _branchService;

        public UserService(IUnitOfWork unitOfWork, HotelBranchService branchService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _branchService = branchService ?? throw new ArgumentNullException(nameof(branchService));
        }

        public async Task<User> GetUserByUsername(string username)
        {
            HotelBranch branch = await _branchService.GetCurrentInstance();
            if (branch == null)
                return new Exception('No branch found');

            User user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username, branch.Id);

            return user;
        }
    }
}
