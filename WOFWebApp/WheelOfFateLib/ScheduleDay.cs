using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFateLib
{
    /// <summary>
    /// Base data type for scheduled days
    /// </summary>
    public class ScheduleDay
    {
        private int day;
        private Employee morningShiftEmp;
        private Employee afternoonShiftEmp;

        public int Day => day;
        public Employee MorningShiftEmployee => morningShiftEmp;
        public Employee AfternoonShiftEployee => afternoonShiftEmp;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="Schedule day"></param>
        /// <param name="Employee one"></param>
        /// <param name="Employee two"></param>
        public ScheduleDay(int dayOfSchedule, Employee one, Employee two)
        {
            day = dayOfSchedule;
            morningShiftEmp = one;
            afternoonShiftEmp = two;
        }
    }
}
