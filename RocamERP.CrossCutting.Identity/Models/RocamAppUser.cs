using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace RocamERP.CrossCutting.Identity.Models
{
    public class RocamAppUser : IdentityUser
    {
        public DateTime? DateRegistered { get; set; }
    }
}
