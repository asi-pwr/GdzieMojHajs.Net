using GdzieMojHajs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.ViewModels.Debts
{
    public class DebtViewModel
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public int IntAmount { get { return (int)(Amount * 100); } set { Amount = (((double)value) / 100); } }  //to get and set int values 
        public string Comment { get; set; }
        public string Date
        {
            get { return _date.Date.ToString("dd/MM/yyyy"); }
            set {
                 _date = DateTime.Parse(value);
            }
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

        //public int GetAmountToDB()
        //{
        //    return (int)(Amount * 100);
        //}

        //public void SetAmountFromDB(int amount)
        //{
        //    Amount = (amount / 100);
        //}
    }
}


