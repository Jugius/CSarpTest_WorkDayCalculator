using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (dayCount < 0) throw new ArgumentOutOfRangeException("dayCount");
            if (dayCount <= 1) return startDate;
            if (weekEnds == null || weekEnds.Length == 0) return startDate.AddDays(dayCount - 1);

            int workingDays = 1;
            DateTime checkingDay = startDate;

            while (workingDays < dayCount)
            {
                checkingDay = checkingDay.AddDays(1);
                if (!IsWeekEnd(checkingDay, weekEnds))
                {
                    workingDays++;
                }
            }
            return checkingDay;
        }
        /// <summary>
        /// Checks if DateTime is a weekend
        /// </summary>
        protected virtual bool IsWeekEnd(DateTime day, WeekEnd[] weekEnds)
        {
            //using Linq
            //return weekEnds.FirstOrDefault(a => day >= a.StartDate && day <= a.EndDate) != null;

            bool result = false;
            foreach (var weekEnd in weekEnds)
            {
                if (day >= weekEnd.StartDate && day <= weekEnd.EndDate)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
