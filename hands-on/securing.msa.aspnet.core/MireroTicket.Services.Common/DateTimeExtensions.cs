using System;

namespace MireroTicket.Services.Common
{
    public static class DateTimeExtensions
    {
        public static string ToDbDateTimeString(this DateTime me)
        {
            return me.ToString("O");
        }
    }

    public static class DbDateTime
    {
        public static DateTime From(string dbDateString)
        {
            return DateTime.Parse(dbDateString); //TODO CHECKME
        }
    }
}