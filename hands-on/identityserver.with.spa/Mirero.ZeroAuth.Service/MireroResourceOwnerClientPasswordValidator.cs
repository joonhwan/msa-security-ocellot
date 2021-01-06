using System;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Test;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;

namespace Mirero.ZeroAuth.Service
{
    public class MireroResourceOwnerClientPasswordValidator : IResourceOwnerPasswordValidator
    {   
        private readonly TestUserStore _users;
        private readonly ISystemClock _clock;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestUserResourceOwnerPasswordValidator"/> class.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="clock">The clock.</param>
        public MireroResourceOwnerClientPasswordValidator(TestUserStore users, ISystemClock clock)
        {
            _users = users;
            _clock = clock;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var username = context.UserName;
            var password = context.Password;
            
            if (_users.ValidateCredentials(context.UserName, context.Password))
            {
                var user = _users.FindByUsername(context.UserName);
                context.Result = new GrantValidationResult(
                    user.SubjectId ?? throw new ArgumentException("Subject ID not set", nameof(user.SubjectId)), 
                    OidcConstants.AuthenticationMethods.Password, _clock.UtcNow.UtcDateTime, 
                    user.Claims);
            }

            return Task.CompletedTask;
        }
    }
}