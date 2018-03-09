using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WOFWebApp.Models;
using WheelOfFateLib;

namespace WOFWebApp.Controllers
{
    public class ScheduleController : Controller
    {
        //Instance of the WheelOfFate library Scheduler
        Scheduler shiftScheduler = new Scheduler();

        // GET: Schedule
        public ActionResult Index()
        {
            var newDay = shiftScheduler.SpinTheWheel();
            List<ScheduleDayModel> info = new List<ScheduleDayModel>();
            info.Add(new ScheduleDayModel {Morning = newDay.Morning, Afternoon = newDay.Afternoon});

            return View(info);
        }
    }
}