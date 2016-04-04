using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using GdzieMojHajs.Models;
using System.Collections.Generic;

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
            var applicationDbContext = _context.Notification.Include(n => n.Debt).Include(n => n.NotificationReceiver).Include(n => n.NotificationSender);
            return View(applicationDbContext.ToList());
        }

        // GET: Notifications/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Notification notification = _context.Notification.Single(m => m.Id == id);
            if (notification == null)
            {
                return HttpNotFound();
            }

            return View(notification);
        }

        // GET: Notifications/Create
        public IActionResult Create()
        {
            ViewData["DebtId"] = ToDebtSelectList(_context.Debt.ToList());
            ViewData["NotificationReceiverId"] = ToUserSelectList(_context.UserProfileInfo.ToList());
            ViewData["NotificationSenderId"] = ToUserSelectList(_context.UserProfileInfo.ToList());
            return View();
        }

        // POST: Notifications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Notification.Add(notification);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DebtId"] = ToDebtSelectList(_context.Debt.ToList());
            ViewData["NotificationReceiverId"] = ToUserSelectList(_context.UserProfileInfo.ToList());
            ViewData["NotificationSenderId"] = ToUserSelectList(_context.UserProfileInfo.ToList());

            //notification.NotificationSender = 
            return View(notification);
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
                return HttpNotFound();
            }

            Notification notification = _context.Notification.Single(m => m.Id == id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            ViewData["DebtId"] = new SelectList(_context.Debt, "Id", "Debt", notification.DebtId);
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
            ViewData["DebtId"] = new SelectList(_context.Debt, "Id", "Debt", notification.DebtId);
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
                return HttpNotFound();
            }

            Notification notification = _context.Notification.Single(m => m.Id == id);
            if (notification == null)
            {
                return HttpNotFound();
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
