using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdzieMojHajs.Models
{
    public class UserProfileInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public bool AllowsToMigrateDebts { get; set; }
    }
}
