using GdzieMojHajs.Models;
using GdzieMojHajs.ViewModels.Notifications;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.Services
{
    public class NotificationService
    {

        private ApplicationDbContext _context;

        public NotificationService (ApplicationDbContext context)
        {
            _context = context;
        }

        protected bool ValidateNotification(Notification notif)
        {
            return true;
        }

        public bool CreateNotification (NotificationViewModel notification)
        {
            //// Validation logic
            //if (!ValidateProduct(productToCreate))
            //    return false;

            //// Database logic
            //try
            //{
            //    _repository.CreateProduct(productToCreate);
            //}
            //catch
            //{
            //    return false;
            //}
            //try
            //{
                var not = new Notification
                {
                    //Debt = notification.Debt,
                    //NotificationReceiver = notification.NotificationReceiver,
                    //DebtId = notification.DebtId,
                    NotificationReceiverId = notification.NotificationReceiverId,
                    Text = notification.Text,
                    NotificationSenderId = notification.NotificationSenderId,
                    //NotificationSender = _context.UserProfileInfo.Select(x=>x.Email==)
                };
                _context.Notification.Add(not);
                _context.SaveChanges();
            //}

            //catch
            //{
            //    return false;
            //}

            return true;
        }

        public void CreateEditNotification(int receiverId, int senderId, int debtId)
        {
            NotificationViewModel newNotif = new NotificationViewModel
            {
                Text = "A debt was edited",
                NotificationReceiverId = receiverId,
                NotificationSenderId = senderId,
                DebtId = debtId
            };

            CreateNotification(newNotif);
        }

        public void CreateCreateNotification(int receiverId, int senderId, int debtId)
        {
            NotificationViewModel newNotif = new NotificationViewModel
            {
                Text = "A debt was created",
                NotificationReceiverId = receiverId,
                NotificationSenderId = senderId,
                DebtId = debtId
            };

            CreateNotification(newNotif);
        }

        public void CreateDeleteNotification(int? debtId, int senderId)
        {
            Debt debt = _context.Debt.Single(m => m.Id == debtId);
            var receiverId = senderId;

            if(debt.DebtOwnerId == senderId)
            {
                receiverId = debt.DebtReceiverId;
            }

            else
            {
                receiverId = debt.DebtOwnerId;
            }

            NotificationViewModel newNotif = new NotificationViewModel
            {
                Text = "A debt was deleted",
                DebtId = (int)debtId,
                NotificationReceiverId = receiverId,
                NotificationSenderId = senderId
                
            };

            CreateNotification(newNotif);
        }

    }
}
