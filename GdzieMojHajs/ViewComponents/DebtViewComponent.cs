using GdzieMojHajs.ViewModels.Debts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var users = _context.UserProfileInfo;
            List<object> newList = new List<object>();

            foreach (var member in users)
            {
                if (member.Email != User.Identity.Name)
                {
                    newList.Add(new
                    {
                        Id = member.Id,
                        Name = member.Name + " " + member.Surname
                    });
                }
            }

            ViewData["DebtorsId"] = new SelectList(newList, "Id", "Name");

            if (owned == true)
                return View("OwnedDebt",new DebtViewModel());
            else
                return View("ReceivedDebt", new DebtViewModel());
        }
    }
}
