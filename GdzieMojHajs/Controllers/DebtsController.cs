using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GdzieMojHajs.Models;
using System.Collections.Generic;
using GdzieMojHajs.ViewModels.Debts;
using System;
using GdzieMojHajs.ViewModels.Notifications;
using GdzieMojHajs.Services;

namespace GdzieMojHajs.Controllers
{
    public class DebtsController : Controller
    {
        private ApplicationDbContext _context;
        private NotificationService _notifService;
        private DebtService _debtService;

        public DebtsController(ApplicationDbContext context)
        {
            _context = context;
            _debtService = new DebtService(_context);
            _notifService = new NotificationService(_context);    
        }

        // GET: Debts
        public IActionResult Index()
        {
            var applicationDbContext = _context.Debt.Include(d => d.DebtOwner).Include(d => d.DebtReceiver);
            return View(applicationDbContext.ToList());
        }

        // GET: Debts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Debt debt = _context.Debt.Single(m => m.Id == id);
            if (debt == null)
            {
                return NotFound();
            }

            return View(debt);
        }

        // GET: Debts/Create
        public IActionResult Create()
        {
            var users = _context.UserProfileInfo;
            List<object> newList = new List<object>();

            foreach (var member in users)
                newList.Add(new
                {
                    Id = member.Id,
                    Name = member.Name + " " + member.Surname
                });

            ViewData["DebtOwnerId"] = new SelectList(newList, "Id", "Name");
            ViewData["DebtReceiverId"] = new SelectList(newList, "Id", "Name");
            return View();
        }

        // POST: Debts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DebtViewModel debt)
        {
            var currentUserProfileInfo = _context.UserProfileInfo.Where(x => x.Email.Equals(User.Identity.Name)).First();

            if (debt.DebtOwnerId == 0)
            {
                debt.DebtOwnerId = _context.UserProfileInfo.Where(x => x.Email == User.Identity.Name).First().Id;
            }

            else if (debt.DebtReceiverId == 0)
            {
                debt.DebtReceiverId = _context.UserProfileInfo.Where(x => x.Email == User.Identity.Name).First().Id;
            }

            if (ModelState.IsValid)
            {
                _debtService.CreateDebt(debt);

                var senderId = currentUserProfileInfo.Id;
                var receiverId = senderId;

                if (debt.DebtOwnerId == senderId)
                {
                    receiverId = debt.DebtReceiverId;
                }

                else
                {
                    receiverId = debt.DebtOwnerId;
                }

                _notifService.CreateCreateNotification(receiverId, senderId, debt.Id);

                return RedirectToAction("Index","UserProfileInfoes");
            }

            var users = _context.UserProfileInfo;
            List<object> newList = new List<object>();

            foreach (var member in users)
                newList.Add(new
                {
                    Id = member.Id,
                    Name = member.Name + " " + member.Surname
                });

            ViewData["DebtOwnerId"] = new SelectList(newList, "Id", "Name", debt.DebtOwnerId);
            ViewData["DebtReceiverId"] = new SelectList(newList, "Id", "Name", debt.DebtReceiverId);
            return View(debt);
        }

        // GET: Debts/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Debt debt = _context.Debt.Single(m => m.Id == id);
            if (debt == null)
            {
                return NotFound();
            }

            DebtViewModel viewModel = new ViewModels.Debts.DebtViewModel
            {
                Id = debt.Id,
                IntAmount = debt.Amount,
                Comment = debt.Comment,
                Date = debt.Date.ToString("dd/MM/yyyy"),
                DebtOwner = debt.DebtOwner,
                DebtOwnerId = debt.DebtOwnerId,
                DebtReceiver = debt.DebtReceiver,
                DebtReceiverId = debt.DebtReceiverId
            };

            var users = _context.UserProfileInfo;
            List<object> newList = new List<object>();

            foreach (var member in users)
                newList.Add(new
                {
                    Id = member.Id,
                    Name = member.Name + " " + member.Surname
                });

            ViewData["DebtOwnerId"] = new SelectList(newList, "Id", "Name", debt.DebtOwnerId);
            ViewData["DebtReceiverId"] = new SelectList(newList, "Id", "Name", debt.DebtReceiverId);

