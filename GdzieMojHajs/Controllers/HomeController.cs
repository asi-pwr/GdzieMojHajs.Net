using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using GdzieMojHajs.Models;

namespace GdzieMojHajs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //public IActionResult WatchNotifications(Notification receiveds, Notification send)
        //{
        //    return PartialView("_WatchNotifications");
        //}
    }
}
