using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.Models
{
    public class UserProfileInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool AllowsToMigrateDebts { get; set; }

        public virtual ICollection<Debt> OwnedDebts { get; set; }
        public virtual ICollection<Debt> ReceivedDebts { get; set; }

        public virtual ICollection<Notification> SendNotifications { get; set; }
        public virtual ICollection<Notification> ReceivedNotifications { get; set; }

        //place for DebtMigration
    }
}
