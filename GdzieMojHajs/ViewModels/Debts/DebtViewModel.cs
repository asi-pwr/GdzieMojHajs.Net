using GdzieMojHajs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.ViewModels.Debts
{
    public class DebtViewModel
    {
        public double Amount { get; set; }
        public string Comment { get; set; }
        public string Date
        {
            get { return _date.Date.ToString("dd/MM/yyyy"); } set { _date = DateTime.Parse(value); }
        }


        public int DebtOwnerId { get; set; }
        public UserProfileInfo DebtOwner { get; set; }

        public int DebtReceiverId { get; set; }
        public UserProfileInfo DebtReceiver { get; set; }

        private DateTime _date;

        //place for DebtMigration

        public DebtViewModel()
        {
            _date = DateTime.Now;
        }
    }
}


