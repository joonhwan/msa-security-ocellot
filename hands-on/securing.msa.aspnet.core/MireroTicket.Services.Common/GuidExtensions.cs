using System;

namespace MireroTicket.Services.Common
{
    public static class GuidExtensions
    {
        public static string ToDbString(this Guid me)
        {
            return me.ToString("D");
        }
    }

    public static class DbGuid
    {
        public static Guid From(string dbGuidString)
        {
            return Guid.ParseExact(dbGuidString, "D");
        }
    }
}