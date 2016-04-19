using GdzieMojHajs.ViewModels.Debts;
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
        public IViewComponentResult Invoke(bool owned)
        {
            // user can't choose himself
            ViewData["DebtorsId"] = new SelectList(_context.UserProfileInfo, "Id", "Email").Where(x => x.Text != User.Identity.Name);

            if (owned == true)
                return View("OwnedDebt",new DebtViewModel());
            else
                return View("ReceivedDebt", new DebtViewModel());
        }
    }
}
