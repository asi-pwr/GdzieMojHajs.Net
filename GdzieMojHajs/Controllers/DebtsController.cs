using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using GdzieMojHajs.Models;

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
            return View(_context.Debt.ToList());
        }

        // GET: Debts/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Debt debt = _context.Debt.Single(m => m.Id == id);
            if (debt == null)
            {
                return HttpNotFound();
            }

            return View(debt);
        }

        // GET: Debts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Debts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Debt debt)
        {
            if (ModelState.IsValid)
            {
                _context.Debt.Add(debt);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(debt);
        }

        // GET: Debts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Debt debt = _context.Debt.Single(m => m.Id == id);
            if (debt == null)
            {
                return HttpNotFound();
            }
            return View(debt);
        }

        // POST: Debts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Debt debt)
        {
            if (ModelState.IsValid)
            {
                _context.Update(debt);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(debt);
        }

        // GET: Debts/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Debt debt = _context.Debt.Single(m => m.Id == id);
            if (debt == null)
            {
                return HttpNotFound();
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
    }
}
