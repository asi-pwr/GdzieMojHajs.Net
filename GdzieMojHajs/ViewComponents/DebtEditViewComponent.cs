using GdzieMojHajs.Models;
using GdzieMojHajs.ViewModels.Debts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.ViewComponents
{
    public class DebtEditViewComponent : ViewComponent
    {
        private ApplicationDbContext _context;

        public DebtEditViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(DebtViewModel debt)
        {
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

            return View("EditDebt", debt);
        }
    }
}