            return PartialView("_EditDebtPartial",viewModel);
        }

        [HttpGet]
        public IActionResult RewriteOwn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Debt debt = _context.Debt.Single(m => m.Id == id);
            if (debt == null)
            {
                return NotFound();
            }

            DebtViewModel viewModel = new ViewModels.Debts.DebtViewModel
            {
                Id = debt.Id,
                IntAmount = debt.Amount,
                Comment = debt.Comment,
                Date = debt.Date.ToString("dd/MM/yyyy"),
                DebtOwner = debt.DebtOwner,
                DebtOwnerId = debt.DebtOwnerId,
                DebtReceiver = debt.DebtReceiver,
                DebtReceiverId = debt.DebtReceiverId
            };

            var users = _context.UserProfileInfo;
            List<object> newList = new List<object>();

            foreach (var member in users)
                newList.Add(new
                {
                    Id = member.Id,
                    Name = member.Name + " " + member.Surname
                });

            ViewData["DebtOwnerId"] = new SelectList(newList, "Id", "Name", debt.DebtOwnerId);
            ViewData["DebtReceiverId"] = new SelectList(newList, "Id", "Name", debt.DebtReceiverId);

            return PartialView("_RewriteOwnPartial", viewModel);
        }

        [HttpGet]
        public IActionResult RewriteReceived(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Debt debt = _context.Debt.Single(m => m.Id == id);
            if (debt == null)
            {
                return NotFound();
            }

            DebtViewModel viewModel = new ViewModels.Debts.DebtViewModel
            {
                Id = debt.Id,
                IntAmount = debt.Amount,
                Comment = debt.Comment,
                Date = debt.Date.ToString("dd/MM/yyyy"),
                DebtOwner = debt.DebtOwner,
                DebtOwnerId = debt.DebtOwnerId,
                DebtReceiver = debt.DebtReceiver,
                DebtReceiverId = debt.DebtReceiverId
            };

            var users = _context.UserProfileInfo;
            List<object> newList = new List<object>();

            foreach (var member in users)
                newList.Add(new
                {
                    Id = member.Id,
                    Name = member.Name + " " + member.Surname
                });

            ViewData["DebtOwnerId"] = new SelectList(newList, "Id", "Name", debt.DebtOwnerId);
            ViewData["DebtReceiverId"] = new SelectList(newList, "Id", "Name", debt.DebtReceiverId);

            return PartialView("_RewriteReceivedPartial", viewModel);
        }

        // POST: Debts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DebtViewModel debt)
        {
            var currentUserProfileInfo = _context.UserProfileInfo.Where(x => x.Email.Equals(User.Identity.Name)).First();

            if (ModelState.IsValid)
            {
                _debtService.EditDebt(debt);

                var senderId = currentUserProfileInfo.Id;
                var receiverId = senderId;

                if(debt.DebtOwnerId == senderId)
                {
                    receiverId = debt.DebtReceiverId;
                }

                else
                {
                    receiverId = debt.DebtOwnerId;
                }

                _notifService.CreateEditNotification(receiverId, senderId, debt.Id);

                return RedirectToAction("Index", "UserProfileInfoes");
            }
            ViewData["DebtOwnerId"] = new SelectList(_context.UserProfileInfo, "Id", "DebtOwner", debt.DebtOwnerId);
            ViewData["DebtReceiverId"] = new SelectList(_context.UserProfileInfo, "Id", "DebtReceiver", debt.DebtReceiverId);
            return View(debt);
        }

        // GET: Debts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Debt debt = _context.Debt.Single(m => m.Id == id);
            if (debt == null)
            {
                return NotFound();
            }

            return View(debt);
        }

        // POST: Debts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var currentUserProfileInfo = _context.UserProfileInfo.Where(x => x.Email.Equals(User.Identity.Name)).First();
            _notifService.CreateDeleteNotification(id, currentUserProfileInfo.Id);
            _debtService.DeleteDebt(id);
            return RedirectToAction("Index");
        }

        [ActionName("PayOff")]
        public IActionResult PayOff(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var currentUserProfileInfo = _context.UserProfileInfo.Where(x => x.Email.Equals(User.Identity.Name)).First();
            var senderId = currentUserProfileInfo.Id;

            _notifService.CreateDeleteNotification(id, senderId);

            _debtService.DeleteDebt(id);
            return RedirectToAction("Index", "UserProfileInfoes");
        }

    }
}
