using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator_SutSun : WorkDayCalculator
    {
        protected override bool IsWeekEnd(DateTime day, WeekEnd[] weekEnds)
        {
            DayOfWeek dayWeek = day.DayOfWeek;
            if ((dayWeek == DayOfWeek.Saturday) || (dayWeek == DayOfWeek.Sunday))
            {
                return true;
            }
            return base.IsWeekEnd(day, weekEnds);
        }
    }
}
