using HotelManagementSystem.Library.Services;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using static IdentityServer4.IdentityServerConstants;

namespace HotelManagementSystem.IdentityServer
{

    public class UserProfileService : IProfileService
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger Logger;

        /// <summary>
        /// The users
        /// </summary>
        protected readonly UserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestUserProfileService"/> class.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="logger">The logger.</param>
        public UserProfileService(UserService userService, ILogger<UserProfileService> logger)
        {
            _userService = userService;
            Logger = logger;
        }

        /// <summary>
        /// This method is called whenever claims about the user are requested (e.g. during token creation or via the userinfo endpoint)
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public virtual async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.LogProfileRequest(Logger);

            if (context.Caller == ProfileDataCallers.UserInfoEndpoint)
            {
                var user = _userService.GetUserByGuidAsync(context?.Subject?.GetSubjectId())?.Result;
                if (user != null)
                {
                    var claims = await _userService.GetUserClaimsAsync(user, true);
                    //context.AddRequestedClaims(claims);
                    context.IssuedClaims.AddRange(claims);
                }

                context.LogIssuedClaims(Logger);
            }

            return;
        }

        /// <summary>
        /// This method gets called whenever identity server needs to determine if the user is valid or active (e.g. if the user's account has been deactivated since they logged in).
        /// (e.g. during token issuance or validation).
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public virtual Task IsActiveAsync(IsActiveContext context)
        {
            Logger.LogDebug("IsActive called from: {caller}", context.Caller);

            var user = _userService.GetUserByGuidAsync(context.Subject.GetSubjectId()).Result;
            context.IsActive = user?.IsActive == true;

            return Task.CompletedTask;
        }
    }
}
