using GdzieMojHajs.Models;
using GdzieMojHajs.ViewModels.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.Services
{
    public class DebtService
    {
        private ApplicationDbContext _context;

        public DebtService(ApplicationDbContext context)
        {
            _context = context;
        }

        protected bool ValidateDebt(DebtViewModel debt)
        {
            return true;
        }

        public bool CreateDebt(DebtViewModel debt)
        {
            if (ValidateDebt(debt))
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
                return true;
            }
            return false;
        }

        public bool EditDebt(DebtViewModel debt)
        {
            Debt toUpdate = _context.Debt.Single(m => m.Id == debt.Id);
            toUpdate.Amount = debt.IntAmount;
            toUpdate.Comment = debt.Comment;
            toUpdate.Date = DateTime.Parse(debt.Date);
            toUpdate.DebtOwnerId = debt.DebtOwnerId;
            toUpdate.DebtReceiverId = debt.DebtReceiverId;

            _context.Update(toUpdate);
            _context.SaveChanges();

            return true;
        }

        public void DeleteDebt(int? id)
        {
            Debt debt = _context.Debt.Single(m => m.Id == id);
            _context.Debt.Remove(debt);
            _context.SaveChanges();
        }
    }
}
