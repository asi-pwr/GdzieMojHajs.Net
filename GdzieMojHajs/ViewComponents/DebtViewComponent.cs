using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.Models
{
    public class DebtViewComponent : ViewComponent
    {
        private ApplicationDbContext _context;

        public DebtViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        //place for DebtMigration
        public IViewComponentResult Invoke()
        {
            ViewData["DebtOwnerId"] = new SelectList(_context.UserProfileInfo, "Id", "Email");
            ViewData["DebtReceiverId"] = new SelectList(_context.UserProfileInfo, "Id", "Email");
            return View(new Debt());
        }
    }
}
