using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFateLib
{
    public class Scheduler : SchedulerBase, IScheduler
    {
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
        /*
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)finalScheduled).GetEnumerator();
        }
        */
        #endregion
    }

}
