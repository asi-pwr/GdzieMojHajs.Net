﻿using GdzieMojHajs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.ViewModels.Notifications
{
    public class NotificationViewModel
    {
        [Display(Name = "Tekst")]
        public string Text { get; set; }

        [Display(Name = "Odbiorca")]
        public int NotificationReceiverId { get; set; }
        [Display(Name = "Odbiorca")]
        public UserProfileInfo NotificationReceiver { get; set; }

        [Display(Name = "Nadawca")]
        public int NotificationSenderId { get; set; }
        [Display(Name = "Nadawca")]
        public UserProfileInfo NotificationSender { get; set; }


        [Display(Name = "Dług")]
        public int DebtId { get; set; }
        [Display(Name = "Dług")]
        public Debt Debt { get; set; }
    }
}
