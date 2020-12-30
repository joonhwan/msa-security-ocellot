using System;
using System.Collections.Generic;
using System.Security.Claims;
using NUnit.Framework;

namespace MireroTicket.Utilities.Test
{
    public class ClaimPrincipalExtensionsTest
    {
        private ClaimsPrincipal CreateCp(string type, string value)
        {
            var identity = new ClaimsIdentity(  
                    new []
                    {
                        new Claim(type, value),
                    })
                ;
            return new ClaimsPrincipal(identity);
        }

        [Test]
        public void TryGetClaim_Can_Convert_Value_Guid_Claim()
        {
            var expected = Guid.NewGuid();
            var cp = CreateCp("guid", expected.ToString("D"));
            var got = cp.TryGetClaim("guid", out Guid actual);
            
            Assert.True(got);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TryGetClaim_Cannot_Convert_Value_NonGuid_Claim_As_Guid_Claim()
        {
            var expected = default(Guid);
            var cp = CreateCp("guid", "invalid-guid-value");
            var got = cp.TryGetClaim("guid", out Guid actual);
            
            Assert.False(got);
            Assert.AreEqual(expected, actual);
        }
        
        
        [Test]
        public void TryGetClaim_Cannot_Convert_Value_Non_Existing_Claim_As_Guid_Claim()
        {
            var expected = default(Guid);
            var cp = CreateCp("not-guid", "invalid-guid-value");
            var got = cp.TryGetClaim("guid", out Guid actual);
            
            Assert.False(got);
            Assert.AreEqual(expected, actual);
        }
    }
}