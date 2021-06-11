using System;

namespace Web.Util.Transformers
{
    public static class ParsingUtilities
    {
        public static DateTime ParseDate(string date)
        {
            var succeed = DateTime.TryParse(date, out DateTime result);
            return succeed ? result : DateTime.MinValue;
        }
    }
}