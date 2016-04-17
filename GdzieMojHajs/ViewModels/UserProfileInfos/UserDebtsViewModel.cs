using GdzieMojHajs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.ViewModels.UserProfileInfos
{
    public class UserDebtsViewModel
    {
        public List<Debt> OwnedDebts { get; set; }
        public List<Debt> ReceivedDebts { get; set; }

        public UserDebtsViewModel()
        {
            OwnedDebts = new List<Debt>();
            ReceivedDebts = new List<Debt>();
        }
    }
}
