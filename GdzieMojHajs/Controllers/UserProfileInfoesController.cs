using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using GdzieMojHajs.Models;
using Microsoft.AspNet.Authorization;
using GdzieMojHajs.ViewModels.UserProfileInfos;
using System.Collections.Generic;

namespace GdzieMojHajs.Controllers
{
    public class UserProfileInfoesController : Controller
    {
        private ApplicationDbContext _context;

        public UserProfileInfoesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: UserProfileInfoes
        [Authorize]
        public IActionResult Index()
        {
            var userDebts = new UserDebtsViewModel();
            List<Debt> list = new List<Debt>(); 
            var applicationDbContext = _context.Debt.Include(n => n.DebtOwner).Include(n => n.DebtReceiver);

            foreach (var debt in applicationDbContext.Where(x=>x.DebtOwner.Email == User.Identity.Name).ToList())
            {
                userDebts.OwnedDebts.Add(debt);
            }
            foreach (var debt in applicationDbContext.Where(x => x.DebtReceiver.Email == User.Identity.Name).ToList())
            {
                userDebts.ReceivedDebts.Add(debt);
            }

            return View(userDebts);
        }

        // GET: UserProfileInfoes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            UserProfileInfo userProfileInfo = _context.UserProfileInfo.Single(m => m.Id == id);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }

            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserProfileInfoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserProfileInfo userProfileInfo)
        {
            if (ModelState.IsValid)
            {
                _context.UserProfileInfo.Add(userProfileInfo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            UserProfileInfo userProfileInfo = _context.UserProfileInfo.Single(m => m.Id == id);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }
            return View(userProfileInfo);
        }

        // POST: UserProfileInfoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserProfileInfo userProfileInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(userProfileInfo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userProfileInfo);
        }

        // GET: UserProfileInfoes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            UserProfileInfo userProfileInfo = _context.UserProfileInfo.Single(m => m.Id == id);
            if (userProfileInfo == null)
            {
                return HttpNotFound();
            }

            return View(userProfileInfo);
        }

        // POST: UserProfileInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            UserProfileInfo userProfileInfo = _context.UserProfileInfo.Single(m => m.Id == id);
            _context.UserProfileInfo.Remove(userProfileInfo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
