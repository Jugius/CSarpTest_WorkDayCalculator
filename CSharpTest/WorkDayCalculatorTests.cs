using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2014, 12, 1);
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count-1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25))
            }; 

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29))
            };
            
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }
        [TestMethod]
        public void TestStartDayIsWeekend()
        {
            DateTime startDate = new DateTime(2022, 4, 15);
            int count = 3;

            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2022, 4, 13), new DateTime(2022, 4, 17))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2022, 4, 20)));
        }
        [TestMethod]
        public void TestLastDayIsWeekend()
        {
            DateTime startDate = new DateTime(2022, 4, 20);
            int count = 3;

            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2022, 4, 22), new DateTime(2022, 4, 23)),
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2022, 4, 24)));
        }

        [TestMethod]
        public void TestDurationIsOneDay()
        {
            DateTime startDate = new DateTime(2022, 4, 20);
            int count = 1;

            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2022, 4, 22), new DateTime(2022, 4, 23)),
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2022, 4, 20)));
        }
        [TestMethod]
        public void TestDurationIsOneDayAndStartDayIsWeekend()
        {
            DateTime startDate = new DateTime(2022, 4, 24);
            int count = 1;

            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2022, 4, 22), new DateTime(2022, 4, 25)),
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2022, 4, 26)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDurationIsZeroThrows()
        {
            DateTime startDate = new DateTime(2022, 4, 20);
            int count = 0;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);
        }
    }
}
