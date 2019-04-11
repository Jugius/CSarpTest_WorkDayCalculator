using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class CalculatorFactory
    {
        /// <summary>
        /// Factory creates instance of IWorkDayCalculator depending on whether saturday and sunday are weekends;
        /// </summary>
        /// <param name="isWeekdays">True if saturday and sunday are weekends, else false</param>
        IWorkDayCalculator Create(bool isWeekdays)
        {
            if (isWeekdays)
                return new WorkDayCalculator_SutSun();
            else
                return new WorkDayCalculator();
        }
    }
}
