using HotelManagementSystem.Library.Services;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace HotelManagementSystem.IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserService userService;
        public ResourceOwnerPasswordValidator(UserService userService)
        {
            this.userService = userService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var isValidResult = await userService.ValidateCredentialsAsync(1, context.UserName, context.Password);
            if (isValidResult)
            {
                var user = await userService.GetUserByUsernameAsync(1, context.UserName);

                if (user != null)
                {
                    //set the result
                    context.Result = new GrantValidationResult(
                        subject: user.Guid.ToString(),
                        authenticationMethod: "custom",
                        claims: await userService.GetUserClaimsAsync(user));

                    return;
                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
                return;
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                return;
            }
        }
    }
}
