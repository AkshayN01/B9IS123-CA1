using HotelManagementSystem.Contracts.Entities.Admin;
using HotelManagementSystem.Library.Services.Data;
using HotelManagementSystem.Library.Services.Data.Admin;

namespace HotelManagementSystem.Library.Services
{
    public class UserService
    {
        private readonly IAdminUnitOfWork _unitOfWork;
        private readonly HotelBranchService _branchService;

        public UserService(IAdminUnitOfWork unitOfWork, HotelBranchService branchService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _branchService = branchService ?? throw new ArgumentNullException(nameof(branchService));
        }

        public async Task<bool> ValidateCredentialsAsync(int branchId, string username, string password)
        {
            bool IsValid = false;

            try
            {
                User user = await GetUserByUsernameAsync(branchId, username);
                if(user != null)
                {
                    IsValid = password == user.Password;
                }
            }
            catch (Exception ex) { }

            return IsValid;
        }

        public async Task<User> GetUserByUsernameAsync(int branchId, string username)
        {
            User user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username, branchId);

            return user;
        }
    }
}
