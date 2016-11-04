using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GdzieMojHajs.Models;
using Microsoft.AspNetCore.Mvc;

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
