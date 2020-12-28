using System;

namespace MireroTicket.Services.Common
{
    public static class GuidExtensions
    {
        public static string ToDbStringId(this Guid me)
        {
            return me.ToString("D");
        }
    }

    public static class DbGuid
    {
        public static Guid From(string dbGuidStringId)
        {
            return Guid.ParseExact(dbGuidStringId, "D");
        }
    }

    public static class StringIdExtensions
    {
        public static bool IsValidDbStringId(this string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }

            return Guid.TryParse(id, out var guid);
        }
    }
}