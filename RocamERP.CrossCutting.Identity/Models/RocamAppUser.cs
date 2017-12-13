using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace RocamERP.CrossCutting.Identity.Models
{
    public class RocamAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime? DateRegistered { get; set; }
    }
}
