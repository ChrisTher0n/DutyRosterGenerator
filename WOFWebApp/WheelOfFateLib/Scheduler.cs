using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFateLib
{
    public class Scheduler : IEnumerable
    {

        private EmployeeContainer myEmpContainer = null;
        private List<ScheduleDay> finalScheduled;
        private int morningEmpNum = -1;
        private int intPrevDayMorningEmpNum = -1;
        private int intPrevDayAfternoonEmpNum = -1;
        private int currentPos = 0;

        int totalShifts = 0;

        #region Public methods
        /// <summary>
        /// Class Constructor
        /// </summary>
        public Scheduler()
        {
            Init();
        }

        /// <summary>
        /// This is the main publicly exposed method that returns a Tuple with strings for morning and afternoon shifts.
        /// </summary>
        /// <returns>Tuple containing names of selected employees</returns>
        public (string Morning, string Afternoon) SpinTheWheel()
        {
            ScheduleDay tmpDay = GetNextDay();

            return (tmpDay.MorningShiftEmployee.Name, tmpDay.AfternoonShiftEployee.Name);
        }

        /// <summary>
        /// Public Enumerator
        /// </summary>
        /// <returns>IEnumerator of finalScheduled list</returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)finalScheduled).GetEnumerator();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// This method will return the next day in schedule containing shift information
        /// When it gets to the 10th day, it returns that, then resets and generates a new list using last day of previous list as starting point
        /// This ensures there are no overlaps/dicrepancies/double shifts
        /// </summary>
        /// <returns></returns>
        private ScheduleDay GetNextDay()
        {
            if (finalScheduled.Count != 0 && currentPos < finalScheduled.Count)
            {
                return finalScheduled[currentPos++];
            }
            else
            {
                Clear();
                GenerateSchedule(10);

                return finalScheduled[currentPos++];
            }

        }

        /// <summary>
        /// Generates final work schedule
        /// </summary>
        /// <param name="numDays">Time in days to generate schedule for</param>
        /// <returns>List of Tuple containing day and two people(Employee type) assigned</returns>
        private List<ScheduleDay> GenerateSchedule(int numDays)
        {
            for (int i = 1; i <= numDays; i++)
            {

                ScheduleDay current = new ScheduleDay(i, GetMorningShift(), GetAfternoonShift());
                finalScheduled.Add(current);

                SetPrevDayVars(current.MorningShiftEmployee.EmployeeNum, current.AfternoonShiftEployee.EmployeeNum);
                SetDayVars(-1);
            }

            return finalScheduled;
        }

        /// <summary>
        /// Only way of resetting main scheduled list and variables to be able to generate a new set of shifts based on rules.
        /// </summary>
        private void Clear()
        {
            myEmpContainer = null;
            finalScheduled.Clear(); 
            morningEmpNum = -1;
            //intPrevDayMorningEmpNum = -1; //Do not reset these, they can be used to continue sequence correctly when list resets
            //intPrevDayAfternoonEmpNum = -1;
            totalShifts = 0;
            currentPos = 0;

            Init();
        }

        
        /// <summary>
        /// Private class initialization function for Scheduler class
        /// Sets up Employee Container and final schedule list
        /// </summary>
        private void Init()
        {
            myEmpContainer = new EmployeeContainer();
            finalScheduled = new List<ScheduleDay>();
        }

        /// <summary>
        /// Using GetNextEmployee this method return morning shift employee
        /// Specialized since two shifts are handled slightly differently
        /// Though both use GetNextEmployee in the end
        /// </summary>
        /// <returns>Instance of an Employee selected at random based on rules</returns>
        private Employee GetMorningShift()
        {
            Employee morningShiftTmp = GetNextEmployee();
            SetDayVars(morningShiftTmp.EmployeeNum);

            return morningShiftTmp;
        }

        /// <summary>
        /// Using GetNextEmployee this method return afternoon shift employee
        /// Specialized since two shifts are handled slightly differently
        /// Though both use GetNextEmployee in the end
        /// </summary>
        /// <returns>Instance of an Employee selected at random based on rules</returns>
        private Employee GetAfternoonShift()
        {
            return GetNextEmployee();
        }

        /// <summary>
        /// Uses rulesets to return a random Employee for a shift
        /// </summary>
        /// <returns>Instance of an Employee selected at random based on rules</returns>
        private Employee GetNextEmployee()
        {
            Employee tempEng = null;
            int maxShifts;
            bool foundEmployee = false;

            while (!foundEmployee)
            {
                if (totalShifts < 10)
                {
                    maxShifts = 1;
                }
                else
                {
                    maxShifts = 2;
                }

                tempEng = myEmpContainer.GetRandomEmployee();

                if (tempEng.EmployeeNum != intPrevDayMorningEmpNum && tempEng.EmployeeNum != intPrevDayAfternoonEmpNum)
                {//Employee did not work yesterday..continue

                    //Check if afternoon employee is different from morning, if a morning shift was assigned
                    if(morningEmpNum == -1 || morningEmpNum != tempEng.EmployeeNum)
                    {
                        //Check if employee already worked at least 2 shifts
                        if (tempEng.ShiftsWorked < maxShifts)
                        {
                            //Success. Return Employee
                            foundEmployee = true;
                            totalShifts++;
                        }
                    }
                }
            }

            //Update shift count of found Employee
            myEmpContainer.UpdateShiftCount(tempEng.EmployeeNum);

            return tempEng;
        }

        /// <summary>
        /// Helper method to set specific vars
        /// </summary>
        /// <param name="morn">Employee number of morning shift employee</param>
        private void SetDayVars(int morn)
        {
            morningEmpNum = morn;
        }

        /// <summary>
        /// Helper method to set specific vars on previous day
        /// </summary>
        /// <param name="prevMorn">Employee number of previous day's morning shift employee</param>
        /// <param name="prevAft">Employee number of previous day's afternoon shift employee</param>
        private void SetPrevDayVars(int prevMorn, int prevAft)
        {
            intPrevDayMorningEmpNum = prevMorn;
            intPrevDayAfternoonEmpNum = prevAft;
        }
        #endregion
    }

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

        public ScheduleDay(int dayOfSchedule, Employee one, Employee two)
        {
            day = dayOfSchedule;
            morningShiftEmp = one;
            afternoonShiftEmp = two;
        }
    }
}
