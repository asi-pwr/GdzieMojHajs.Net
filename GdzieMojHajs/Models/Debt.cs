using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.Models
{
    public class Debt
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }


        [ForeignKey("UserProfileInfo")]
        public int DebtOwnerId { get; set; }
        public virtual UserProfileInfo DebtOwner { get; set; }

        [ForeignKey("UserProfileInfo")]
        public int DebtReceiverId { get; set; }
        public virtual UserProfileInfo DebtReceiver { get; set; }

        //place for DebtMigration
    }
}
