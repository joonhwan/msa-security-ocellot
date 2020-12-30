using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;

namespace MireroTicket.Utilities
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool TryGetClaim<T>(this ClaimsPrincipal me, string claimType, out T value)
        {
            value = default;
            var done = false;
            try
            {
                var foundClaim = me.Claims.FirstOrDefault(claim => claim.Type == claimType);
                if (foundClaim != null)
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter.CanConvertFrom(typeof(string)))
                    {
                        value = (T) converter.ConvertFromString(foundClaim.Value);
                        done = true;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
                done = false;
            }

            return done;
        }

        public static T GetClaimOrDefault<T>(this ClaimsPrincipal me, string claimType, T defaultValue = default)
        {
            if (!TryGetClaim(me, claimType, out T value))
            {
                value = defaultValue;
            }
            return value;
        }
    }
}