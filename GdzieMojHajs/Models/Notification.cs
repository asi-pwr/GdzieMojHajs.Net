using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Seen { get; set; }

        [ForeignKey("UserProfileInfo")]
        public int NotificationSenderId { get; set; }
        public virtual UserProfileInfo NotificationSender { get; set; }

        [ForeignKey("UserProfileInfo")]
        public int NotificationReceiverId { get; set; }
        public virtual UserProfileInfo NotificationReceiver { get; set; }

        [ForeignKey("Debt")]
        public int DebtId { get; set; }
        public virtual Debt Debt { get; set; }

        //place for DebtMigration

    }
}
