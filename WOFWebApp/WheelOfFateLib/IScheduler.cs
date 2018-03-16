using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelOfFateLib
{
    interface IScheduler
    {
        #region public API surface methods
        (string Morning, string Afternoon) SpinTheWheel();

        /// <summary>
        /// Public Enumerator
        /// </summary>
        /// <returns>IEnumerator of finalScheduled list</returns>
        //IEnumerator<ScheduleDay> GetEnumerator();
        #endregion

        
    }
}