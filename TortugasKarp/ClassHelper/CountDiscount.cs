using System;

namespace TortugasKarp.ClassHelper
{
    public static class CountDiscount
    {
        public static decimal Sum(DateTime date, decimal cost)
        {
            int month = date.Month;
            int year = date.Year;
            DateTime dates = new DateTime(year, month, 1);
            int counts = DateTime.DaysInMonth(year, month);
            if ((int)dates.DayOfWeek >= 4 && (int)date.DayOfWeek == 6)
            {
                return cost * (decimal)0.89;
            }
            return cost;
        }
    }
}
