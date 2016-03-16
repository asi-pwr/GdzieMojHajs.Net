using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using GdzieMojHajs.Models;

namespace GdzieMojHajs.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Debt>().HasOne(x => x.DebtOwner).WithMany().HasForeignKey(x => x.DebtOwnerId);
            builder.Entity<Debt>().HasOne(x => x.DebtReceiver).WithMany().HasForeignKey(x => x.DebtReceiverId);
            builder.Entity<Notification>().HasOne(x => x.NotificationSender).WithMany().HasForeignKey(x => x.NotificationSenderId);
            builder.Entity<Notification>().HasOne(x => x.NotificationReceiver).WithMany().HasForeignKey(x => x.NotificationReceiverId);

            builder.Entity<Debt>().HasOne(x => x.DebtOwner).WithMany(x => x.OwnedDebts);
            builder.Entity<Debt>().HasOne(x => x.DebtReceiver).WithMany(x => x.ReceivedDebts);
            builder.Entity<Notification>().HasOne(x => x.NotificationSender).WithMany(x => x.SendNotifications);
            builder.Entity<Notification>().HasOne(x => x.NotificationReceiver).WithMany(x => x.ReceivedNotifications);

        }

        public DbSet<UserProfileInfo> UserProfileInfo { get; set; }

        public DbSet<Debt> Debt { get; set; }

        public DbSet<Notification> Notification { get; set; }
    }
}
