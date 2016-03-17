using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using GdzieMojHajs.Models;

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
        public IActionResult Index()
        {
            return View(_context.UserProfileInfo.ToList());
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
