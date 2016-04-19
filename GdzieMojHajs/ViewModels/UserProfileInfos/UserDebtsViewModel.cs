using GdzieMojHajs.Models;
using GdzieMojHajs.ViewModels.Debts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.ViewModels.UserProfileInfos
{
    public class UserDebtsViewModel
    {
        public List<DebtViewModel> OwnedDebts { get; set; }
        public List<DebtViewModel> ReceivedDebts { get; set; }

        public UserDebtsViewModel()
        {
            OwnedDebts = new List<DebtViewModel>();
            ReceivedDebts = new List<DebtViewModel>();
        }
    }
}
