using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GdzieMojHajs.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfileInfo UserProfileInfo { get; set; }

    }
    //public static class IdentityExtensions
    //{
    //    public static string UserProfileInfo(this IIdentity identity)
    //    {
    //        var claim = ((ClaimsIdentity)identity).FindFirst("UserProfileInfo");
    //        // Test for null to avoid issues during local testing
    //        return (claim != null) ? claim.Value : string.Empty;
    //    }
    //}
}
