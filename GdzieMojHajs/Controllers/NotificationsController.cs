using System.Linq;
using GdzieMojHajs.Models;
using System.Collections.Generic;
using GdzieMojHajs.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GdzieMojHajs.Controllers
{
    public class NotificationsController : Controller
    {
        private ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Notifications
        public IActionResult Index()
        {
            var currentUserProfileInfo = _context.UserProfileInfo.Where(x => x.Email.Equals(User.Identity.Name)).First();
            var applicationDbContext = _context.Notification.Where(x => x.NotificationReceiverId.Equals(currentUserProfileInfo.Id));
            return View(applicationDbContext.ToList());
        }

        // GET: Notifications/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notification notification = _context.Notification.Single(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            ViewData["DebtId"] = ToDebtSelectList(_context.Debt.ToList());
            ViewData["NotificationReceiverId"] = ToUserSelectList(_context.UserProfileInfo.ToList());
            return View();
        }

        // POST: Notifications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NotificationViewModel notification)
        {
            if (ModelState.IsValid)
            {
                var currentUserProfileInfo = _context.UserProfileInfo.Where(x => x.Email == User.Identity.Name).First();

                var not = new Notification
                {
                    //Debt = notification.Debt,
                    //NotificationReceiver = notification.NotificationReceiver,
                    //DebtId = notification.DebtId,
                    NotificationReceiverId = notification.NotificationReceiverId,
                    Text = notification.Text,
                    NotificationSenderId = currentUserProfileInfo.Id,
                    //NotificationSender = _context.UserProfileInfo.Select(x=>x.Email==)
                };
                _context.Notification.Add(not);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewData["DebtId"] = ToDebtSelectList(_context.Debt.ToList());
            //ViewData["NotificationReceiverId"] = ToUserSelectList(_context.UserProfileInfo.ToList());

            return new EmptyResult();
        }

        public List<SelectListItem> ToUserSelectList(List<UserProfileInfo> users)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var u in users)
            {
                items.Add(new SelectListItem()
                {
                    Text = u.Name + " " + u.Surname,
                    Value = u.Id.ToString()
                });
            }
            return items;
        }

        public List<SelectListItem> ToDebtSelectList(List<Debt> debts)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var users =_context.UserProfileInfo;
            foreach (var d in debts)
            {
                d.DebtOwner = users.First(u => u.Id == d.DebtOwnerId);
                d.DebtReceiver = users.First(u => u.Id == d.DebtReceiverId);

                items.Add(new SelectListItem()
                {
                    Text = d.DebtOwner.Name + " " + d.DebtOwner.Surname + "=>" + d.DebtReceiver.Name + " " + d.DebtReceiver.Surname + " " + d.Amount + "zl " + d.Date,
                    Value = d.Id.ToString()
                });
            }
            return items;
        }

        // GET: Notifications/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notification notification = _context.Notification.Single(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["DebtId"] = new SelectList(_context.Debt, "Id", "Debt");
            ViewData["NotificationReceiverId"] = new SelectList(_context.UserProfileInfo, "Id", "NotificationReceiver", notification.NotificationReceiverId);
            ViewData["NotificationSenderId"] = new SelectList(_context.UserProfileInfo, "Id", "NotificationSender", notification.NotificationSenderId);
            return View(notification);
        }

        // POST: Notifications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Update(notification);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DebtId"] = new SelectList(_context.Debt, "Id", "Debt");
            ViewData["NotificationReceiverId"] = new SelectList(_context.UserProfileInfo, "Id", "NotificationReceiver", notification.NotificationReceiverId);
            ViewData["NotificationSenderId"] = new SelectList(_context.UserProfileInfo, "Id", "NotificationSender", notification.NotificationSenderId);
            return View(notification);
        }

        // GET: Notifications/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notification notification = _context.Notification.Single(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Notification notification = _context.Notification.Single(m => m.Id == id);
            _context.Notification.Remove(notification);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
