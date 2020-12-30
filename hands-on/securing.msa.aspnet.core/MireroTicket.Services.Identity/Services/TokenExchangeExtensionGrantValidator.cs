using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace MireroTicket.Services.Identity.Services
{
    // Valid "Token Exchange" 
    //  서비스가 어떤 요청을 받을 때 따라온 인증정보를 사용해 다른 서비스를 호출 시 새로운 token을 받는 시나리오 
    //  이런 경우, Identity서비스가 이 요청이 유효한지를 확인하는 Custom Validator.
    // 
    // https://tools.ietf.org/html/rfc8693#section-2 
    // grant_type = urn:ietf:params:oauth:grant-type:token-exchange
    // subject_token =  {값이 있어야 함}
    // subject_token_type = {값이 있어야 함}
    //
    // 아래는 강좌와 똑같이 했지만, 위 사이트의 스펙과 좀 다른거 같다. 
    public class TokenExchangeExtensionGrantValidator : IExtensionGrantValidator
    {
        private readonly ITokenValidator _tokenValidator;
        private string AccessTokenType => "urn:ietf:params:oauth:token-type:access_token";
        
        public string GrantType => "urn:ietf:params:oauth:grant-type:token-exchange";

        public TokenExchangeExtensionGrantValidator(ITokenValidator tokenValidator)
        {
            _tokenValidator = tokenValidator;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            GrantValidationResult error = null;
            do
            {
                var requestedGrantType = context.Request.GrantType;
                if (requestedGrantType?.Equals(GrantType) == false)
                {
                    error = new GrantValidationResult(
                        TokenRequestErrors.InvalidGrant,
                        "Invalid Token Exchange Grant"
                    );
                    break;
                }

                var subjectToken = context.Request.Raw.Get("subject_token");
                if (subjectToken == null)
                {
                    error = new GrantValidationResult(
                        TokenRequestErrors.InvalidRequest,
                        "`subject_token` is missing"
                    );
                    break;
                }

                // subject_token = 로그인한 사용자의 access_token ?! 
                var subjectTokenType = context.Request.Raw.Get("subject_token_type");
                if (subjectTokenType == null)
                {
                    error = new GrantValidationResult(
                        TokenRequestErrors.InvalidRequest,
                        "`subject_token_type` is missing"
                    );
                    break;
                }

                if (AccessTokenType.Equals(subjectTokenType) == false)
                {
                    error = new GrantValidationResult(
                        TokenRequestErrors.InvalidRequest,
                        $"`subject_token_type` != `{AccessTokenType}`");
                }

                // subject_token_type 은 access token type 임을 나타내는 값이어야 함.
                // --> 그런다음에야 토큰값에 대한 Validation을 수행할 수 있음. 
                var result = await _tokenValidator.ValidateAccessTokenAsync(subjectToken);
                if (result.IsError)
                {
                    error = new GrantValidationResult(
                        TokenRequestErrors.InvalidRequest,
                        "`subject_token` is invalid"
                    );
                    break;
                }

                var sub = result.Claims.FirstOrDefault(c => c.Type == "sub");
                if (sub == null)
                {
                    error = new GrantValidationResult(
                        TokenRequestErrors.InvalidRequest,
                        "`sub` claim is missing"
                    );
                    break;
                }

                // ... 여기서 authorization checks 추가 작업을 할 수 있다. 

                // ... 여기서 claims transformation 작업을 할 수 있다. (특정 claim을 명시적으로 추가)

                // valid request. 
                context.Result = new GrantValidationResult(
                    sub.Value,
                    "access_token",
                    result.Claims
                );
            } while (false);

            if (error != null)
            {
                context.Result = error;
            }
        }
        
    }
}