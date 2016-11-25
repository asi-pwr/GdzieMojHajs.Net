using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GdzieMojHajs.Models;
using System.Collections.Generic;
using GdzieMojHajs.ViewModels.Debts;
using System;

namespace GdzieMojHajs.Controllers
{
    public class DebtsController : Controller
    {
        private ApplicationDbContext _context;

        public DebtsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Debts
        public IActionResult Index()
        {
            var dupa = _context.UserProfileInfo.ToList();
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
                _context.Debt.Add(new Debt()
                {
                    Amount = debt.IntAmount,
                    Comment = debt.Comment,
                    Date = DateTime.Parse(debt.Date),
                    DebtOwnerId = debt.DebtOwnerId,
                    DebtReceiverId = debt.DebtReceiverId
                });
                _context.SaveChanges();
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

        // POST: Debts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DebtViewModel debt)
        {
            if (ModelState.IsValid)
            {
                Debt toUpdate = _context.Debt.Single(m => m.Id == debt.Id);
                toUpdate.Amount = debt.IntAmount;
                toUpdate.Comment = debt.Comment;
                toUpdate.Date = DateTime.Parse(debt.Date);
                toUpdate.DebtOwnerId = debt.DebtOwnerId;
                toUpdate.DebtReceiverId = debt.DebtReceiverId;

                _context.Update(toUpdate);
                _context.SaveChanges();
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
            Debt debt = _context.Debt.Single(m => m.Id == id);
            _context.Debt.Remove(debt);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ActionName("PayOff")]
        public IActionResult PayOff(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Debt toRemove = _context.Debt.Single(x => x.Id == id);
            _context.Debt.Remove(toRemove);
            _context.SaveChanges();
            return RedirectToAction("Index", "UserProfileInfoes");
        }

    }
}
