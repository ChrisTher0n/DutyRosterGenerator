using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelOfFateLib;

namespace WOFUnitTest
{
    [TestClass]
    public class DayUnitTest
    {

        Scheduler initSchedule = new Scheduler();

        [TestMethod]
        public void TestDayDuplicates()
        {
            for (int i = 1; i <= 10; i++)
            {
                var result = initSchedule.SpinTheWheel();
                Assert.AreNotEqual(result.Morning, result.Afternoon);

            }
        }

        
        [TestMethod]
        public void TestConsecutiveDayDuplicates()
        {
            //int prevMornEmpNum = -1;
            //int prevAftEmpNum = -1;
            var prevResult = (Morning: "empty" , Afternoon: "empty");

            for (int i = 1; i <= 10; i++)
            {
                var result = initSchedule.SpinTheWheel();
                if(prevResult.Morning !=  "empty")
                {
                    //Compare!
                    Assert.AreNotEqual(result.Morning, prevResult.Morning);
                    Assert.AreNotEqual(result.Afternoon, prevResult.Morning);
                    Assert.AreNotEqual(result.Morning, prevResult.Afternoon);
                    Assert.AreNotEqual(result.Afternoon, prevResult.Afternoon);
                }

                prevResult = result;
            }
        }

        /* Proposed test TODO
        [TestMethod]
        public void TestEvenWorkload()
        {
            EngineerContainer newContainer = new EngineerContainer();

            Scheduler testSchedule = new Scheduler(newContainer);
            testSchedule.GenerateSchedule(10);

                
            foreach(Engineer e in newContainer)
            {
                Assert.IsTrue(newContainer.ReturnShiftCount(e.EmployeeNum) >= 2);
            }
            
        }
        */        
    }
}
