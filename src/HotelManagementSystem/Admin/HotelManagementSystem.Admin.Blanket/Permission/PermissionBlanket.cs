using HotelManagementSystem.Contracts.APIModels.Admin;
using HotelManagementSystem.Contracts.Generic.Response;
using HotelManagementSystem.Library.Services;
using HotelManagementSystem.Library.Services.Data.Admin;

namespace HotelManagementSystem.Admin.Blanket.Permission
{
    public class PermissionBlanket
    {
        private readonly HotelBranchService _branchService;
        private readonly IAdminUnitOfWork _adminUnitOfWork;
        public PermissionBlanket(HotelBranchService hotelBranchService, IAdminUnitOfWork adminUnitOfWork) 
        {
            _branchService = hotelBranchService;
            _adminUnitOfWork = adminUnitOfWork;
        }

        public async Task<HTTPResponse> AddPermission(List<PermissionModel> permissionModels)
        {
            int retVal = -40;
            string message = string.Empty;
            Object data = default(Object);

            try
            {
                //Get Current branch Details
                var branch = await _branchService.GetCurrentInstance();

                List<Contracts.Entities.Admin.Permission> permissions = new List<Contracts.Entities.Admin.Permission>();
                if(permissionModels.Any())
                {
                    foreach(var model in permissionModels)
                    {
                        Contracts.Entities.Admin.Permission permission = new Contracts.Entities.Admin.Permission()
                        {
                            CreatedAt = DateTime.UtcNow,
                            HotelBranchId = branch.Id,
                            Description = model.Description,
                            Name = model.Name
                        };
                    }

                    retVal = await _adminUnitOfWork.PermissionRepository.AddPermissions(permissions);
                }

            }
            catch(Exception ex) 
            {
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }
        public async Task<HTTPResponse> ViewPermission()
        {
            int retVal = -40;
            string message = string.Empty;
            Object data = default(Object);

            try
            {
                data = await _adminUnitOfWork.PermissionRepository.GetAllAsync();
                retVal = 1;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Library.Generic.APIResponse.ConstructExceptionResponse(retVal, message);
            }

            return Library.Generic.APIResponse.ConstructHTTPResponse(data, retVal, message);
        }
    }
}