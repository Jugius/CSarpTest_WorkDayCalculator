using System;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            // !!!This logic MUST be clarified with the Tl
            // since the start day is the first day, the number of days is less than 1 is an error
            if (dayCount < 1) throw new ArgumentOutOfRangeException(nameof(dayCount), "Duration must be at least 1 day.");

            // if there are no weekEnds, return the start date plus duration
            if (weekEnds == null || weekEnds.Length == 0) return startDate.AddDays(dayCount - 1);

            DateTime checkingDay = startDate;
            int daysLeft = dayCount - 1;

            foreach (WeekEnd weekEnd in weekEnds)
            {
                if (checkingDay < weekEnd.StartDate)
                {
                    var daysToStartNextWeekend = (int)(weekEnd.StartDate - checkingDay).TotalDays;
                    if (daysLeft < daysToStartNextWeekend)
                    {
                        return checkingDay.AddDays(daysLeft);
                    }
                    else if (daysLeft == daysToStartNextWeekend)
                    {
                        return weekEnd.EndDate.AddDays(1);
                    }
                    else
                    {
                        daysLeft -= daysToStartNextWeekend;
                        checkingDay = weekEnd.EndDate.AddDays(1);
                    }
                }
                else if (checkingDay > weekEnd.EndDate)
                {
                    continue;
                }
                else
                {
                    checkingDay = weekEnd.EndDate.AddDays(1);
                }
            }
            return checkingDay.AddDays(daysLeft);
        }       
    }
}
